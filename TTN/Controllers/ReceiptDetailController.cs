using albim.Result;
using Common.Extensions;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TTN.Controllers.v1;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Authorize]
    public class ReceiptDetailController : BaseController
    {
        #region Fields
        private readonly IReceiptDetailService _receiptDetailService;
        #endregion

        #region CTOR

        public ReceiptDetailController(IReceiptDetailService receiptDetailService)
        {
            _receiptDetailService = receiptDetailService;
        }
        #endregion

        #region ReceiptDetail Actions
        [HttpPost()]
        public async Task<ApiResult<ReceiptDetailDTO>> Create(ReceiptDetailDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.DownloadBy =int .Parse( HttpContext.User.Identities.Select(c => c.Claims).ToArray()[0].ToArray()[0].Value);
            modelDto.DownloadDate = DateTime.Now;
         
            var result = await _receiptDetailService.UpdateDetail(modelDto, cancellationToken);
            return result;
        }

        //[HttpDelete("{Id}")]
        //public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        //{
        //    var result = await _receiptService.DeleteAsync(Id, cancellationToken);
        //    return result.ToString();
        //}

        //[HttpPut("{Id}")]
        //public async Task<ApiResult<ReceiptDetailDTO>> Update(int Id, ReceiptDetailDTO modelDto, CancellationToken cancellationToken)
        //{
        //    modelDto.ModifiedBy = HttpContext.User.Identity.GetUserId<int>();

        //    var result = await _receiptService.UpdateAsync(Id, modelDto, cancellationToken);
        //    return result;
        //}

        //[HttpGet("Get")]
        //public async Task<ApiResult<List<ReceiptDetailDTO>>> Get(CancellationToken cancellationToken)
        //{
        //    var result = await _receiptService.GetAsync(cancellationToken);
        //    return result;
        //}

        //[HttpGet("GetAll")]
        //public async Task<ApiResult<PagedResult<ReceiptDetail>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        //{
        //    var result = await _receiptService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
        //    return result;
        //}

       
        #endregion
    }
    
}

