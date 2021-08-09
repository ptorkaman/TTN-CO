using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Bin", Schema = "TTN")]

    public class Bin: BaseClass<int>
    {
        public int WarehoseId { get; set; }
        public string BinName { get; set; }

    }
}
