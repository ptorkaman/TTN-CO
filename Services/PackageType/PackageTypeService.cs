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
    public class PackageTypeService : IPackageTypeService
    {
        #region Fields
        private readonly IRepository<PackageType> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IPackageTypeRepository _cityRepository;
        #endregion 

        #region CTOR
        public PackageTypeService(IRepository<PackageType> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IPackageTypeRepository cityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _cityRepository = cityRepository;
        }

        public async Task<PackageTypeDTO> Create(PackageTypeDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                PackageType city = new()
                {
                    CreatedBy = modelDto.CreatedBy.Value,
                    CreatedDate = DateTime.Now,
                    Title = modelDto.Title,

                    IsActive = true
                };
                await _repository.AddAsync(city, cancellationToken);
                return _mapper.Map<PackageTypeDTO>(city);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public async Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(Id);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

       

        public  Task<PagedResult<PackageType>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<PackageTypeDTO> UpdateAsync(int cityId, PackageTypeDTO modelDto, CancellationToken cancellationToken)
        {

            PackageType model = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Title = modelDto.Title,

                ModifiedDate = DateTime.Now
            };

            await _repository.UpdateAsync(model, cancellationToken);
            return _mapper.Map<PackageTypeDTO>(model);
        }


        public async Task<List<PackageType>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _repository.GetAllAsync(cancellationToken);
            return model.Result;
        }

        #endregion

    }
}
