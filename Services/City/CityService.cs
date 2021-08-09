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

        public async Task<bool> DeleteCityAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<CityDTO>> GetAllAsync(int id,CancellationToken cancellationToken)
        {
            var model =await _cityRepository.GetByCityId(id, cancellationToken);
            return _mapper.Map<List<CityDTO>>(model);
        }

        public async Task<PagedResult<CityDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<CityDTO>>(model);
        }

        public async Task<CityDTO> UpdateCityAsync(int cityId, CityDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.City city = new()
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
        #endregion

    }
}
