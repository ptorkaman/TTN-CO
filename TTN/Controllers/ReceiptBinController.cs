using System;
using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using albim.Result;
using DAL.Models;
using TTN.Controllers.v1;
using TTN;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Authorize]
    //[Route("api/[controller]")]
    //[Authorize]
    public class ReceiptBinController : BaseController
    {
        #region Fields
        private readonly IReceiptBinService _recieptBinService;

        #endregion

        #region CTOR

        public ReceiptBinController(IReceiptBinService recieptBinService)
        {
            _recieptBinService = recieptBinService;
  

        }
        #endregion

        #region ReceiptBin Actions
        //[HttpPost("FindAll")]
        //public DtoBase FindAll(SpecificationOfDataList<ReceiptBinDTO> filter)
        //{
        //    DtoBase result = new DtoBase();
        //    try
        //    {
        //        filter.FilterSpecifications.Add(new FilterSpecification<ReceiptBinDTO>()
        //        {
        //            FilterValue = "te",
        //            PropertyName = "Name",
        //            FilterOperation = FilterOperations.NotEqual
        //        });
        //        var obj = _cityService.FindAll(filter.PageSize, filter.PageIndex, filter.GetCriteria());
        //        result.Results = obj;
        //        result.DtoIsValid = true;
        //        result.Status = "200";
        //        //LoggerProxy.Log(LoggerProxy.LogLevels.Info, typeof(Type), " Success " + Request.RequestUri + " || userId:" + userId + " UserIP:" + ip, null);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        result.DtoIsValid = false;
        //        result.Status = "500";
        //        result.MessageError.Add(e.ToString());
        //        //LoggerProxy.Log(LoggerProxy.LogLevels.Error, typeof(Type), " Faild( " + e + "   )" + this.Request.RequestUri + " || userId:" + userId + " UserIP:" + ip, null);
        //        return result;
        //    }
        //}

        [HttpPost()]
        public async Task<ApiResult<ReceiptBinDTO>> Create(ReceiptBinDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _recieptBinService.Create(modelDto, cancellationToken);
            return result;
        }

        //[HttpDelete("{Id}")]
        //public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        //{
        //    var result = await _cityService.DeleteAsync(Id, cancellationToken);
        //    return result.ToString();
        //}

        //[HttpPut("{Id}")]
        //public async Task<ApiResult<ReceiptBinDTO>> Update(int Id, ReceiptBinDTO modelDto, CancellationToken cancellationToken)
        //{
        //    var result = await _cityService.UpdateAsync(Id, modelDto, cancellationToken);
        //    return result;
        //}

     

        //[HttpGet("Get")]
        //public async Task<ApiResult<List<ReceiptBinDTO>>> Get(CancellationToken cancellationToken)
        //{
        //    var result = await _cityService.GetAsync(cancellationToken);
            
        //    return result;
        //}

        //[HttpGet("GetAll")]
        //public async Task<ApiResult<PagedResult<ReceiptBin>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        //{
        //    var result = await _cityService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
        //    return result;
        //}


        #endregion
    }
}

