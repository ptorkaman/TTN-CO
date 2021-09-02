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
    public class VehicleManagerController : BaseController
    {
        #region Fields
        private readonly IVehicleManagerService _vehicleManagerService;
        #endregion

        #region CTOR

        public VehicleManagerController(IVehicleManagerService vehicleManagerService)
        {
            _vehicleManagerService = vehicleManagerService;
        }
        #endregion

        #region VehicleManager Actions
        [HttpPost()]
        public async Task<ApiResult<VehicleManagerDTO>> Create(VehicleManagerDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _vehicleManagerService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _vehicleManagerService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<VehicleManagerDTO>> Update(int Id, VehicleManagerDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _vehicleManagerService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet("Get")]
        public async Task<ApiResult<List<VehicleManagerDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _vehicleManagerService.GetAsync(cancellationToken);
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<VehicleManager>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _vehicleManagerService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }
        #endregion
    }
}

