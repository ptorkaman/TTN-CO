
namespace DTO
{
    public partial class MenuPermissionDTO : BaseClassDTO<long>
    {
        public long MenuId { get; set; }
        public long PermissionId { get; set; }
        public  MenuDTO Menu { get; set; }
        public  PermissionDTO Permission { get; set; }

    }
}
