using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Regions", Schema = "TTN")]

    public class Region : BaseClass<int> 
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        

    }
}
