using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
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
    public class ProvinceService : IProvinceService
    {
        #region Fields
        private readonly IRepository<Domain.Province> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IProvinceRepository _provinceRepository;
        #endregion

        #region CTOR
        public ProvinceService(IRepository<Domain.Province> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IProvinceRepository provinceRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _provinceRepository = provinceRepository;
        }

        public async Task<ProvinceDTO> Create(ProvinceDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Province province = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                ProvinceName = modelDto.ProvinceName,
                CountryId = modelDto.CountryId,
                IsActive = true
            };

            await _repository.AddAsync(province, cancellationToken);
            return _mapper.Map<ProvinceDTO>(province);

        }

        public async Task<bool> DeleteProvinceAsync(int provinceId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(provinceId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<ProvinceDTO>> GetAllAsync(int id,CancellationToken cancellationToken)
        {
            var model = _provinceRepository.GetByCountryId( id,cancellationToken);
            return _mapper.Map<List<ProvinceDTO>>(model.Result);
        }

        public async Task<PagedResult<ProvinceDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<ProvinceDTO>>(model);
        }

        public async Task<ProvinceDTO> UpdateProvinceAsync(int provinceId, ProvinceDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Province province = new()
            {
                Id = provinceId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                ProvinceName = modelDto.ProvinceName,
                CountryId = modelDto.CountryId,
                ModifiedDate = DateTime.Now,
                IsActive = modelDto.IsActive
            };

            await _repository.UpdateAsync(province, cancellationToken);
            return _mapper.Map<ProvinceDTO>(province);
        }
        #endregion

    }
}
