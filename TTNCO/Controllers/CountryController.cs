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
        public async Task<ApiResult<CountryDTO>> Create(CountryDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _countryService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _countryService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<CountryDTO>> Update(int Id, CountryDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _countryService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<CountryDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _countryService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<Country>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _countryService.GetAllCountryAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

