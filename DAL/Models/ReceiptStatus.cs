using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("ReceiptStatuses")]

    public class ReceiptStatus : BaseClass<int> 
    { 
        public string Title { get; set; }
        public int Code { get; set; }

    }
}
