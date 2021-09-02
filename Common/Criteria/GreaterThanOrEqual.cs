using TTN;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TTN
{
    [Serializable]
    public class GreaterThanOrEqual : Criteria
    {
        public override Expression GetExpression(ParameterExpression parameter)
        {
                   return ExpressionHelper.CreateConditionalExpression(parameter, this.FirstOprand.ToString(), ObjectType, this.SecondOperand, this.SecondOperand.GetType(), new GreaterThanOrEqualConditionExpressionBuilder());
        }
    }
}
