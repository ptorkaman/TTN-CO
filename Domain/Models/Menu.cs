using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Menu", Schema = "TTN")]

    public  class Menu:BaseClass<long>
    {
        public Menu()
        {
            //UserMenus = new List<UserMenu>();
        }
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public virtual IList<UserMenu> UserMenus { get; set; }

    }
}
