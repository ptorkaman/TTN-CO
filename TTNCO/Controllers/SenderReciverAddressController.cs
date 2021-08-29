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
using TTNCO.Result;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [AllowAnonymous]
    public class SenderReciverAddressController : BaseController
    {
        #region Fields
        private readonly ISenderReciverAddressService _senderReciverAddressService;
        #endregion

        #region CTOR

        public SenderReciverAddressController(ISenderReciverAddressService senderReciverAddressService)
        {
            _senderReciverAddressService = senderReciverAddressService;
        }
        #endregion

        #region SenderReciver Actions
        [HttpPost()]
        public async Task<ApiResult<SenderReciverAddressDTO>> Create(SenderReciverAddressDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _senderReciverAddressService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _senderReciverAddressService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<SenderReciverAddressDTO>> Update(int Id, SenderReciverAddressDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _senderReciverAddressService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet("Get")]
        public async Task<ApiResult<List<SenderReciverAddressDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _senderReciverAddressService.GetAsync(cancellationToken);
            return result;
        }

    
        #endregion
    }
}

