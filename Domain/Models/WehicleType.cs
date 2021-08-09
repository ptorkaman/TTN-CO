using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("WehicleType", Schema = "TTN")]

    public class WehicleType : BaseClass<int> 
    {
        public string Name { get; set; }
        public string Dimension { get; set; }
        public string FactoryId { get; set; }
        public string DownloadType { get; set; }
        public int MinimumCapacity { get; set; }
        public int MaximumCapacity { get; set; }


    }
}
