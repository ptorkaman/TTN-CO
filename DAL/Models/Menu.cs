using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Menus")]

    public  class Menu:BaseClass<long>
    {
        public Menu()
        {
            //UserMenus = new List<UserMenu>();
        }
        public string Title { get; set; }
        public long? ParentId { get; set; }

        public virtual IList<UserMenu> UserMenus { get; set; }

    }
}
