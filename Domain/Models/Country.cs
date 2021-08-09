using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Country", Schema = "TTN")]

    public class Country : BaseClass<int> 
    {
        public string Name { get; set; }
        public string EnglishName { get; set; }
       


    }
}
