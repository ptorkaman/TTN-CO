using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class RolePermissionDTO:BaseClassDTO<long>
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }

        public virtual PermissionDTO Permission { get; set; }
        public virtual RoleDTO Role { get; set; }
    }
}
