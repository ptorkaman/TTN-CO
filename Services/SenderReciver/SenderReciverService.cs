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
    public class SenderReciverService : ISenderReciverService
    {
        #region Fields
        private readonly IRepository<SenderReciver> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        #endregion 

        #region CTOR
        public SenderReciverService(IRepository<SenderReciver> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
       
        }

        public async Task<SenderReciverDTO> Create(SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            SenderReciver city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Name = modelDto.Name,
                Type =(Domain.ClassType) modelDto.Type,
                Address = modelDto.Address,
                CityId = modelDto.CityId,
                CompanyCode = modelDto.CompanyCode,
                CompanyName = modelDto.CompanyName,
                Mobile = modelDto.Mobile,
                Phone = modelDto.Phone,

                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<SenderReciverDTO>(city);
        }

        public async Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<SenderReciverDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model =await _repository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<SenderReciverDTO>>(model);
        }

        public  Task<PagedResult<SenderReciver>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<SenderReciverDTO> UpdateAsync(int cityId, SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            SenderReciver city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Name = modelDto.Name,
                IsActive = modelDto.IsActive,
                Type = (Domain.ClassType)modelDto.Type,
                Address = modelDto.Address,
                CityId = modelDto.CityId,
                CompanyCode = modelDto.CompanyCode,
                CompanyName = modelDto.CompanyName,
                Mobile = modelDto.Mobile,
                Phone = modelDto.Phone,
                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<SenderReciverDTO>(city);
        }
        #endregion

    }
}
