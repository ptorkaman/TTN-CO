using Common.Extensions;
using Common.Utilities;
using DTO;
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
 
    public class SenderController : BaseController
    {
        #region Fields
        private readonly ISenderService _cityService;
        #endregion

        #region CTOR

        public SenderController(ISenderService cityService)
        {
            _cityService = cityService;
        }
        #endregion

        #region Sender Actions
        [HttpPost()]
        public async Task<ApiResult<SenderDTO>> Create(SenderDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _cityService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _cityService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<SenderDTO>> Update(int Id, SenderDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<List<SenderDTO>>> Get(int id,CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAsync(id,cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<SenderDTO>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

