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
    public class ReceiptStatusController : BaseController
    {
        #region Fields
        private readonly IReceiptStatusService _receiptStatusService;
        #endregion

        #region CTOR
        public ReceiptStatusController(IReceiptStatusService receiptStatusService)
        {
            _receiptStatusService = receiptStatusService;
        }
        #endregion

        #region ReceiptStatus Actions
        [HttpPost()]
        public async Task<ApiResult<ReceiptStatusDTO>> Create(ReceiptStatusDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _receiptStatusService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _receiptStatusService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<ReceiptStatusDTO>> Update(int Id, ReceiptStatusDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _receiptStatusService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<ReceiptStatusDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _receiptStatusService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<ReceiptStatus>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _receiptStatusService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }



        #endregion
    }
}

