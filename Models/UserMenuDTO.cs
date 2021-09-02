

namespace DTO
{
    public partial class UserMenuDTO : BaseClassDTO<long>
    {
        public UserMenuDTO()
        {
            //Menu = new MenuDTO();
            //User = new UserDTO();
        }
        public long MenuId { get; set; }
        public long UserId { get; set; }
        //public virtual MenuDTO Menu { get; set; }
        //public virtual UserDTO User { get; set; }
        public string MenuTitle { get; set; }
        public long? ParentId { get; set; }
    }
}
