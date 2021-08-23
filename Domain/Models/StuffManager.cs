using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("StuffManagers", Schema = "TTN")]

    public class StuffManager : BaseClass<int>
    {
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal  Length { get; set; }
        public decimal Weight { get; set; }

    }
}
