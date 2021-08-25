using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
using Domain;
using DTO;
using DTO.Settings;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class VehicleManagerService : IVehicleManagerService
    {
        #region Fields
        private readonly IRepository<VehicleManager> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        #endregion 

        #region CTOR
        public VehicleManagerService(IRepository<VehicleManager> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<VehicleManagerDTO> Create(VehicleManagerDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                VehicleManager city = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    Name = modelDto.Name,
                    Family = modelDto.Family,
                    Mobile = modelDto.Mobile,
                    Phone = modelDto.Phone,
                    VehicleNumber = modelDto.VehicleNumber,
                    NationalCode = modelDto.NationalCode,
                    VehicleTypeId = modelDto.VehicleTypeId,
                    IsActive = true
                };
                await _repository.AddAsync(city, cancellationToken);
                return _mapper.Map<VehicleManagerDTO>(city);
            }
            catch (Exception e)
            {
                return null;
            }
           
        }

        public async Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            model.IsActive = false;
            _repository.UpdateAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<VehicleManagerDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model =await _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<VehicleManagerDTO>>(model);
        }

        public  Task<PagedResult<VehicleManager>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<VehicleManagerDTO> UpdateAsync(int cityId, VehicleManagerDTO modelDto, CancellationToken cancellationToken)
        {
            VehicleManager city = new()
            {
                Id = cityId,
                
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                Family = modelDto.Family,
                Mobile = modelDto.Mobile,
                Phone = modelDto.Phone,
                VehicleNumber = modelDto.VehicleNumber,
                NationalCode = modelDto.NationalCode,
                VehicleTypeId = modelDto.VehicleTypeId,
                IsActive = modelDto.IsActive,
                ModifiedBy = modelDto.ModifiedBy,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<VehicleManagerDTO>(city);
        }
        #endregion

    }
}
