﻿using AutoMapper;
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
    public class UserWarhouseService : IUserWarhouseService
    {
        #region Fields
        private readonly IRepository<UserWarhouse> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IUserWarehouseRepository _warehouseRepository;
        #endregion 

        #region CTOR
        public UserWarhouseService(IRepository<UserWarhouse> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IUserWarehouseRepository warehouseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<UserWarhouseDTO> Create(UserWarhouseDTO modelDto, CancellationToken cancellationToken)
        {
            UserWarhouse warehouse = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                WareouseId = modelDto.WareouseId,
                UserId = modelDto.UserId,
               
                IsActive = true,
                ModifiedBy = modelDto.ModifiedBy,
                ModifiedDate = modelDto.ModifiedDate,
            };
            await _repository.AddAsync(warehouse, cancellationToken);
            return _mapper.Map<UserWarhouseDTO>(warehouse);
        }

        public async Task<bool> DeleteAsync(int warehouseId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(warehouseId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            model.IsActive = false;
            _repository.UpdateAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<UserWarhouseDTO>> GetByWarehouseId(int id,CancellationToken cancellationToken)
        {
            var model =await _warehouseRepository.GetByWarehouseId(id, cancellationToken);
            return _mapper.Map<List<UserWarhouseDTO>>(model);
        }

        public async Task<PagedResult<UserWarhouseDTO>> GetAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<UserWarhouseDTO>>(model);
        }

        public async Task<UserWarhouseDTO> UpdateUserWarhouseAsync(int warehouseId, UserWarhouseDTO modelDto, CancellationToken cancellationToken)
        {
            UserWarhouse warehouse = new()
            {
                Id = warehouseId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                WareouseId = modelDto.WareouseId,
                UserId = modelDto.UserId,
                IsActive = modelDto.IsActive,
                ModifiedBy = modelDto.ModifiedBy,
                ModifiedDate = DateTime.Now,
            };

            await _repository.UpdateAsync(warehouse, cancellationToken);
            return _mapper.Map<UserWarhouseDTO>(warehouse);
        }

        public async  Task<List<UserWarhouseDTO>> GetByUserId(int id, CancellationToken cancellationToken)
        {
            var model = await _warehouseRepository.GetByUserId(id, cancellationToken);
            return _mapper.Map<List<UserWarhouseDTO>>(model);
        }


        public async Task<List<UserWarhouseDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<UserWarhouseDTO>>(model);
        }

        public Task<PagedResult<UserWarhouse>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }


        #endregion

    }
}
