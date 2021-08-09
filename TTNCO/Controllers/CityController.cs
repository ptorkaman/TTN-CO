using Common.Extensions;
using Common.Utilities;
using Domain;
using DTO;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ApiResult<CityDTO>> CreateCity(CityDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _cityService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteCity(int Id, CancellationToken cancellationToken)
        {
            var result = await _cityService.DeleteCityAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<CityDTO>> UpdateCity(int Id, CityDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateCityAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<List<CityDTO>>> GetAllCities(int id,CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllAsync(id,cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<CityDTO>>> GetCities(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllCitiesAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

