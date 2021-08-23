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
    public class PermissionController : BaseController
    {
        #region Fields
        private readonly IPermissionService _countryService;
        #endregion

        #region CTOR

        public PermissionController(IPermissionService countryService)
        {
            _countryService = countryService;
        }
        #endregion

        #region Permission Actions
        [HttpPost()]
        public async Task<ApiResult<PermissionDTO>> CreatePermission(PermissionDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _countryService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeletePermission(int Id, CancellationToken cancellationToken)
        {
            var result = await _countryService.DeletePermissionAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<PermissionDTO>> UpdatePermission(int Id, PermissionDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _countryService.UpdatePermissionAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet()]
        public async Task<ApiResult<List<PermissionDTO>>> GetAllCities(CancellationToken cancellationToken)
        {
            var result = await _countryService.GetAllAsync(cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<PermissionDTO>>> GetCities(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _countryService.GetAllCitiesAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

