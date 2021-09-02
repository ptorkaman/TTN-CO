using TTN;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TTN
{
    [Serializable]
    public class EqualCriteria : Criteria
    {
        public override Expression GetExpression(ParameterExpression parameter)
        {
            if (this.FirstOprand == null && this.SecondOperand == null)
            {
                return null;
            }

            if (this.FirstOprand == null)
            {
                throw new Exception("First oprand can not be null.");
            }
            if (this.SecondOperand == null)
            {
                throw new Exception("Second operand can not be null.");
            }

            if (this.FirstOprand.GetType() != typeof(string))
            {
                throw new Exception("First operand must be string.");
            }

            if (parameter == null)
            {
                parameter = Expression.Parameter(ObjectType);
            }
            if (ObjectType == null)
            {
                ObjectType = parameter.Type;
            }
            //return ExpressionGenerator.CreateEqualExpression(parameter, this.FirstOprand.ToString(), ObjectType, this.SecondOperand, this.SecondOperand.GetType());
            //MemberExpression leftExpression = ExpressionHelper.GetMemberExpression(parameter, this.FirstOprand.ToString(), ObjectType);

            //Type firstdOperandType = ((PropertyInfo)(leftExpression.Member)).PropertyType;
            //Type secondOperandType = this.SecondOperand.GetType();

            //ConstantExpression rightExpression = Expression.Constant(this.SecondOperand, secondOperandType.FullName.StartsWith(typeof(Nullable<>).FullName) ? Nullable.GetUnderlyingType(secondOperandType) : secondOperandType);

            //if (firstdOperandType.FullName.StartsWith(typeof(Nullable<>).FullName))
            //{
            //    return Expression.And(Expression.NotEqual(leftExpression, Expression.Constant(null)),
            //    Expression.Equal(Expression.Convert(leftExpression, Nullable.GetUnderlyingType(firstdOperandType)), rightExpression));
            //}
            //return Expression.Equal(leftExpression, rightExpression);
            return ExpressionHelper.CreateConditionalExpression(parameter, this.FirstOprand.ToString(), ObjectType, this.SecondOperand, this.SecondOperand.GetType(), new EqualConditionExpressionBuilder());
        }
    }
}
