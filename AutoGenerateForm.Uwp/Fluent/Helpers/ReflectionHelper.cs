using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoGenerateForm.Uwp.Helpers
{
    internal static class Reflection
    {
        internal static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (expression.Body is UnaryExpression unaryExp)
            {
                if (unaryExp.Operand is MemberExpression memberExp)
                {
                    return (PropertyInfo)memberExp.Member;
                }
            }
            else if (expression.Body is MemberExpression memberExp)
            {
                return (PropertyInfo)memberExp.Member;
            }

            throw new ArgumentException($"The expression doesn't indicate a valid property. [ { expression } ]");
        }

        internal static PropertyInfo GetPropertyInfoFromCollection<T, TCollection>(Expression<Func<T, IEnumerable<TCollection>>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (expression.Body is UnaryExpression unaryExp)
            {
                if (unaryExp.Operand is MemberExpression memberExp)
                {
                    return (PropertyInfo)memberExp.Member;
                }
            }
            else if (expression.Body is MemberExpression memberExp)
            {
                return (PropertyInfo)memberExp.Member;
            }

            throw new ArgumentException($"The expression doesn't indicate a valid property. [ { expression } ]");
        }
    }
}
