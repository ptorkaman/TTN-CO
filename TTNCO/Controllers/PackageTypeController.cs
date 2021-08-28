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
    public class PackageTypeController : BaseController
    {
        #region Fields
        private readonly IPackageTypeService _packageTypeService;
        #endregion

        #region CTOR

        public PackageTypeController(IPackageTypeService packageTypeService)
        {
            _packageTypeService = packageTypeService;
        }
        #endregion

        #region PackageType Actions
        [HttpPost()]
        public async Task<ApiResult<PackageTypeDTO>> Create(PackageTypeDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _packageTypeService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _packageTypeService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<PackageTypeDTO>> Update(int Id, PackageTypeDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _packageTypeService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("Get")]
        public async Task<ApiResult<List<PackageType>>> Get(CancellationToken cancellationToken)
        {
            var result = await _packageTypeService.GetAllAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<PackageType>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _packageTypeService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

