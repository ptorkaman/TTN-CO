using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("TransportationDtl", Schema = "TTN")]

    public class TransportationDtl : BaseClass<int> 
    {
        public int TransportationId { get; set; }
        public string Remark { get; set; }

        

    }
}
