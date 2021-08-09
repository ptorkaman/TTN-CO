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
    public class RegionController : BaseController
    {
        #region Fields
        private readonly IRegionService _regionService;
        #endregion

        #region CTOR

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        #endregion

        #region Region Actions
        [HttpPost()]
        public async Task<ApiResult<RegionDTO>> CreateRegion(RegionDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _regionService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteRegion(int Id, CancellationToken cancellationToken)
        {
            var result = await _regionService.DeleteRegionAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<RegionDTO>> UpdateRegion(int Id, RegionDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _regionService.UpdateRegionAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<List<RegionDTO>>> GetAll(int id,CancellationToken cancellationToken)
        {
            var result = await _regionService.GetByCityId(id,cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<RegionDTO>>> Get(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _regionService.GetAllCitiesAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

