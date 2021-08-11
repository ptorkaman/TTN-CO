using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Services.User;
using Repository;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Http;
using DTO.Settings;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Common.Utilities;
using Common.Extensions;
using DTO.DependencyInjection;
using Domain;
using TTNCO.Versioning;
using Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace TTNCO
{
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


        public IConfiguration Configuration { get; }
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
            });
            //    .AddNewtonsoftJson(z =>
            //{
            //    z.SerializerSettings.ContractResolver = new DefaultContractResolver
            //    {
            //        NamingStrategy = new SnakeCaseNamingStrategy()
            //    };
            //    z.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});


            services.RegisterScoped<IScopedInjectable>(typeof(IScopedInjectable).Assembly);

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

            //services.AddDbContext<TTNContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TTNContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
             ServiceLifetime.Transient);
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
                        $"Clean Architecture API's for integration with UI \r\n\r\n � Copyright {DateTime.Now.Year} JK. All rights reserved."
                });
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Clean Architecture v2 API's",
                    Description =
                        $"Clean Architecture API's for integration with UI \r\n\r\n � Copyright {DateTime.Now.Year} JK. All rights reserved."
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

            //services.AddSwaggerGenNewtonsoftSupport();

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
            services.AddScoped<ISenderRepository, SenderRepository>();

            
            #endregion

            #region Services
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
        }
    }
}
