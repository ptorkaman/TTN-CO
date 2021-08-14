using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace TTNCO.Controllers.Filter
{
    public class FlightSearch
    {
        [Required]
        public DateTime FlightDate { get; set; }
        [Required]
        public string FlightNumber { get; set; }
    }

    public class GetDataByDateFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PositionId { get; set; }
        public int AcTypeId { get; set; }
        public string EmployeeNumber { get; set; }
    }
    public class FilterEmployee
    {
        public string EmployeeNumber { get; set; }
    }
}
