using System.ComponentModel;
using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("SenderReciverAddresses", Schema = "TTN")]

    public class SenderReciverAddress : BaseClass<int> 
    {
        public SenderReciver SenderReciver { get; set; }
        public int SenderReciverId { get; set; }
        public string Address { get; set; }

    }


}
