using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("TransportationDetails")]

    public class TransportationDetail : BaseClass<int> 
    {
        public int TransportationId { get; set; }
        public string Remark { get; set; }

        

    }
}
