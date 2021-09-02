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
    public class SenderReciverAddressService : ISenderReciverAddressService
    {
        #region Fields
        private readonly IRepository<SenderReciverAddress> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        #endregion 

        #region CTOR
        public SenderReciverAddressService(IRepository<SenderReciverAddress> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
       
        }

        public async Task<SenderReciverAddressDTO> Create(SenderReciverAddressDTO modelDto, CancellationToken cancellationToken)
        {
            SenderReciverAddress city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Address = modelDto.Address,
                SenderReciverId = modelDto.SenderReciverId,
                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<SenderReciverAddressDTO>(city);
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

        public async Task<List<SenderReciverAddressDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model =await _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<SenderReciverAddressDTO>>(model);
        }

        public  Task<PagedResult<SenderReciverAddress>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<SenderReciverAddressDTO> UpdateAsync(int cityId, SenderReciverAddressDTO modelDto, CancellationToken cancellationToken)
        {
            SenderReciverAddress city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Address = modelDto.Address,
                SenderReciverId = modelDto.SenderReciverId,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<SenderReciverAddressDTO>(city);
        }
        #endregion

    }
}
