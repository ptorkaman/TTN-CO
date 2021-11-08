using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("GroupUsers")]

    public class GroupUser : BaseClass<int>
    {
        public string Name { get; set; }

    }
}
