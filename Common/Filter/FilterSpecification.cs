using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTN
{
    public class FilterSpecification<T>
    {
        public string PropertyName { get; set; }
        public string FilterValue { get; set; }
        public FilterOperations FilterOperation { get; set; }
    }
}
