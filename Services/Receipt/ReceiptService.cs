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
    public class ReceiptService : IReceiptService
    {
        #region Fields
        private readonly IRepository<Receipt> _repository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IReceiptRepository _cityRepository;
        #endregion 

        #region CTOR
        public ReceiptService(IRepository<Receipt> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IReceiptRepository cityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _cityRepository = cityRepository;
        }

        public async Task<ReceiptDTO> Create(ReceiptDTO modelDto, CancellationToken cancellationToken)
        {
            Receipt city = new()
            {
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = DateTime.Now,
                CityAmount = modelDto.CityAmount,
                DerricAmount = modelDto.DerricAmount,
                DestinationCity = modelDto.DestinationCity,
                Destinationlatitude = modelDto.DestinationLatitude,
                Destinationlongtude = modelDto.DestinationLongtude,
                DestinationWarhouseId = modelDto.DestinationWarhouseId,
                DownloadAmount = modelDto.DownloadAmount,
                ForceType = modelDto.ForceType,
                InstitutionAmount = modelDto.InstitutionAmount,
                InsuranceAmount = modelDto.InsuranceAmount,
                Istransport1 = modelDto.Istransport1,
                Istransport2 = modelDto.Istransport2,
                PassingAmount = modelDto.PassingAmount,
                PerfixAmount = modelDto.PerfixAmount,
                ReceiptNo = modelDto.ReceiptNo,
                Remark = modelDto.Remark,
                ReferenceNo = modelDto.ReferenceNo,
                NeedIncurance = modelDto.NeedIncurance,
                Startlongitude = modelDto.StartLongitude,
                TotalAmount = modelDto.TotalAmount,
                TipAmount = modelDto.TipAmount,
                StatusId = modelDto.StatusId,
                StartwarhouseId = modelDto.StartwarhouseId,
                Startlatitude = modelDto.StartLatitude,
                StartingCity = modelDto.StartingCity,
                SenderId = modelDto.SenderId,
                RecieverId = modelDto.RecieverId,
                FreightAmount = modelDto.FreightAmount,
                IsActive = true
            };
            await _repository.AddAsync(city, cancellationToken);
            return _mapper.Map<ReceiptDTO>(city);
        }

        public async Task<bool> DeleteAsync(int cityId, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(cityId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _repository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<ReceiptDTO>> GetAsync(int id,CancellationToken cancellationToken)
        {
            var model =await _cityRepository.GetByReceiptId(id, cancellationToken);
            return _mapper.Map<List<ReceiptDTO>>(model);
        }

        public async Task<PagedResult<ReceiptDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<ReceiptDTO>>(model);
        }

        public async Task<ReceiptDTO> UpdateAsync(int cityId, ReceiptDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Receipt city = new()
            {
                Id = cityId,
                CreatedBy = modelDto.CreatedBy.Value,
                CreatedDate = modelDto.CreatedDate.Value,
               
                CityAmount = modelDto.CityAmount,
                DerricAmount = modelDto.DerricAmount,
                DestinationCity = modelDto.DestinationCity,
                Destinationlatitude = modelDto.DestinationLatitude,
                Destinationlongtude = modelDto.DestinationLongtude,
                DestinationWarhouseId = modelDto.DestinationWarhouseId,
                DownloadAmount = modelDto.DownloadAmount,
                ForceType = modelDto.ForceType,
                InstitutionAmount = modelDto.InstitutionAmount,
                InsuranceAmount = modelDto.InsuranceAmount,
                Istransport1 = modelDto.Istransport1,
                Istransport2 = modelDto.Istransport2,
                PassingAmount = modelDto.PassingAmount,
                PerfixAmount = modelDto.PerfixAmount,
                ReceiptNo = modelDto.ReceiptNo,
                Remark = modelDto.Remark,
                ReferenceNo = modelDto.ReferenceNo,
                NeedIncurance = modelDto.NeedIncurance,
                Startlongitude = modelDto.StartLongitude,
                TotalAmount = modelDto.TotalAmount,
                TipAmount = modelDto.TipAmount,
                StatusId = modelDto.StatusId,
                StartwarhouseId = modelDto.StartwarhouseId,
                Startlatitude = modelDto.StartLatitude,
                StartingCity = modelDto.StartingCity,
                SenderId = modelDto.SenderId,
                RecieverId = modelDto.RecieverId,
                FreightAmount = modelDto.FreightAmount,
                IsActive=modelDto.IsActive,
                ModifiedBy=modelDto.ModifiedBy,
                ModifiedDate=DateTime.Now

            };

            await _repository.UpdateAsync(city, cancellationToken);
            return _mapper.Map<ReceiptDTO>(city);
        }
        #endregion

    }
}
