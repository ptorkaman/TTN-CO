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
    public class ParishController : BaseController
    {
        #region Fields
        private readonly IParishService _parishService;
        #endregion

        #region CTOR

        public ParishController(IParishService parishService)
        {
            _parishService = parishService;
        }
        #endregion

        #region Parish Actions
        [HttpPost()]
        public async Task<ApiResult<ParishDTO>> CreateParish(ParishDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _parishService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteParish(int Id, CancellationToken cancellationToken)
        {
            var result = await _parishService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<ParishDTO>> UpdateParish(int Id, ParishDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _parishService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<ParishDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _parishService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<Parish>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _parishService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }

        #endregion
    }
}

