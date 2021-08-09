using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class PermissionDTO:BaseClassDTO<long>
    {
        public PermissionDTO()
        {
            Menus = new HashSet<MenuDTO>();
            RolePermissions = new HashSet<RolePermissionDTO>();
        }

        public string Name { get; set; }
        public string EnglishName { get; set; }

        public virtual ICollection<MenuDTO> Menus { get; set; }
        public virtual ICollection<RolePermissionDTO> RolePermissions { get; set; }
    }
}
