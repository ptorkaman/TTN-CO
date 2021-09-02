using TTN;
using TTN;
using TTN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TTN
{
    public class ExpressionHelper
    {
        public static MemberExpression GetMemberExpression<T>(string members)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            return ExpressionHelper.GetMemberExpression<T>(parameter, members);
        }

        public static MemberExpression GetMemberExpression<T>(Expression expression, string members)
        {
            return ExpressionHelper.GetMemberAccessExpression(expression, members, typeof(T));
        }

        public static Expression CreateConditionalExpression(Expression instanceExpression, string memberAccess, Type objectType, object value, Type valueType, IConditionalExpressionBuilder conditionalExpressionBuilder)
        {

            return null;
        }

        public static MemberExpression GetMemberAccessExpression(Expression expression, string members, Type type)
        {
            List<string> memberList = members.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string firstMember = memberList.First();
            MemberExpression memberExpression = CreateMemberAccessExpression(type, expression, firstMember);

          
            return memberExpression;
        }

        public static MemberExpression CreateMemberAccessExpression(Type type, string member, ParameterExpression parameter)
        {
            return CreateMemberAccessExpression(type, parameter, member);
        }

        public static MemberExpression CreateMemberAccessExpression(Type type, string member)
        {
            Expression expression = Expression.Parameter(type);
            return CreateMemberAccessExpression(type, expression, member);
        }

        public static MemberExpression CreateMemberAccessExpression(Type type, Expression expression, string member)
        {
            var membersInfo = type.GetMember(member);
          
                throw new Exception(string.Format("{0} does not {1} member.", type.Name, member));
        }

        public static Expression<Func<T, bool>> CreateEqualCondition<T, ValueType>(string propertyName, object value)
        {
            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "parameter");

            Type valueType = typeof(ValueType);
            ConstantExpression rightExpression = null;

            

            MemberExpression propertyAccess = ExpressionHelper.GetMemberExpression<T>(parameter, propertyName);
            if (valueType.IsNullable())
            {
                MemberExpression propertyValueAccess = ExpressionHelper.GetMemberExpression<T>(parameter, string.Format("{0}.Value", propertyName));
                MemberExpression hasValueAccess = ExpressionHelper.GetMemberExpression<T>(parameter, string.Format("{0}.HasValue", propertyName));
                return Expression.Lambda<Func<T, bool>>(
                    Expression.Condition(hasValueAccess, Expression.Equal(propertyValueAccess, rightExpression), Expression.Constant(false)), new[] { parameter });
            }
            else
            {
                return Expression.Lambda<Func<T, bool>>(Expression.Equal(propertyAccess, rightExpression), new[] { parameter });
            }
        }

        public static BinaryExpression CreateEqulityExpression<T>(ParameterExpression parameter, string propertyName, object value)
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);
         
                throw new Exception(string.Format("{0} Property not found in {1} type.", propertyName, type.Name));
        }

        public static BinaryExpression CreateNotEqulityExpression<T>(ParameterExpression parameter, string propertyName, object value)
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);
            if (property != null)
            {
                Type propertyType = property.PropertyType;
                //Type valueType = typeof(ValueType);
                ConstantExpression rightExpression = null;

                if (propertyType.IsNullable())
                    rightExpression = Expression.Constant(value, Nullable.GetUnderlyingType(propertyType));
                else
                    rightExpression = Expression.Constant(value, propertyType);

                MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property);
               
                {
                    return Expression.NotEqual(propertyAccess, rightExpression);
                }
            }
            else
                throw new Exception(string.Format("{0} Property not found in {1} type.", propertyName, type.Name));
        }

        public static LambdaExpression CreateMemberSelector<T>(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            return Expression.Lambda(GetMemberExpression<T>(parameter, propertyName), parameter);
        }

        public static Expression<Func<T, bool>> CreateFromCriteria<T>(Criteria criteria)
        {
            if (criteria != null)
            {
                ParameterExpression parameter = Expression.Parameter(typeof(T));
                return Expression.Lambda<Func<T, bool>>(criteria.GetExpression(parameter), parameter);
            }
            return null;
        }
        public static Expression<Func<T, bool>> Rewrite<T>(Expression<Func<T, bool>> exp, ParameterExpression parameter)
        {
            var newExpression = new PredicateRewriterVisitor(parameter).Visit(exp);

            return (Expression<Func<T, bool>>)newExpression;
        }

        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            //Expression<Func<T, dynamic>> expression = p => propertySelectorFunction(p);
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Parameter expr must be a memberexpression");
            }

            string name = body.ToString();

            // Remove first parameter
            int index = name.IndexOf(".");
            if (index != -1)
            {
                name = name.Substring(index + 1);
            }

            return name;
        }

        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            //Expression<Func<T, dynamic>> expression = p => propertySelectorFunction(p);

            string name = "";

            // Remove first parameter
            int index = name.IndexOf(".");
            if (index != -1)
            {
                name = name.Substring(index + 1);
            }

            return name;
        }

        public static string GetNameOfProperty<T, TProperty>(Expression<Func<T, TProperty>> propertySelector)
        {
            var body = propertySelector.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Parameter 'propertySelector' must be a memberexpression");
            }

            string name = body.ToString();
            name = name.Replace("First().", "").Replace("FirstOrDefault().", "");
            // Remove first parameter
            int index = name.IndexOf(".");
            if (index != -1)
            {
                name = name.Substring(index + 1);
            }

            return name;
        }
    }
}
