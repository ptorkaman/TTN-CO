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
    public class SenderService : ISenderService
    {
        #region Fields
        private readonly IRepository<Sender> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        #endregion 

        #region CTOR
        public SenderService(IRepository<Sender> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<SenderDTO> Create(SenderDTO modelDto, CancellationToken cancellationToken)
        {
            Sender city = new()
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
            return _mapper.Map<SenderDTO>(city);
        }

        public async Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<SenderDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<SenderDTO>>(model);
        }

        public Task<PagedResult<Sender>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }


        public async Task<SenderDTO> UpdateAsync(int cityId, SenderDTO modelDto, CancellationToken cancellationToken)
        {
            Sender city = new()
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
            return _mapper.Map<SenderDTO>(city);
        }
        #endregion

    }
}
