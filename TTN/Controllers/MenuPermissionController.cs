using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using albim.Result;
using Domain;
using TTN.Controllers.v1;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Authorize]
    public class MenuPermissionController : BaseController
    {
        #region Fields
        private readonly IMenuPermissionService _menuPermissionService;
        #endregion

        #region CTOR

        public MenuPermissionController(IMenuPermissionService menuPermissionService)
        {
            _menuPermissionService = menuPermissionService;
        }
        #endregion

        #region MenuPermission Actions
        [HttpPost()]
        public async Task<ApiResult<MenuPermissionDTO>> Create(MenuPermissionDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _menuPermissionService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<MenuPermissionDTO>> Update(int Id, MenuPermissionDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<MenuPermissionDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<MenuPermission>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _menuPermissionService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }

        #endregion
    }
}

