using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public  class BijakDtlDTO : BaseClassDTO<int> 
    { 
        public long BijakId { get; set; }
        public string GoodsName { get; set; }
        public int GoodsId { get; set; }
        public int Qty { get; set; }
        public int UsnitId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal weight { get; set; }
    }
}
