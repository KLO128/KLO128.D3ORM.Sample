using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace KLO128.D3ORM.Sample.Tests
{
    public static class Extensions
    {
        public static T? GetService<T>(this IServiceScope scope)
        {
            return scope.ServiceProvider.GetService<T>();
        }

        public static Expression<Func<T, TProp>> GetPropExpression<T, TProp>(this PropertyInfo prop)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, prop);
            return Expression.Lambda<Func<T, TProp>>(property, parameter);
        }

        public static int Factorial(int input)
        {
            var result = 1;
            for (int i = input; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }

        public static Exception UnexpectedDatabaseType(string databaseType)
        {
            throw new NotSupportedException($"Unexpected Database Type: {databaseType}.");
        }
    }
}
