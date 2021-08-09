using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TTNCO.Result;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [AllowAnonymous]
    public class MenuPermissionController : BaseController
    {
        #region Fields
        private readonly IMenuPermissionService _menuService;
        #endregion

        #region CTOR

        public MenuPermissionController(IMenuPermissionService menuService)
        {
            _menuService = menuService;
        }
        #endregion

        #region MenuPermission Actions
        [HttpPost()]
        public async Task<ApiResult<MenuPermissionDTO>> CreateMenuPermission(MenuPermissionDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _menuService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteMenuPermission(int Id, CancellationToken cancellationToken)
        {
            var result = await _menuService.DeleteMenuPermissionAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<MenuPermissionDTO>> UpdateMenuPermission(int Id, MenuPermissionDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _menuService.UpdateMenuPermissionAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet()]
        public async Task<ApiResult<List<MenuPermissionDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _menuService.GetAll(cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<MenuPermissionDTO>>> GetCities(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _menuService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

