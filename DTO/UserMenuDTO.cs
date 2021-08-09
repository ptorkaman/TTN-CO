

namespace DTO
{
    public partial class UserMenuDTO : BaseClassDTO<long>
    {
        public long MenuId { get; set; }
        public long UserId { get; set; }
        public virtual MenuDTO Menu { get; set; }
        public virtual UserDTO User { get; set; }

    }
}
