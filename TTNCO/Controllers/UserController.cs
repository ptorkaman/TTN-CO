using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DTO;
using Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TTNCO.Result;
using Common.Extensions;

namespace TTNCO.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {      
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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
            var model = await _userService.Login(modelDto, cancellationToken);
            model.Menu = _userService.GetMenu(model.Id);
            return model;
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
