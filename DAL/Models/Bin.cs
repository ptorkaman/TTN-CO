using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Bins")]

    public class Bin: BaseClass<int>
    {
        public int WarehoseId { get; set; }
        public string Name { get; set; }

    }
}
