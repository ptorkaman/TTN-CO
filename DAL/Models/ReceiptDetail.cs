using Domain.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("ReceiptDetails")]

    public class ReceiptDetail : BaseClass<int> 
    { 
        public long ReceiptId { get; set; }
        public string GoodsName { get; set; }
        public int GoodsId { get; set; }
        public int Count { get; set; }
        public int UsnitId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal weight { get; set; }
        
        public virtual PackageType PackageType { get; set; }
        public int PackageTypeId { get; set; }
        public virtual StuffManager StuffManager { get; set; }
        public long StuffManagerId { get; set; }

        public ReceiptStatus Status { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DownloadDate { get; set; }
        public int? DownloadBy { get; set; }

    }
}
