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
 
    public class WarehouseController : BaseController
    {
        #region Fields
        private readonly IWarehouseService _warehouseService;
        #endregion

        #region CTOR

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        #endregion

        #region Warehouse Actions
        [HttpPost()]
        public async Task<ApiResult<WarehouseDTO>> Create(WarehouseDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();
            var result = await _warehouseService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> DeleteWarehouse(int Id, CancellationToken cancellationToken)
        {
            var result = await _warehouseService.DeleteWarehouseAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<WarehouseDTO>> UpdateWarehouse(int Id, WarehouseDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _warehouseService.UpdateWarehouseAsync(Id, modelDto, cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<List<WarehouseDTO>>> GetByCityId(int id,CancellationToken cancellationToken)
        {
            var result = await _warehouseService.GetByCityId(id,cancellationToken);
            return result;
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<WarehouseDTO>>> Get(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _warehouseService.GetAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

