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
    public class UnitService : IUnitService
    {
        #region Fields
        private readonly IRepository<Unit> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        #endregion 

        #region CTOR
        public UnitService(IRepository<Unit> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<UnitDTO> Create(UnitDTO modelDto, CancellationToken cancellationToken)
        {
            Unit city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                Dimension = modelDto.Dimension,
         
                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<UnitDTO>(city);
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

        public async Task<List<UnitDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model =await _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<UnitDTO>>(model);
        }

        public  Task<PagedResult<Unit>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<UnitDTO> UpdateAsync(int cityId, UnitDTO modelDto, CancellationToken cancellationToken)
        {
            Unit city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                Dimension = modelDto.Dimension,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<UnitDTO>(city);
        }
        #endregion

    }
}
