

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("RolePermissions")]
    public  class RolePermission
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
        public string Roles { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }

}
