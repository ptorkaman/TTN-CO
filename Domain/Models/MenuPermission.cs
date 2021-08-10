using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("MenuPermission", Schema = "TTN")]

    public  class MenuPermission : BaseClass<long>
    {
        public long MenuId { get; set; }
        public long PermissionId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Permission Permission { get; set; }

    }
}
