using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("SenderWarehouses", Schema = "TTN")]

    public class SenderWarehouse : BaseClass<int> 
    {
        public int SenderId { get; set; }
        public string WarehouseId { get; set; }

       

    }
}
