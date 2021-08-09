using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("BijakStatus", Schema = "TTN")]

    public class BijakStatus : BaseClass<int> 
    { 
        public string Title { get; set; }
       

    }
}
