using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("UserMenu", Schema = "TTN")]

    public  class UserMenu : BaseClass<long>
    {
        public long MenuId { get; set; }
        public long UserId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }

    }
}
