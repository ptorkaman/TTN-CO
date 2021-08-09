using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Unit", Schema = "TTN")]

    public class Unit : BaseClass<int> 
    {
        public string Name { get; set; }
        public string Dimension { get; set; }

        

    }
}
