using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using DTO;

namespace TTNCO.Dto
{
    public class NodeDto
    {
        public NodeDto()
        {
            this.Modules = new List<Module>();
            UserMenus = new List<UserMenu>();
            this.Principles = new List<string>();
            ValidForServices = true;
        }

        public UserInfo User { get; set; }
        public IList<Module> Modules { get; set; }
        public IList<UserMenu> UserMenus { get; set; }
        public string Token { get; set; }
        public string Ip { get; set; }
        public string DashboardUrl { get; set; }
        public DateTime AccessTokenExpirationDateTime { get; set; }
        public IList<string> Principles { get; set; }
        public bool ValidForServices { get; set; }
        public string Enviroment { get; set; }
        public int ExpireDate { get; set; }

    }

    public class Principle

    {
        public string Resource { get; set; }
        public string Actions { get; set; }
    }

    public class Module
    {
        public Module()
        {
            this.Menus = new List<Menue>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string DashboarUrl { get; set; }
        public IList<Menue> Menus { get; set; }

    }

    public class Menue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string ParentId { get; set; }
        public string Link { get; set; }
    }
    public class UserInfo
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public long UserId { get; set; }
        public IList<String> Roles { get; set; }
        public IList<string> RoleNames { get; set; }
        public bool IsFirstLogin { get; set; }
        public bool ShowAllComponent { get; set; }
        public String Base { get; set; }
        public IList<int> Stations { get; set; }
        public UserInfo()
        {
            this.Roles = new List<string>();
            this.RoleNames = new List<string>();
            this.Stations = new List<int>();
        }
    }
}
