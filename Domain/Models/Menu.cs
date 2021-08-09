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

    public partial class Menu:BaseClass<long>
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public virtual IList<UserMenu> UserMenus { get; set; }

    }
}
