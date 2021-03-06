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
    public class MenuController : BaseController
    {
        #region Fields
        private readonly IMenuService _menuService;
        #endregion

        #region CTOR

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        #endregion

        #region Menu Actions
        [HttpPost()]
        public async Task<ApiResult<MenuDTO>> Create(MenuDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _menuService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _menuService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<MenuDTO>> Update(int Id, MenuDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _menuService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<MenuDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _menuService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<Menu>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _menuService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

