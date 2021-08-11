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
using Common.Extensions;
using ClassType = Domain.ClassType;

namespace Services
{
    public class SenderReciverService : ISenderReciverService
    {
        #region Fields
        private readonly IRepository<SenderReciver> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IReciverRepository _senderReciverRepository;
        #endregion 

        #region CTOR
        public SenderReciverService(IRepository<SenderReciver> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IReciverRepository senderReciverRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _senderReciverRepository = senderReciverRepository;
        }

        public async Task<SenderReciverDTO> Create(SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            SenderReciver model = new()
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
                Type = (ClassType) modelDto.Type,
                IsActive = true
            };
        
            await _repository.AddAsync(model, cancellationToken);
            return _mapper.Map<SenderReciverDTO>(model);
        }

        public async Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(Id);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<SenderReciverDTO>> GetAsync(int id,CancellationToken cancellationToken)
        {
            var model =await _senderReciverRepository.GetByCityId(id, cancellationToken);
            return _mapper.Map<List<SenderReciverDTO>>(model);
        }

        public async Task<PagedResult<SenderReciverDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<SenderReciverDTO>>(model);
        }

        public async Task<SenderReciverDTO> UpdateAsync(int Id, SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            SenderReciver model = new()
            {
                Id = Id,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
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

            await _repository.UpdateAsync(model, cancellationToken);
            return _mapper.Map<SenderReciverDTO>(model);
        }
        #endregion

    }
}
