using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Roles")]

    public  class Role
    {
        public Role()
        {
            //RolePermissions = new HashSet<RolePermission>();
            //UserRoles = new HashSet<UserRole>();
        }

        public long Id { get; set; }
        public string Title { get; set; }

        public virtual IList<RolePermission> RolePermissions { get; set; }
        //public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
