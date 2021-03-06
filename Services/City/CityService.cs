using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
using Domain;
using DTO;
using Microsoft.Extensions.Options;
using Models.Settings;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TTN;

namespace Services
{
    public class CityService : ICityService
    {
        #region Fields
        private readonly IRepository<City> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly ICityRepository _cityRepository;
        #endregion 

        #region CTOR
        public CityService(IRepository<City> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, ICityRepository cityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _cityRepository = cityRepository;
        }

        public async Task<CityDTO> Create(CityDTO modelDto, CancellationToken cancellationToken)
        {
            City city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                Latitude = modelDto.Latitude,
                Longitude = modelDto.Longitude,
                ProvinceId = modelDto.ProvinceId,
                //WarhouseId = modelDto.WarhouseId,
                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<CityDTO>(city);
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

        public async Task<List<CityDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model =await _cityRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<CityDTO>>(model);
        }

        public  Task<PagedResult<City>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<CityDTO> UpdateAsync(int cityId, CityDTO modelDto, CancellationToken cancellationToken)
        {
            City city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                Latitude = modelDto.Latitude,
                Longitude = modelDto.Longitude,
                ProvinceId = modelDto.ProvinceId,
                //WarhouseId = modelDto.WarhouseId,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<CityDTO>(city);
        }

        public Task<PagedResult<City>> FindAll(int pageSize, int pageIndex, Criteria criteria)
        {
            CancellationToken cancellationToken = new CancellationToken();
            var model= _repository.GetPagedAsync(pageIndex,pageSize, cancellationToken);
            return model;
        }


        #endregion

    }
}
