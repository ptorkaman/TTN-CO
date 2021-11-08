using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Countries")]

    public class Country : BaseClass<int> 
    {
        public string Name { get; set; }
        public string EnglishName { get; set; }
       


    }
}
