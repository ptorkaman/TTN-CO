using TTN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TTN
{

    public static class LinqExtensions
    {

        public static PropertyInfo ExtractPropertyInfo(this LambdaExpression propertyAccessor)
        {
            return propertyAccessor.ExtractMemberInfo() as PropertyInfo;
        }

        public static FieldInfo ExtractFieldInfo(this LambdaExpression propertyAccessor)
        {
            return propertyAccessor.ExtractMemberInfo() as FieldInfo;
        }

        public static MemberInfo ExtractMemberInfo(this LambdaExpression propertyAccessor)
        {
            Guard.ArgumentNotNull(() => propertyAccessor);

            MemberInfo info;
            try
            {
                MemberExpression operand;
                // o => o.PropertyOrField
                LambdaExpression expression = propertyAccessor;

                if (expression.Body is UnaryExpression)
                {
                    // If the property is not an Object, then the member access expression will be wrapped in a conversion expression
                    // (object)o.PropertyOrField
                    UnaryExpression body = (UnaryExpression)expression.Body;
                    // o.PropertyOrField
                    operand = (MemberExpression)body.Operand;
                }
                else
                {
                    // o.PropertyOrField
                    operand = (MemberExpression)expression.Body;
                }

                // Member
                MemberInfo member = operand.Member;
                info = member;
            }
            catch (Exception e)
            {
                throw new ArgumentException("The property or field accessor expression is not in the expected format 'o => o.PropertyOrField'.", e);
            }

            return info;
        }

    }

}
