using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
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
    public class BijakStatusService : IBijakStatusService
    {
        #region Fields
        private readonly IRepository<Domain.BijakStatus> _cityRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;

        #endregion

        #region CTOR
        public BijakStatusService(IRepository<Domain.BijakStatus> cityRepository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
        }

        public async Task<BijakStatusDTO> Create(BijakStatusDTO modelDto, CancellationToken cancellationToken)
        {

            //var model = _cityRepository.GetById(modelDto.Id) != null;
            //if (!model)
            //    throw new CustomException("خطا در دریافت اطلاعات ");

            Domain.BijakStatus city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                Title = modelDto.Title,
             IsActive=true
            };

            await _cityRepository.AddAsync(city, cancellationToken);
            return _mapper.Map<BijakStatusDTO>(city);

        }

        public async Task<bool> DeleteBijakStatusAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _cityRepository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _cityRepository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<BijakStatusDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _cityRepository.GetAllAsync( cancellationToken);
            return _mapper.Map<List<BijakStatusDTO>>(model);
        }

        public async Task<PagedResult<BijakStatusDTO>> GetAllCitiesAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _cityRepository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<BijakStatusDTO>>(model);
        }

        public async Task<BijakStatusDTO> UpdateBijakStatusAsync(int cityId, BijakStatusDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.BijakStatus city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
                Title = modelDto.Title,
                
                ModifiedDate = DateTime.Now
            };

            await _cityRepository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<BijakStatusDTO>(city);
        }
        #endregion

    }
}
