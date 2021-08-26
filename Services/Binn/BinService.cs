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
    public class BinService : IBinService
    {
        #region Fields
        private readonly IRepository<Bin> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IBinRepository _cityRepository;
        #endregion 

        #region CTOR
        public BinService(IRepository<Bin> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IBinRepository cityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _cityRepository = cityRepository;
        }

        public async Task<BinDTO> Create(BinDTO modelDto, CancellationToken cancellationToken)
        {
            Bin city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                WarehoseId = modelDto.WarehoseId,

                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<BinDTO>(city);
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

        public async Task<List<BinDTO>> GetAsync( )
        {
            CancellationToken cancellationToken = new CancellationToken();
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<BinDTO>>(model);
        }

        public Task<PagedResult<Bin>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<BinDTO> UpdateAsync(int Id, BinDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Bin model = new()
            {
                Id = Id,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                IsActive = modelDto.IsActive,
                ModifiedBy = modelDto.ModifiedBy,
                Name = modelDto.Name,
                WarehoseId = modelDto.WarehoseId,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(model, cancellationToken);
            return _mapper.Map<BinDTO>(model);
        }
        #endregion

    }
}
