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
    public class SenderReciverService : ISenderReciverService
    {
        #region Fields
        private readonly IRepository<SenderReciver> _repository;
        private readonly IRepository<SenderReciverAddress> _repositoryAddress;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly ISenderReciverAddressRepository _senderReciverAddressRepository;
        #endregion 

        #region CTOR
        public SenderReciverService(IRepository<SenderReciver> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IRepository<SenderReciverAddress> repositoryAddress, ISenderReciverAddressRepository senderReciverAddressRepository)
        {
            _repository = repository;
            _repositoryAddress = repositoryAddress;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _senderReciverAddressRepository = senderReciverAddressRepository;
        }

        public async Task<SenderReciverDTO> Create(SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                SenderReciver model = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    Name = modelDto.Name,
                    Type = (Domain.ClassType)modelDto.Type,
                    Address = modelDto.Address,
                    CityId = modelDto.CityId,
                    CompanyCode = modelDto.CompanyCode,
                    CompanyName = modelDto.CompanyName,
                    Mobile = modelDto.Mobile,
                    Phone = modelDto.Phone,

                    IsActive = true
                };
                await _repository.AddAsync(model, cancellationToken);
                foreach (var item in modelDto.SenderReciverAddress)
                {
                    SenderReciverAddress address = new SenderReciverAddress()
                    {
                        IsActive = item.IsActive,
                        CreatedDate = model.CreatedDate,
                        CreatedBy = model.CreatedBy,
                        Address = item.Address,
                        SenderReciverId = model.Id
                    };
                    await _repositoryAddress.AddAsync(address, cancellationToken);
                }

                return _mapper.Map<SenderReciverDTO>(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

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

        public async Task<List<SenderReciverDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            foreach (var item in model)
            {
                var data = _senderReciverAddressRepository.GetBySenderReciverId(item.Id, cancellationToken);
                item.SenderReciverAddress.Add(data.Result);
            }
            return _mapper.Map<List<SenderReciverDTO>>(model);
        }

        public Task<PagedResult<SenderReciver>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);

            return model;

        }

        public async Task<SenderReciverDTO> UpdateAsync(int cityId, SenderReciverDTO modelDto, CancellationToken cancellationToken)
        {
            SenderReciver model = new()
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
                ModifiedDate = DateTime.Now,
                ModifiedBy = modelDto.ModifiedBy
            };

            await _repository.UpdateAsync(model, cancellationToken);
            foreach (var item in modelDto.SenderReciverAddress)
            {
                SenderReciverAddress address = new SenderReciverAddress()
                {
                    Id = item.Id,
                    IsActive = item.IsActive,
                    CreatedDate = model.CreatedDate,
                    CreatedBy = model.CreatedBy,
                    Address = item.Address,
                    SenderReciverId = model.Id,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = model.ModifiedBy
                };
                await _repositoryAddress.UpdateAsync(address, cancellationToken);
            }
            return _mapper.Map<SenderReciverDTO>(model);
        }
        #endregion

    }
}
