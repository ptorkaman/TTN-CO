using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
using Domain;
using DTO;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models.Settings;

namespace Services
{
    public class WarehouseService : IWarehouseService
    {
        #region Fields
        private readonly IRepository<Warehouse> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IWarehouseRepository _warehouseRepository;
        #endregion 

        #region CTOR
        public WarehouseService(IRepository<Warehouse> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IWarehouseRepository warehouseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<WarehouseDTO> Create(WarehouseDTO modelDto, CancellationToken cancellationToken)
        {
            Warehouse city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                CityId = modelDto.CityId,
                Latitude = modelDto.Latitude,
                Longitude = modelDto.Longitude,
                Address = modelDto.Address,
                ContactMobile1 = modelDto.ContactMobile1,
                ContactMobile2 = modelDto.ContactMobile2,
                ContactPerson = modelDto.ContactPerson,
                Phone = modelDto.Phone,
                WarehouseCode = modelDto.WarehouseCode,
                Title = modelDto.Title,
                IsActive = true,
                ModifiedBy = modelDto.ModifiedBy,
                ModifiedDate = modelDto.ModifiedDate,
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<WarehouseDTO>(city);
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

        public async Task<List<WarehouseDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _warehouseRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<WarehouseDTO>>(model);
        }

        public Task<PagedResult<Warehouse>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<WarehouseDTO> UpdateAsync(int cityId, WarehouseDTO modelDto, CancellationToken cancellationToken)
        {
            Warehouse city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                CityId = modelDto.CityId,
                Latitude = modelDto.Latitude,
                Longitude = modelDto.Longitude,
                Address = modelDto.Address,
                ContactMobile1 = modelDto.ContactMobile1,
                ContactMobile2 = modelDto.ContactMobile2,
                ContactPerson = modelDto.ContactPerson,
                Phone = modelDto.Phone,
                WarehouseCode = modelDto.WarehouseCode,
                Title = modelDto.Title,
                IsActive = modelDto.IsActive,
                ModifiedBy = modelDto.ModifiedBy,
                ModifiedDate = DateTime.Now,
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<WarehouseDTO>(city);
        }
        #endregion

    }
}
