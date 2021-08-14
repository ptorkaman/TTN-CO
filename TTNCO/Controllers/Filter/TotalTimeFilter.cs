using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTNCO.Controllers.Filter
{
    public class TotalTimeFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string EmployeeNumber { get; set; }
        public int AcRegId { get; set; }
    }
}
