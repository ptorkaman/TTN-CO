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
    public class ParishService : IParishService
    {
        #region Fields
        private readonly IRepository<Parish> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IParishRepository _parishRepository;
        #endregion

        #region CTOR
        public ParishService(IRepository<Domain.Parish> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IParishRepository parishRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _parishRepository = parishRepository;
        }

        public async Task<ParishDTO> Create(ParishDTO modelDto, CancellationToken cancellationToken)
        {
            Parish city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                ParishName = modelDto.ParishName,
                RegionId = modelDto.RegionId,
                IsActive = true
            };

            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<ParishDTO>(city);

        }

        public async Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<ParishDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<ParishDTO>>(model);
        }

        public Task<PagedResult<Parish>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<ParishDTO> UpdateAsync(int cityId, ParishDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Parish city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                ParishName = modelDto.ParishName,
                RegionId = modelDto.RegionId,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<ParishDTO>(city);
        }
        #endregion

    }
}
