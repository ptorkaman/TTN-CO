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
    public class ProvinceController : BaseController
    {
        #region Fields
        private readonly IProvinceService _provinceService;
        #endregion

        #region CTOR

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        #endregion

        #region Province Actions
        [HttpPost()]
        public async Task<ApiResult<ProvinceDTO>> CreateProvince(ProvinceDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _provinceService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteProvince(int Id, CancellationToken cancellationToken)
        {
            var result = await _provinceService.DeleteProvinceAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<ProvinceDTO>> UpdateProvince(int Id, ProvinceDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _provinceService.UpdateProvinceAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<List<ProvinceDTO>>> GetAll(int id,CancellationToken cancellationToken)
        {
            var result = await _provinceService.GetAllAsync(id,cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<ProvinceDTO>>> Get(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _provinceService.GetAllCitiesAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

