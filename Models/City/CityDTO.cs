using System.ComponentModel.DataAnnotations.Schema;
using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Models.City
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CityDTO : BaseClassDTO<int>
    {
        public int ProvinceId { get; set; }
        public string ProvinceTitle { get; set; }
        public int WarhouseId { get; set; }
        public string WarhouseTitle { get; set; }

        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Longitude { get; set; }
        public int SortBy { get; set; }
    }
}
