﻿using Common.Extensions;
using Common.Utilities;
using DTO;
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
 
    public class PackageTypeController : BaseController
    {
        #region Fields
        private readonly IPackageTypeService _cityService;
        #endregion

        #region CTOR

        public PackageTypeController(IPackageTypeService cityService)
        {
            _cityService = cityService;
        }
        #endregion

        #region PackageType Actions
        [HttpPost()]
        public async Task<ApiResult<PackageTypeDTO>> Create(PackageTypeDTO modelDto, CancellationToken cancellationToken)
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
        public async Task<ApiResult<PackageTypeDTO>> Update(int Id, PackageTypeDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

        //[HttpGet("{id}")]
        //public async Task<ApiResult<List<PackageTypeDTO>>> Get(int id,CancellationToken cancellationToken)
        //{
        //    var result = await _cityService.GetAsync(id,cancellationToken);
        //    return result;
        //}

        [HttpGet("{page}/{pageSize}")]
        public async Task<ApiResult<PagedResult<PackageTypeDTO>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }


        #endregion
    }
}

