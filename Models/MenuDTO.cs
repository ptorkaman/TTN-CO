using System.Collections.Generic;

namespace DTO
{
    public partial class MenuDTO:BaseClassDTO<long>
    {
        public MenuDTO()
        {
            UserMenus = new List<UserMenuDTO>();
        }
        public string Title { get; set; }
       // public long PermissionId { get; set; }
        //public virtual PermissionDTO Permission { get; set; }
        public long? ParentId { get; set; }
        public virtual IList<UserMenuDTO> UserMenus { get; set; }

    }
}
