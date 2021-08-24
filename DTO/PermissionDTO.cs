using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class PermissionDTO:BaseClassDTO<long>
    {
       

        public string Name { get; set; }
        public string EnglishName { get; set; }

    }
}
