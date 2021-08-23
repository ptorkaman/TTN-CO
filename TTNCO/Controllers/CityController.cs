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
    public class CityController : BaseController
    {
        #region Fields
        private readonly ICityService _cityService;
        #endregion

        #region CTOR

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        #endregion

        #region City Actions
        [HttpPost()]
        public async Task<ApiResult<CityDTO>> Create(CityDTO modelDto, CancellationToken cancellationToken)
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
        public async Task<ApiResult<CityDTO>> Update(int Id, CityDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet("Get")]
        public async Task<ApiResult<List<CityDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<City>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }
        #endregion
    }
}

