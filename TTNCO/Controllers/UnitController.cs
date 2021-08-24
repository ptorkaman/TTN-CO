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
    public class UnitController : BaseController
    {
        #region Fields
        private readonly IUnitService _unitService;
        #endregion

        #region CTOR

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        #endregion

        #region Unit Actions
        [HttpPost()]
        public async Task<ApiResult<UnitDTO>> Create(UnitDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _unitService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _unitService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<UnitDTO>> Update(int Id, UnitDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _unitService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet("Get")]
        public async Task<ApiResult<List<UnitDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _unitService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<Unit>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _unitService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }
        #endregion
    }
}

