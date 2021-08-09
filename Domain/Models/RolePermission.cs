

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("RolePermission", Schema = "TTN")]
    public partial class RolePermission
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
