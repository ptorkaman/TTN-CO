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
    public class SenderReciverController : BaseController
    {
        #region Fields
        private readonly ISenderService _senderReciverService;
        #endregion

        #region CTOR

        public SenderReciverController(ISenderService senderReciverService)
        {
            _senderReciverService = senderReciverService;
        }
        #endregion

        #region SenderReciver Actions
        [HttpPost()]
        public async Task<ApiResult<SenderDTO>> Create(SenderDTO modelDto, CancellationToken cancellationToken)
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
        public async Task<ApiResult<SenderDTO>> Update(int Id, SenderDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _senderReciverService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet("Get")]
        public async Task<ApiResult<List<SenderDTO>>> Get(CancellationToken cancellationToken)
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

