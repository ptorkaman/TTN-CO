using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
    [Table("PackageTypes")]
    public class PackageType : BaseClass<int>
    {
        public string Title { get; set; }
    }
}
