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
    public class RegionService : IRegionService
    {
        #region Fields
        private readonly IRepository<Region> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IRegionRepository _regionRepository;
        #endregion

        #region CTOR
        public RegionService(IRepository<Region> cityRepository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IRegionRepository regionRepository)
        {
            _repository = cityRepository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _regionRepository = regionRepository;
        }

        public async Task<RegionDTO> Create(RegionDTO modelDto, CancellationToken cancellationToken)
        {
            Region city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                CityId = modelDto.CityId,
               IsActive=true
            };

            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<RegionDTO>(city);

        }

        public async Task<bool> DeleteRegionAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<RegionDTO>> GetByCityId(int id,CancellationToken cancellationToken)
        {
            var model = _regionRepository.GetByCityId(id, cancellationToken);
            return _mapper.Map<List<RegionDTO>>(model.Result);
        }

        public async Task<PagedResult<RegionDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<RegionDTO>>(model);
        }

        public async Task<RegionDTO> UpdateRegionAsync(int cityId, RegionDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Region city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                CityId = modelDto.CityId,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<RegionDTO>(city);
        }
        #endregion

    }
}
