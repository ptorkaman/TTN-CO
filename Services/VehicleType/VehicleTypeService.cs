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
    public class VehicleTypeService : IVehicleTypeService
    {
        #region Fields
        private readonly IRepository<VehicleType> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        #endregion 

        #region CTOR
        public VehicleTypeService(IRepository<VehicleType> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<VehicleTypeDTO> Create(VehicleTypeDTO modelDto, CancellationToken cancellationToken)
        {
            VehicleType city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Title = modelDto.Title,
               
                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<VehicleTypeDTO>(city);
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

        public async Task<List<VehicleTypeDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model =await _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<VehicleTypeDTO>>(model);
        }

        public  Task<PagedResult<VehicleType>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<VehicleTypeDTO> UpdateAsync(int cityId, VehicleTypeDTO modelDto, CancellationToken cancellationToken)
        {
            VehicleType city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Title = modelDto.Title,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<VehicleTypeDTO>(city);
        }
        #endregion

    }
}
