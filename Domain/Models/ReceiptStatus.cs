using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("BijakStatus", Schema = "TTN")]

    public class ReceiptStatus : BaseClass<int> 
    { 
        public string Title { get; set; }
       

    }
}
