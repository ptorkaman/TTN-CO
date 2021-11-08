using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("UserWarhouses")]

    public class UserWarhouse : BaseClass<long> 
    {
        public virtual Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }

        public virtual User User { get; set; }
        public long UserId { get; set; }


    }
}
