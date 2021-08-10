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
    public class ReceiptStatusService : IReceiptStatusService
    {
        #region Fields
        private readonly IRepository<ReceiptStatus> _cityRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public ReceiptStatusService(IRepository<ReceiptStatus> cityRepository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<ReceiptStatusDTO> Create(ReceiptStatusDTO modelDto, CancellationToken cancellationToken)
        {
            ReceiptStatus city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Title = modelDto.Title,
             IsActive=true
            };

            await _cityRepository.AddAsync(city, cancellationToken);
            return _mapper.Map<ReceiptStatusDTO>(city);

        }

        public async Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _cityRepository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _cityRepository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<ReceiptStatusDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _cityRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<ReceiptStatusDTO>>(model.Result);
        }

        public async Task<PagedResult<ReceiptStatusDTO>> GetAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _cityRepository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<ReceiptStatusDTO>>(model);
        }

        public async Task<ReceiptStatusDTO> UpdateAsync(int cityId, ReceiptStatusDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.ReceiptStatus city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Title = modelDto.Title,
                
                ModifiedDate = DateTime.Now
            };

            await _cityRepository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<ReceiptStatusDTO>(city);
        }
        #endregion

    }
}
