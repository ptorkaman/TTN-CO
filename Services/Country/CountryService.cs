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
    public class CountryService : ICountryService
    {
        #region Fields
        private readonly IRepository<Country> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public CountryService(IRepository<Country> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<CountryDTO> Create(CountryDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                Country county = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    Name = modelDto.Name,
                    EnglishName = modelDto.EnglishName,
                    IsActive = true

                };

                await _repository.AddAsync(county, cancellationToken);
                return _mapper.Map<CountryDTO>(county);
            }
            catch (Exception ex)
            {
                return null;
                //throw;
            }
            

        }

        public async Task<bool> DeleteAsync(int countyId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(countyId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            model.IsActive = false;
            _repository.UpdateAsync(model, cancellationToken); return true;
        }

        public async Task<List<CountryDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<CountryDTO>>(model.Result);
        }

        public Task<PagedResult<Country>> GetAllCountryAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return  model;
        }

        public async Task<CountryDTO> UpdateAsync(int countyId, CountryDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Country county = new()
            {
                Id = countyId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                EnglishName = modelDto.EnglishName,
                
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(county, cancellationToken);
            return _mapper.Map<CountryDTO>(county);
        }
        #endregion

    }
}
