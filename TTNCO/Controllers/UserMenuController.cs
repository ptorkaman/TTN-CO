using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using TTNCO.Result;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [AllowAnonymous]
    public class UserMenuController : BaseController
    {
        #region Fields
        private readonly IUserMenuService _menuPermissionService;
        #endregion

        #region CTOR

        public UserMenuController(IUserMenuService menuPermissionService)
        {
            _menuPermissionService = menuPermissionService;
        }
        #endregion

        #region UserMenu Actions
        [HttpPost()]
        public async Task<ApiResult<UserMenuDTO>> CreateUserMenu(UserMenuDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _menuPermissionService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteUserMenu(int Id, CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<UserMenuDTO>> UpdateUserMenu(int Id, UserMenuDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<UserMenuDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<UserMenu>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }

        #endregion
    }
}

