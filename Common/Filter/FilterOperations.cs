using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTN
{
    public enum FilterOperations
    {
        Equal = 1,
        Like = 2,
        NotEqual = 3,
        GreaterThan = 4,
        GreaterThanOrEqual = 5,
        LessThan = 6,
        LessThanOrEqual = 7,
        Between = 8,
    }
}
