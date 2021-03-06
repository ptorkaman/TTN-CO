using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using albim.Result;
using Domain;
using Microsoft.AspNetCore.Authorization;
using TTN.Controllers.v1;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Authorize]
    public class ReceiptController : BaseController
    {
        #region Fields
        private readonly IReceiptService _receiptService;
        #endregion

        #region CTOR

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }
        #endregion

        #region Receipt Actions
        [HttpPost()]
        public async Task<ApiResult<ReceiptDTO>> Create(ReceiptDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _receiptService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _receiptService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<ReceiptDTO>> Update(int Id, ReceiptDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.ModifiedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _receiptService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<ReceiptDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _receiptService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<Receipt>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _receiptService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }

       
        #endregion
    }
  
}

