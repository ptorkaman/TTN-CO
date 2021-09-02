using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("ReceiptDetails", Schema = "TTN")]

    public class ReceiptDetail : BaseClass<int> 
    { 
        public long ReceiptId { get; set; }
        public string GoodsName { get; set; }
        public int GoodsId { get; set; }
        public int Count { get; set; }
        public int UsnitId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal weight { get; set; }
        
        public virtual PackageType PackageTypes { get; set; }
        public int PackageTypesId { get; set; }
        public virtual StuffManager StuffManager { get; set; }
        public int StuffManagerId { get; set; }
        
    }
}
