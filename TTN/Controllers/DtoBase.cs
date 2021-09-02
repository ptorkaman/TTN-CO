using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTNCO
{
  
        public class  DtoBase
    {
        public DtoBase()
        {
            this.MessageError = new List<string>();
        }
        public bool DtoIsValid { get; set; }
        public IList<string> MessageError { get; set; }
        public string Status { get; set; }
        public object Results { get; set; }
    }
}
