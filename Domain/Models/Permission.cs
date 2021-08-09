using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Permission", Schema = "TTN")]

    public partial class Permission
    {
        public Permission()
        {
            Menus = new HashSet<Menu>();
            RolePermissions = new HashSet<RolePermission>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
