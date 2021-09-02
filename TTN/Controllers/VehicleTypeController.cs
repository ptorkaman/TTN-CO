using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using albim.Result;
using Domain;
using Microsoft.AspNetCore.Authorization;
using TTN.Controllers.v1;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Authorize]
    public class VehicleTypeController : BaseController
    {
        #region Fields
        private readonly IVehicleTypeService _vehicleTypeService;
        #endregion

        #region CTOR

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }
        #endregion

        #region VehicleType Actions
        [HttpPost()]
        public async Task<ApiResult<VehicleTypeDTO>> Create(VehicleTypeDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _vehicleTypeService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _vehicleTypeService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<VehicleTypeDTO>> Update(int Id, VehicleTypeDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _vehicleTypeService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet("Get")]
        public async Task<ApiResult<List<VehicleTypeDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _vehicleTypeService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<VehicleType>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _vehicleTypeService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }
        #endregion
    }
}

