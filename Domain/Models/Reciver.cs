using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Reciver", Schema = "TTN")]

    public class Reciver : BaseClass<int> 
    {
        public int CityId { get; set; }
        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

    }
}
