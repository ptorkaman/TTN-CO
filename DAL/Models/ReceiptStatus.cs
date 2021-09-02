using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("BijakStatuses", Schema = "TTN")]

    public class ReceiptStatus : BaseClass<int> 
    { 
        public string Title { get; set; }
       

    }
}
