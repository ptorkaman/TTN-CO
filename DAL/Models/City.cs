using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Cities", Schema = "TTN")]

    public class City : BaseClass<int> 
    {
        public int ProvinceId { get; set; }
        //public int WarhouseId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Longitude { get; set; }
        public int SortBy { get; set; }


    }
}
