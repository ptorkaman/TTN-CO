using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
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
    public class SenderReciverController : BaseController
    {
        #region Fields
        private readonly ISenderReciverService _senderReciverService;
        #endregion

        #region CTOR

        public SenderReciverController(ISenderReciverService senderReciverService)
        {
            _senderReciverService = senderReciverService;
        }
        #endregion

        #region SenderReciverReciver Actions
        [HttpPost()]
        public async Task<ApiResult<SenderReciverDTO>> Create(SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _senderReciverService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _senderReciverService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<SenderReciverDTO>> Update(int Id, SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _senderReciverService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet()]
        public async Task<ApiResult<List<SenderReciverDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _senderReciverService.GetAsync(cancellationToken);
           
            return result;
        }
        //[HttpGet("GetAll")]
        //public async Task<ApiResult<PagedResult<SenderReciver>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        //{
        //    var result = await _senderReciverService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
        //    return result;
        //}
     
        #endregion
    }
}

