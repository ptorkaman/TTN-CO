using Common.Extensions;
using Common.Utilities;
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
    [AllowAnonymous]
    public class CountryController : BaseController
    {
        #region Fields
        private readonly ICountryService _countryService;
        #endregion

        #region CTOR

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        #endregion

        #region Country Actions
        [HttpPost()]
        public async Task<ApiResult<CountryDTO>> CreateCountry(CountryDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _countryService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteCountry(int Id, CancellationToken cancellationToken)
        {
            var result = await _countryService.DeleteCountryAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<CountryDTO>> UpdateCountry(int Id, CountryDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _countryService.UpdateCountryAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet()]
        public async Task<ApiResult<List<CountryDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _countryService.GetAllAsync(cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<CountryDTO>>> Get(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _countryService.GetAllCitiesAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

