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
    public class ReceiptDetailService : IReceiptDetailService
    {
        #region Fields
        private readonly IRepository<ReceiptDetail> _repository;
        private readonly IReceiptDetailRepository _repositoryDetailRepository;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        private readonly IReceiptStatusRepository _receiptStatusRepository;
        #endregion 

        #region CTOR
        public ReceiptDetailService(IRepository<ReceiptDetail> repository, IMapper mapper, IOptionsSnapshot<PagingSettings> pagingSettings, IReceiptDetailRepository repositoryDetailRepository, IReceiptStatusRepository receiptStatusRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pagingSettings = pagingSettings.Value;
            _receiptStatusRepository = receiptStatusRepository;
            _repositoryDetailRepository = repositoryDetailRepository;
        }
        public async Task<ReceiptDetailDTO> UpdateDetail(ReceiptDetailDTO modelDto, CancellationToken cancellationToken)
        {
           var detail=  _repository.GetById(modelDto.Id);
            detail.DownloadDate = modelDto.DownloadDate;
            detail.DownloadBy = modelDto.DownloadBy;
            detail.StatusId = _receiptStatusRepository.GetByCode(9, cancellationToken).Id;
           await _repositoryDetailRepository.UpdateAsync(detail,cancellationToken);
            return _mapper.Map<ReceiptDetailDTO>(detail);

        }

        //public async Task<ReceiptDetailDTO> Create(ReceiptDetailDTO modelDto, CancellationToken cancellationToken)
        //{
        //    using (var scope = new TransactionScope(
        //        TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        try
        //        {
        //            ReceiptDetail model = new()
        //            {
        //                CreatedBy = modelDto.CreatedBy.Value,
        //                CreatedDate = DateTime.Now,
        //                //CityAmount = modelDto.CityAmount,
        //                //DerricAmount = modelDto.DerricAmount,
        //                //DestinationCity = modelDto.DestinationCity,
        //                //Destinationlatitude = modelDto.DestinationLatitude,
        //                //Destinationlongtude = modelDto.DestinationLongtude,
        //                //DestinationWarhouseId = modelDto.DestinationWarhouseId,
        //                //DownloadAmount = modelDto.DownloadAmount,
        //                //ForceType = modelDto.ForceType,
        //                //InstitutionAmount = modelDto.InstitutionAmount,
        //                //InsuranceAmount = modelDto.InsuranceAmount,
        //                //Istransport1 = modelDto.Istransport1,
        //                //Istransport2 = modelDto.Istransport2,
        //                //PassingAmount = modelDto.PassingAmount,
        //                //PerfixAmount = modelDto.PerfixAmount,
        //                //ReceiptNo = modelDto.ReceiptNo,
        //                //Remark = modelDto.Remark,
        //                //ReferenceNo = modelDto.ReferenceNo,
        //                //NeedIncurance = modelDto.NeedIncurance,
        //                //Startlongitude = modelDto.StartLongitude,
        //                //TotalAmount = modelDto.TotalAmount,
        //                //TipAmount = modelDto.TipAmount,
        //                //StatusId = modelDto.StatusId,
        //                //StartwarhouseId = modelDto.StartwarhouseId,
        //                //Startlatitude = modelDto.StartLatitude,
        //                //StartingCity = modelDto.StartingCity,
        //                //SenderId = modelDto.SenderId,
        //                //RecieverId = modelDto.RecieverId,
        //                //FreightAmount = modelDto.FreightAmount,
        //                IsActive = true
        //            };
        //            await _repository.AddAsync(model, cancellationToken);

        //            //foreach (var item in modelDto.ReceiptDetail)
        //            //{

        //            //    ReceiptDetail modelDetail = new ReceiptDetail()
        //            //    {
        //            //        CreatedBy = model.CreatedBy,
        //            //        CreatedDate = DateTime.Now,
        //            //        GoodsId = model.CreatedBy,
        //            //        GoodsName = item.GoodsName,
        //            //        Count = item.Qty,
        //            //        ReceiptId = model.Id,
        //            //        UsnitId = item.UsnitId,
        //            //        weight = item.weight
        //            //    };
        //            //    await _repositoryDetailRepository.AddAsync(modelDetail, cancellationToken);
        //            //    model.ReceiptDetail.Add(modelDetail);
        //            //}
        //            scope.Complete();
        //            return _mapper.Map<ReceiptDetailDTO>(model);
        //        }
        //        catch (Exception e)
        //        {
        //            scope.Dispose();
        //            return null;
        //        }
        //    }
        //}

        //public async Task<bool> DeleteAsync(int Id, CancellationToken cancellationToken)
        //{
        //    var model = _repository.GetById(Id);
        //    if (model == null)
        //        throw new CustomException("خطا در دریافت اطلاعات ");
        //    model.IsActive = false;
        //    _repository.UpdateAsync(model, cancellationToken);
        //    return true;
        //}

        //public async Task<List<ReceiptDetailDTO>> GetAsync(CancellationToken cancellationToken)
        //{
        //    var model = await _repository.GetAllAsync(cancellationToken);
        //    foreach (var item in model)
        //    {
        //        //item.ReceiptDetail = await _repositoryDetailRepository.GetByReceiptId(item.Id,cancellationToken);
        //    }
        //    return _mapper.Map<List<ReceiptDetailDTO>>(model);
        //}

        //public Task<PagedResult<ReceiptDetail>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        //{
        //    int pageNotNull = page ?? _pagingSettings.DefaultPage;
        //    int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
        //    var model = _repository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
        //    return model;
        //}

        //public async Task<ReceiptDetailDTO> UpdateAsync(int Id, ReceiptDetailDTO modelDto, CancellationToken cancellationToken)
        //{
        //    using (var scope = new TransactionScope(
        //        TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        try
        //        {
        //            ReceiptDetail model = new()
        //            {
        //                Id = Id,
        //                CreatedBy = modelDto.CreatedBy.Value,
        //                CreatedDate = modelDto.CreatedDate.Value,
        //                //CityAmount = modelDto.CityAmount,
        //                //DerricAmount = modelDto.DerricAmount,
        //                //DestinationCity = modelDto.DestinationCity,
        //                //Destinationlatitude = modelDto.DestinationLatitude,
        //                //Destinationlongtude = modelDto.DestinationLongtude,
        //                //DestinationWarhouseId = modelDto.DestinationWarhouseId,
        //                //DownloadAmount = modelDto.DownloadAmount,
        //                //ForceType = modelDto.ForceType,
        //                //InstitutionAmount = modelDto.InstitutionAmount,
        //                //InsuranceAmount = modelDto.InsuranceAmount,
        //                //Istransport1 = modelDto.Istransport1,
        //                //Istransport2 = modelDto.Istransport2,
        //                //PassingAmount = modelDto.PassingAmount,
        //                //PerfixAmount = modelDto.PerfixAmount,
        //                //ReceiptNo = modelDto.ReceiptNo,
        //                //Remark = modelDto.Remark,
        //                //ReferenceNo = modelDto.ReferenceNo,
        //                //NeedIncurance = modelDto.NeedIncurance,
        //                //Startlongitude = modelDto.StartLongitude,
        //                //TotalAmount = modelDto.TotalAmount,
        //                //TipAmount = modelDto.TipAmount,
        //                //StatusId = modelDto.StatusId,
        //                //StartwarhouseId = modelDto.StartwarhouseId,
        //                //Startlatitude = modelDto.StartLatitude,
        //                //StartingCity = modelDto.StartingCity,
        //                //SenderId = modelDto.SenderId,
        //                //RecieverId = modelDto.RecieverId,
        //                //FreightAmount = modelDto.FreightAmount,
        //                IsActive = modelDto.IsActive,
        //                ModifiedBy = modelDto.ModifiedBy,
        //                ModifiedDate = DateTime.Now

        //            };

        //            await _repository.UpdateAsync(model, cancellationToken);
        //            //foreach (var item in modelDto.ReceiptDetail)
        //            //{

        //            //    ReceiptDetail modelDetail = new ReceiptDetail()
        //            //    {
        //            //        Id = item.Id,
        //            //        CreatedBy = model.CreatedBy,
        //            //        CreatedDate = item.CreatedDate.Value,
        //            //        GoodsId = model.CreatedBy,
        //            //        GoodsName = item.GoodsName,
        //            //        Count = item.Qty,
        //            //        ReceiptId = model.Id,
        //            //        UsnitId = item.UsnitId,
        //            //        weight = item.weight,
        //            //        ModifiedBy = item.ModifiedBy,
        //            //        ModifiedDate = DateTime.Now
        //            //    };
        //            //    await _repositoryDetailRepository.UpdateAsync(modelDetail, cancellationToken);
        //            //    model.ReceiptDetail.Add(modelDetail);
        //            //}
        //            scope.Complete();
        //            return _mapper.Map<ReceiptDetailDTO>(model);
        //        }
        //        catch (Exception e)
        //        {
        //            scope.Dispose();
        //            return null;
        //        }
        //    }
        //}

        #endregion

    }
}
