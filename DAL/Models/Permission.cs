using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
    [Table("Permissions", Schema = "TTN")]

    public  class Permission : BaseClass<long>
    {

 
        public string Name { get; set; }
        public string EnglishName { get; set; }

    }
}
