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
    public class ReceiptStatusService : IReceiptStatusService
    {
        #region Fields
        private readonly IRepository<ReceiptStatus> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public ReceiptStatusService(IRepository<ReceiptStatus> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
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

            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<ReceiptStatusDTO>(city);

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

        public async Task<List<ReceiptStatusDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<ReceiptStatusDTO>>(model);
        }

        public Task<PagedResult<ReceiptStatus>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
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

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<ReceiptStatusDTO>(city);
        }
        #endregion

    }
}
