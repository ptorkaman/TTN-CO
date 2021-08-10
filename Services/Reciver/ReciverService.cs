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
    public class ReciverService : IReciverService
    {
        #region Fields
        private readonly IRepository<Reciver> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IReciverRepository _cityRepository;
        #endregion 

        #region CTOR
        public ReciverService(IRepository<Reciver> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IReciverRepository cityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _cityRepository = cityRepository;
        }

        public async Task<ReciverDTO> Create(ReciverDTO modelDto, CancellationToken cancellationToken)
        {
            Reciver city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                Address = modelDto.Address,
                CityId = modelDto.CityId,
                CompanyCode = modelDto.CompanyCode,
                CompanyName = modelDto.CompanyName,
                Mobile = modelDto.Mobile,
                Phone = modelDto.Phone,
                ModifiedBy = modelDto.ModifiedBy,
                ModifiedDate = modelDto.ModifiedDate,
                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<ReciverDTO>(city);
        }

        public async Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<ReciverDTO>> GetAsync(int id,CancellationToken cancellationToken)
        {
            var model =await _cityRepository.GetByCityId(id, cancellationToken);
            return _mapper.Map<List<ReciverDTO>>(model);
        }

        public async Task<PagedResult<ReciverDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<ReciverDTO>>(model);
        }

        public async Task<ReciverDTO> UpdateAsync(int cityId, ReciverDTO modelDto, CancellationToken cancellationToken)
        {
            Reciver city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                Address = modelDto.Address,
                CityId = modelDto.CityId,
                CompanyCode = modelDto.CompanyCode,
                CompanyName = modelDto.CompanyName,
                Mobile = modelDto.Mobile,
                Phone = modelDto.Phone,
                ModifiedBy = modelDto.ModifiedBy,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<ReciverDTO>(city);
        }
        #endregion

    }
}
