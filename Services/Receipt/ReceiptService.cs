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
using System.Transactions;
using Models.Settings;

namespace Services
{
    public class ReceiptService : IReceiptService
    {
        #region Fields
        private readonly IRepository<Receipt> _repository;
        private readonly IReceiptDetailRepository _repositoryDetailRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IReceiptRepository _receiptRepository;
        #endregion 

        #region CTOR
        public ReceiptService(IRepository<Receipt> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IReceiptRepository receiptRepository, IReceiptDetailRepository repositoryDetailRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _receiptRepository = receiptRepository;
            _repositoryDetailRepository = repositoryDetailRepository;
        }

        public async Task<ReceiptDTO> Create(ReceiptDTO modelDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(
                TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Receipt model = new()
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
                    await _repository.AddAsync(model, cancellationToken);

                    foreach (var item in modelDto.ReceiptDetail)
                    {

                        ReceiptDetail modelDetail = new ReceiptDetail()
                        {
                            CreatedBy = model.CreatedBy,
                            CreatedDate = DateTime.Now,
                            GoodsId = model.CreatedBy,
                            GoodsName = item.GoodsName,
                            Count = item.Qty,
                            ReceiptId = model.Id,
                            UsnitId = item.UsnitId,
                            weight = item.weight
                        };
                        await _repositoryDetailRepository.AddAsync(modelDetail, cancellationToken);
                        model.ReceiptDetail.Add(modelDetail);
                    }
                    scope.Complete();
                    return _mapper.Map<ReceiptDTO>(model);
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return null;
                }
            }
        }

        public async Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(Id);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            model.IsActive = false;
            _repository.UpdateAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<ReceiptDTO>> GetAsync(CancellationToken cancellationToken)
        {
            var model = await _repository.GetAllAsync(cancellationToken);
            foreach (var item in model)
            {
                item.ReceiptDetail = await _repositoryDetailRepository.GetByReceiptId(item.Id,cancellationToken);
            }
            return _mapper.Map<List<ReceiptDTO>>(model);
        }

        public Task<PagedResult<Receipt>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return model;
        }

        public async Task<ReceiptDTO> UpdateAsync(int Id, ReceiptDTO modelDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(
                TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Receipt model = new()
                    {
                        Id = Id,
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
                        IsActive = modelDto.IsActive,
                        ModifiedBy = modelDto.ModifiedBy,
                        ModifiedDate = DateTime.Now

                    };

                    await _repository.UpdateAsync(model, cancellationToken);
                    foreach (var item in modelDto.ReceiptDetail)
                    {

                        ReceiptDetail modelDetail = new ReceiptDetail()
                        {
                            Id = item.Id,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = item.CreatedDate.Value,
                            GoodsId = model.CreatedBy,
                            GoodsName = item.GoodsName,
                            Count = item.Qty,
                            ReceiptId = model.Id,
                            UsnitId = item.UsnitId,
                            weight = item.weight,
                            ModifiedBy = item.ModifiedBy,
                            ModifiedDate = DateTime.Now
                        };
                        await _repositoryDetailRepository.UpdateAsync(modelDetail, cancellationToken);
                        model.ReceiptDetail.Add(modelDetail);
                    }
                    scope.Complete();
                    return _mapper.Map<ReceiptDTO>(model);
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return null;
                }
            }
        }
        #endregion

    }
}
