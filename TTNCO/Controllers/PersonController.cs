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
    public class PersonController : BaseController
    {
        #region Fields
        private readonly IPersonService _personService;
        #endregion

        #region CTOR

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        #endregion

        #region Person Actions
        [HttpPost()]
        public async Task<ApiResult<PersonDTO>> Create(PersonDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _personService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _personService.DeletePersonAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<PersonDTO>> Update(int Id, PersonDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _personService.UpdatePersonAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet()]
        public async Task<ApiResult<List<PersonDTO>>> GetAllCities(CancellationToken cancellationToken)
        {
            var result = await _personService.GetAllAsync(cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<PersonDTO>>> GetCities(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _personService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

