using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public  class ReceiptDetailDTO : BaseClassDTO<int> 
    { 
        public long ReceiptId { get; set; }
        public string GoodsName { get; set; }
        public int GoodsId { get; set; }
        public int Qty { get; set; }
        public int UsnitId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal weight { get; set; }
        public ReceiptStatusDTO Status { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DownloadDate { get; set; }
        public int? DownloadBy { get; set; }
        public virtual PackageTypeDTO PackageType { get; set; }
        public int PackageTypeId { get; set; }
        public virtual StuffManagerDTO StuffManager { get; set; }
        public long StuffManagerId { get; set; }
    }
}
