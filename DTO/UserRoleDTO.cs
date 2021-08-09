using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserRoleDTO : BaseClassDTO<long>
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }

        public virtual RoleDTO Role { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
