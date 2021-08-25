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
    public class StuffManagerService : IStuffManagerService
    {
        #region Fields
        private readonly IRepository<StuffManager> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public StuffManagerService(IRepository<StuffManager> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<StuffManagerDTO> Create(StuffManagerDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                StuffManager county = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    Name = modelDto.Name,
                    Height = modelDto.Height,
                    Length = modelDto.Length,
                    Weight = modelDto.Weight,
                    Width = modelDto.Width,
                    IsActive = true

                };

                await _repository.AddAsync(county, cancellationToken);
                return _mapper.Map<StuffManagerDTO>(county);
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
            _repository.UpdateAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<StuffManagerDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<StuffManagerDTO>>(model.Result);
        }

        public Task<PagedResult<StuffManager>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return  model;
        }

        public async Task<StuffManagerDTO> UpdateAsync(int countyId, StuffManagerDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.StuffManager county = new()
            {
                Id = countyId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                Height = modelDto.Height,
                Length = modelDto.Length,
                Weight = modelDto.Weight,
                Width = modelDto.Width,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(county, cancellationToken);
            return _mapper.Map<StuffManagerDTO>(county);
        }
        #endregion

    }
}
