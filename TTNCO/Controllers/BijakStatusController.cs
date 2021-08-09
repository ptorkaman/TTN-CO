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
    public class BijakStatusController : BaseController
    {
        #region Fields
        private readonly IBijakStatusService _cityService;
        #endregion

        #region CTOR

        public BijakStatusController(IBijakStatusService cityService)
        {
            _cityService = cityService;
        }
        #endregion

        #region BijakStatus Actions
        [HttpPost()]
        public async Task<ApiResult<ReceiptStatusDTO>> CreateBijakStatus(ReceiptStatusDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _cityService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteBijakStatus(int Id, CancellationToken cancellationToken)
        {
            var result = await _cityService.DeleteBijakStatusAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<ReceiptStatusDTO>> UpdateBijakStatus(int Id, ReceiptStatusDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateBijakStatusAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet()]
        public async Task<ApiResult<List<ReceiptStatusDTO>>> GetAllCities(CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllAsync(cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<ReceiptStatusDTO>>> GetCities(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllCitiesAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        
        #endregion
    }
}

