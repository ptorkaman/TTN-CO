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
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ApiResult<LoginDataDTO>> Login(LoginDTO modelDto, CancellationToken cancellationToken)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var key = new byte[64];// Encoding.ASCII.GetBytes(_appSettings.Secret);
            var model = await _userService.Login(modelDto, cancellationToken, ip, key);

            //model.Menu = _userService.GetMenu(model.Id);
            return model;
        }
        //[AllowAnonymous]
        //[HttpPost("Login")]
        //public async Task<ApiResult<DtoBase>> Login(LoginDTO dto)
        //{

        //    var result = new DtoBase();
        //    var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //    var userAgent = Request.Headers["User-Agent"].ToString();
        //    var user = Authenticate1(dto.UserName, dto.Password, "h", ip, userAgent);

        //    if (user == null)
        //    {
        //        result.DtoIsValid = false;
        //        result.Status = "500";
        //        result.MessageError.Add("Username or password is incorrect");
        //    }
        //    else
        //    {
        //        result.DtoIsValid = true;
        //        result.Status = "200";
        //        result.Results = user;
        //    }
        //    return result;
        //}
        [NonAction]
        protected NodeDto Authenticate1(string username, string password, string tokenRefresh, string ip, string userAgent)
        {
            var result = new NodeDto();
            var userInfo = new UserInfo();
            var user = _userService.Login1(username, password);
            if (user != null)
            {
                result.UserMenus = user.UserMenus;

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
                //result.UserMenus = user.;
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
