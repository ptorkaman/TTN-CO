using albim.Versioning;
using Common.Extensions;
using Common.Utilities;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models.DependencyInjection;
using Models.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Services;
using Services.Redis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Localization;
using Repository;
using Services.User;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace albim
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private readonly SiteSettings _siteSetting;
        private readonly PagingSettings _pagingSettings;

        /// <summary>
        /// 
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            _pagingSettings = configuration.GetSection(nameof(PagingSettings)).Get<PagingSettings>();
        }


        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        /// <summary>
        /// 
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));

                var jsonInputFormatter = options.InputFormatters
                    .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
                    .Single();
                jsonInputFormatter.SupportedMediaTypes.Add("multipart/form-data");
            }).AddNewtonsoftJson(z =>
            {
                z.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
                z.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); 


            services.RegisterScoped<IScopedInjectable>(typeof(IScopedInjectable).Assembly);


            #region Localization

            services.AddLocalization(options => options.ResourcesPath = "");
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("fa-IR"),
                        new CultureInfo("en-US"),
                       
                    };
                    options.DefaultRequestCulture = new RequestCulture(culture: "fa-IR", uiCulture: "fa-IR");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    // options.RequestCultureProviders = new[] {new RouteDataRequestCultureProvider {IndexOfCulture: 1, IndexOfUICulture = 1}};
                }
            );

            #endregion


            #region SiteSettings

            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

            #endregion

            #region PagingSettings

            services.Configure<PagingSettings>(Configuration.GetSection(nameof(PagingSettings)));

            #endregion

            #region API Versioning

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader =
                    new HeaderApiVersionReader("X-API-Version");
            });

            #endregion

            #region Connection String

            //services.AddDbContext<TTNContext>(item => item.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddDbContext<TTNContext>(item => item.UseSqlServer(Configuration.GetConnectionString("Dev"),sqlServerOptionsAction:SqlOperation=>
            {
                SqlOperation.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            })
            );
            services.AddDbContext<TTNContext>(ServiceLifetime.Transient);

            #endregion

            #region Enable Cors

            services.AddCors();

            #endregion

            #region Swagger

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = " Clean Architecture v1 API's",
                    Description =
                        $"Clean Architecture API's for integration with UI \r\n\r\n ??? Copyright {DateTime.Now.Year} JK. All rights reserved."
                });
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Clean Architecture v2 API's",
                    Description =
                        $"Clean Architecture API's for integration with UI \r\n\r\n ??? Copyright {DateTime.Now.Year} JK. All rights reserved."
                });
                swagger.ResolveConflictingActions(a => a.First());
                swagger.OperationFilter<RemoveVersionFromParameterv>();
                swagger.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                #region Enable Authorization using Swagger (JWT)

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                #endregion
            });

            #endregion

            #region Swagger Json property Support

            services.AddSwaggerGenNewtonsoftSupport();

            #endregion

            #region JWT

            // Adding Authentication    
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })

                // Adding Jwt Bearer    
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = _siteSetting.Jwt.Issuer,
                        ValidIssuer = _siteSetting.Jwt.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_siteSetting.Jwt.Key))
                    };
                });

            #endregion

            #region Dependency Injection

            services.AddTransient<IUserService, UserService>();

            #endregion

            #region Automapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IRedisService, RedisService>();
            // services.AddScoped<IStringLocalizer, StringLocalizer<Resource>>();
            #endregion
            #region Repositories

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserMenuRepository, UserMenuRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IParishRepository, ParishRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IUserWarehouseRepository, UserWarehouseRepository>();
            services.AddScoped<IBinRepository, BinRepository>();
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<IReciverRepository, ReciverRepository>();

            services.AddScoped<IPackageTypeRepository, PackageTypeRepository>();
            services.AddScoped<IReceiptDetailRepository, ReceiptDetailRepository>();
            services.AddScoped<ISenderReciverAddressRepository, SenderReciverAddressRepository>();
            services.AddScoped<IReceiptBinRepository, ReceiptBinRepository>();
            services.AddScoped<IReceiptStatusRepository, ReceiptStatusRepository>();


            #endregion

            #region Services
            services.AddScoped<IReceiptDetailService, ReceiptDetailService>();
            services.AddScoped<IReceiptStatusService, ReceiptStatusService>();
            services.AddScoped<IReceiptBinService, ReceiptBinService>();
            services.AddScoped<IStuffManagerService, StuffManagerService>();
            services.AddScoped<IUserWarhouseService, UserWarhouseService>();
            services.AddScoped<IReceiptStatusService, ReceiptStatusService>();
            services.AddScoped<IMenuPermissionService, MenuPermissionService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IParishService, ParishService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IBinService, BinService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<ISenderService, SenderService>();
            services.AddScoped<ISenderReciverService, SenderReciverService>();
            services.AddScoped<IPackageTypeService, PackageTypeService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<IVehicleManagerService, VehicleManagerService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUserMenuService, UserMenuService>();
            services.AddScoped<ISenderReciverAddressService, SenderReciverAddressService>();


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// 
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var prefix = _siteSetting.PrefixUrl;
                c.SwaggerEndpoint(prefix + "/swagger/v1/swagger.json", "API v1");
                c.SwaggerEndpoint(prefix + "/swagger/v2/swagger.json", "API v2");
                c.DocExpansion(DocExpansion.None);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region Global Cors Policy

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin  
                .AllowCredentials()); // allow credentials  

            #endregion

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.Run(async (context) =>
            {
                string myValue = configuration["AppConfig"];
                await context.Response.WriteAsync(myValue);
            });
            var localization = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localization.Value);
        }
    }
}