using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class RoleDTO
    {
        public RoleDTO()
        {
            RolePermissions = new HashSet<RolePermissionDTO>();
            UserRoles = new HashSet<UserRoleDTO>();
        }

        public long Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<RolePermissionDTO> RolePermissions { get; set; }
        public virtual ICollection<UserRoleDTO> UserRoles { get; set; }
    }
}
