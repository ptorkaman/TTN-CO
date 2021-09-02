using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
    [Table("VehicleManagers", Schema = "TTN")]
    public class VehicleManager : BaseClass<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string NationalCode { get; set; }
        public string VehicleNumber { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
