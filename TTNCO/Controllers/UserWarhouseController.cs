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
 
    public class UserWarhouseController : BaseController
    {
        #region Fields
        private readonly IUserWarhouseService _userWarhouseService;
        #endregion

        #region CTOR

        public UserWarhouseController(IUserWarhouseService userWarhouseService)
        {
            _userWarhouseService = userWarhouseService;
        }
        #endregion

        #region UserWarhouse Actions
        [HttpPost()]
        public async Task<ApiResult<UserWarhouseDTO>> Create(UserWarhouseDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();
            var result = await _userWarhouseService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteUserWarhouse(int Id, CancellationToken cancellationToken)
        {
            var result = await _userWarhouseService.DeleteUserWarhouseAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<UserWarhouseDTO>> UpdateUserWarhouse(int Id, UserWarhouseDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _userWarhouseService.UpdateUserWarhouseAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<List<UserWarhouseDTO>>> GetByWarehouseId(int id,CancellationToken cancellationToken)
        {
            var result = await _userWarhouseService.GetByWarehouseId(id,cancellationToken);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ApiResult<List<UserWarhouseDTO>>> GetByUserId(int id, CancellationToken cancellationToken)
        {
            var result = await _userWarhouseService.GetByUserId(id, cancellationToken);
            return result;
        }
        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<UserWarhouseDTO>>> Get(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _userWarhouseService.GetAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

