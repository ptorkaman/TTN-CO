using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace TTN
{
  
    public abstract class Criteria
    {

        public virtual object FirstOprand { get; set; }

        public virtual object SecondOperand { get; set; }
        public Type ObjectType { get; set; }
        public abstract Expression GetExpression(ParameterExpression parameter);
        public static Type[] GetKnownType()
        {
            return new Type[] { typeof(Criteria), typeof(AndCriteria), typeof(EqualCriteria), typeof(GreaterThan), typeof(GreaterThanOrEqual), typeof(LessThan), typeof(LessThanOrEqual), 
                typeof(LikeCriteria), typeof(NotEqualCriteria), typeof(OrCriteria) , typeof(EmptyCriteria) };
        }
    }
}
