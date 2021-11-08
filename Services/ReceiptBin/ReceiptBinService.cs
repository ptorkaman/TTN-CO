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
    public class ReceiptBinService : IReceiptBinService
    {
        #region Fields
        private readonly IRepository<ReceiptBin> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IReceiptBinRepository _cityRepository;
        #endregion 

        #region CTOR
        public ReceiptBinService(IRepository<ReceiptBin> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IReceiptBinRepository cityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _cityRepository = cityRepository;
        }

        public async Task<ReceiptBinDTO> Create(ReceiptBinDTO modelDto, CancellationToken cancellationToken)
        {
            ReceiptBin city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                ReceiptId = modelDto.ReceiptId,
                BinId = modelDto.BinId,
 
                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<ReceiptBinDTO>(city);
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

        public async Task<List<ReceiptBinDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model =await _cityRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<ReceiptBinDTO>>(model);
        }

        public  Task<PagedResult<ReceiptBin>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<ReceiptBinDTO> UpdateAsync(int cityId, ReceiptBinDTO modelDto, CancellationToken cancellationToken)
        {
            ReceiptBin city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                ReceiptId = modelDto.ReceiptId,
                BinId = modelDto.BinId,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<ReceiptBinDTO>(city);
        }

        public Task<PagedResult<ReceiptBin>> FindAll(int pageSize, int pageIndex, Criteria criteria)
        {
            CancellationToken cancellationToken = new CancellationToken();
            var model= _repository.GetPagedAsync(pageIndex,pageSize, cancellationToken);
            return model;
        }


        #endregion

    }
}
