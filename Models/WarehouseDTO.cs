using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class WarehouseDTO : BaseClassDTO<int>
    {
        public string WarehouseCode { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string ContactPerson { get; set; }
        public string ContactMobile1 { get; set; }
        public string ContactMobile2 { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Longitude { get; set; }


        
    }
}
