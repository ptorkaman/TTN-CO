using TTN;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TTN
{
    [Serializable]
    public class LessThan : Criteria
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
            //MemberExpression leftExpression = ExpressionHelper.GetMemberAccessExpression(parameter, this.FirstOprand.ToString(), ObjectType);

            //Type firstdOperandType = ((PropertyInfo)(leftExpression.Member)).PropertyType;
            //Type secondOperandType = this.SecondOperand.GetType();

            //ConstantExpression rightExpression = Expression.Constant(this.SecondOperand, secondOperandType.FullName.StartsWith(typeof(Nullable<>).FullName) ? Nullable.GetUnderlyingType(secondOperandType) : secondOperandType);

            //return firstdOperandType.FullName.StartsWith(typeof(Nullable<>).FullName) ? Expression.LessThan(Expression.Convert(leftExpression, Nullable.GetUnderlyingType(firstdOperandType)), rightExpression) : Expression.LessThan(leftExpression, rightExpression);
            return ExpressionHelper.CreateConditionalExpression(parameter, this.FirstOprand.ToString(), ObjectType, this.SecondOperand, this.SecondOperand.GetType(), new LessThanConditionExpressionBuilder());
        }
    }
}
