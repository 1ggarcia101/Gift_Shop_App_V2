using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SS.Template.Application.Infrastructure
{
    public interface IFilterCriteria
    {
        Expression<Func<T, bool>> BuildDynamicExpression<T>(string propertyName, List<int> propertyValue);
        Expression<Func<T, bool>> BuildDynamicExpression<T>(string propertyName, List<string> propertyValue);

    }
    public class FilterCriteria: IFilterCriteria
    {
        public  Expression<Func<T, bool>> BuildDynamicExpression<T>(string propertyName, List<int> propertyValue)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var method = propertyValue.GetType().GetMethod("Contains");
            var call = Expression.Call(Expression.Constant(propertyValue), method, Expression.Property(parameter, propertyName));
            return Expression.Lambda<Func<T, bool>>(call, parameter);
        }
        public Expression<Func<T, bool>> BuildDynamicExpression<T>(string propertyName, List<string> propertyValue)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var method = propertyValue.GetType().GetMethod("Contains");
            var call = Expression.Call(Expression.Constant(propertyValue), method, Expression.Property(parameter, propertyName));

            return Expression.Lambda<Func<T, bool>>(call, parameter);
        }
    }
}
