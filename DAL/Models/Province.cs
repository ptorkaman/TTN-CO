using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Provinces")]

    public class Province : BaseClass<int> 
    {
        public int CountryId { get; set; }
        public string ProvinceName { get; set; }



    }
}
