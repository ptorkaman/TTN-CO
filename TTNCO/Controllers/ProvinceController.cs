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
        public async Task<ApiResult<ProvinceDTO>> Create(ProvinceDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _provinceService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _provinceService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<ProvinceDTO>> Update(int Id, ProvinceDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _provinceService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<ProvinceDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _provinceService.GetAllAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<Province>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _provinceService.GetAllProvinceAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }




        #endregion
    }
}

