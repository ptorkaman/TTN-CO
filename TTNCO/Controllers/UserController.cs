using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DTO;
using Services.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TTNCO.Result;
using Common.Extensions;
using Microsoft.IdentityModel.Tokens;
using TTNCO.Dto;

namespace TTNCO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {      
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        //private readonly AppSettings _appSettings;
        public UserController(ILogger<UserController> logger, IUserService userService/*, AppSettings appSettings*/)
        {
            _logger = logger;
            _userService = userService;
            //_appSettings = appSettings;
        }

        #region Create User

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ApiResult<string>> Create(RegisterDTO modelDto,
            CancellationToken cancellationToken)
        {

            var user = await _userService.Register(modelDto, cancellationToken);
            return user.ToString();
        }

        #endregion
        //[HttpPost("login")]
        //[AllowAnonymous]
        //public async Task<ApiResult<LoginDataDTO>> Login(LoginDTO modelDto, CancellationToken cancellationToken)
        //{
        //    var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //    var key = new byte[64];// Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var model = await _userService.Login(modelDto, cancellationToken, ip, key);

        //    //model.Menu = _userService.GetMenu(model.Id);
        //    return model;
        //}
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ApiResult<DtoBase>> Login(LoginDTO dto)
        {

            var result = new DtoBase();
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var userAgent = Request.Headers["User-Agent"].ToString();
            var user = Authenticate1(dto.UserName, dto.Password, "h", ip, userAgent);

            if (user == null)
            {
                result.DtoIsValid = false;
                result.Status = "500";
                result.MessageError.Add("Username or password is incorrect");
            }
            else
            {
                result.DtoIsValid = true;
                result.Status = "200";
                result.Results = user;
            }
            return result;
        }
        [NonAction]
        protected NodeDto Authenticate1(string username, string password, string tokenRefresh, string ip, string userAgent)
        {
            var result = new NodeDto();
            var userInfo = new UserInfo();
            var user = _userService.Login1(username, password);
            if (user != null)
            {


                //if (Password.HashPassword(password, user.SecretKey) != user.Password && Password.SaltPass(password, user.SecretKey) != user.Password)

                //    return null;


                //var servicesProject = user.Roles.FirstOrDefault(x => x.Role.Project.Name == "Services");
                //if (servicesProject != null)
                //{
                //    result.ValidForServices = false;
                //    return result;

                //}

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);//must be 16 character
                var claims = new ClaimsIdentity();
                //claims.AddClaim(new Claim(type: ClaimTypes.Name, user.UserName));
                //claims.AddClaim(new Claim(type: "UserId", user.Id.ToString()));
                claims.AddClaim(new Claim(type: "Ip", ip));
                //claims.AddClaim(new Claim(ClaimTypes.Country, user.Base));
                claims.AddClaim(new Claim(type: "UserAgent", userAgent));
                string listmenu = "";
                //user.UserMenus.ToList().ForEach(x =>
                //{
                //    listmenu = listmenu + "," + x.Menu.Name.ToString();
                //    //claims.AddClaim(new Claim(type: "UserMenues", x.Menu.Name.ToString()));

                //    //claims.AddClaim(new Claim(ClaimTypes., x.Role.Name));

                //});
                //    claims.AddClaim(new Claim(type: "UserMenues", listmenu));

                //    user.Roles.ToList().ForEach((x) =>
                //    {


                //        claims.AddClaim(new Claim(ClaimTypes.Role, x.Role.Name));
                //        claims.AddClaim(new Claim("RoleIds", x.Role.Id.ToString()));

                //        var module = new Module
                //        {
                //            Id = x.Role.ProjectId,
                //            Name = x.Role.Project.Name,
                //            Link = x.Role.Project.Name.Replace(" ", string.Empty).Replace("&", string.Empty),
                //            DashboarUrl = x.Role.Project.DashboarUrl
                //        };

                //        var module1 = x.Role.ModuleActionRoles.Select(u => u.ModuleAction);
                //        foreach (var item1 in x.Role.ModuleActionRoles)
                //        {
                //            var action = item1.ModuleAction.Name;
                //            var controller = item1.ModuleAction.ProjectModule.Name;
                //            var project = item1.ModuleAction.ProjectModule.Project.Name;
                //            result.Principles.Add(project + '/' + controller + '/' + action);

                //        }
                //        userInfo.Roles.Add(x.RoleId.ToString());
                //        userInfo.RoleNames.Add(x.Role.Name + "-" + x.Role.Project.Name);


                //        x.Role.PermissionRoles.ToList().ForEach((per) =>
                //        {
                //            bool noMenu = false;
                //            foreach (var item5 in result.Modules)
                //            {
                //                if (item5.Menus.FirstOrDefault(q => q.Id == per.PermissionId) != null)
                //                    noMenu = true;
                //            }
                //            if (noMenu == false)
                //                module.Menus.Add(new Menue()
                //                {
                //                    Id = per.PermissionId,
                //                    ParentId = per.Permission.ParentId,
                //                    Name = per.Permission.Title,
                //                    Link = per.Permission.Title.Replace(" ", string.Empty).Replace("&", string.Empty),
                //                });

                //        });
                //        if (result.Modules.FirstOrDefault(y => y.Id == module.Id) == null)
                //            result.Modules.Add(module);
                //        else
                //        {
                //            var modulenew = result.Modules.FirstOrDefault(yx => yx.Id == module.Id);
                //            if (modulenew != null)
                //            {
                //                module.Menus.ToList().ForEach((item1) =>
                //                {
                //                    modulenew.Menus.Add(item1);
                //                });
                //            }

                //        }
                //    });
                //    user.Stations.ToList().ForEach((x) =>
                //    {
                //        Claim c1 = new Claim("Stations", x.StationId.ToString());
                //        userInfo.Stations.Add(x.StationId);

                //        claims.AddClaim(c1);

                //    });

                //    claims.AddClaims(new[]
                //    {

                //    new Claim(ClaimTypes.Name,user.UserName),
                //    new Claim(ClaimTypes.Country,user.Base),
                //    new Claim(ClaimTypes.UserData,user.Id.ToString())
                //}
                //);
                var key = new byte[64];
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddYears(100),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var token1 = tokenHandler.WriteToken(token);
                //SaveToken
                //var userToken = new UserToken(0, user.Id, GetSha256Hash(token1), tokenDescriptor.Expires.Value, ip, user.UserName, Guid.NewGuid().ToString(), tokenDescriptor.Expires.Value, userAgent);
                //var tokennew = _userTokenService.CreateToken(userToken);
                //if (tokennew == null)
                //    throw new Exception("ارتباط با سرور مقدور نمی باشد");

                //result.Ip = ip;
                //result.Enviroment = userAgent;
                result.Token = token1;
                //userInfo.UserId = user.Id;
                //userInfo.Base = user.Base;
                //userInfo.DisplayName = user.DisplayName;
                //userInfo.UserName = user.UserName;

                //result.User = userInfo;
                //result.ExpireDate = 1;
                //result.AccessTokenExpirationDateTime = tokenDescriptor.Expires.Value;

                return result;
            }
            return null;
        }


        [HttpPost("ForgetPassword")]
        [AllowAnonymous]
        public async Task<ApiResult<string>> ForgetPassword(SendSmsDTO modelDto,
          CancellationToken cancellationToken)
        {
            var res = _userService.ForgetPassword(modelDto, cancellationToken);
            return res.ToString();
        }
        [HttpPost("CheckVerification")]
        [AllowAnonymous]
        public async Task<ApiResult<string>> CheckVerification(CheckVerificationDTO model,
       CancellationToken cancellationToken)
        {
            var res = await _userService.CheckVerification(model, cancellationToken);
            return res;
        }
    }
}
