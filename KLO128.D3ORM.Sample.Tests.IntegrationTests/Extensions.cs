using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Common.Impl.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Domain.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests
{
    public static class Extensions
    {
        public static ServiceResult<TResult> RollbackAction<TResult>(this ID3Context d3Context, IDbConnection dbConnection, Func<ServiceResult<TResult>> func)
        {
            dbConnection.OpenIfNot();

            using (var transaction = dbConnection.BeginTransaction())
            {
                try
                {
                    var result = func();

                    transaction.Rollback();

                    return result;
                }
                catch (Exception exp)
                {
                    transaction.Rollback();
                    var err = exp as Error;

                    if (err == null)
                    {
                        Assert.Fail(exp.Message);

                        return new ServiceResult<TResult>() { Error = new Error() };
                    }

                    return new ServiceResult<TResult> { Error = err };
                }
            }
        }

        public static void AssertServiceFail(ServiceResult serviceResult)
        {
            if (serviceResult.Error != null)
            {
                Assert.Fail(string.Format(Translations.ResourceManager.GetString(serviceResult.Error.ErrCode) ?? "Unknown Exception Code", serviceResult.Error.ErrArgs));
            }
        }

        public static List<PropertyInfo?>? TryGetAggregates(this ISpecification d3Specification)
        {
            var aggContextMapperProp = typeof(D3BaseSpecification).GetProperty("AggContextMapper");

            if (d3Specification == null || d3Specification is not D3BaseSpecification || aggContextMapperProp == null || aggContextMapperProp.GetValue(d3Specification) is not Dictionary<Type, List<AggregateContext>> aggContextMapper)
            {
                return null;
            }

            var ret = new List<PropertyInfo?>();

            foreach (var aggContexts in aggContextMapper)
            {
                foreach (var aggContext in aggContexts.Value)
                {
                    if (aggContext.Property.Property == null || ret.Contains(aggContext.Property.Property))
                    {
                        continue;
                    }

                    ret.Add(aggContext.Property.Property);
                }
            }

            return ret;
        }
    }
}
