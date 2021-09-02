using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TTN
{
    public class EmptyCriteria : Criteria
    {
        public override Expression GetExpression(ParameterExpression parameter)
        {
            if (parameter == null)
            {
                parameter = Expression.Parameter(ObjectType);
            }

            return Expression.Constant(true);
        }
    }
}
