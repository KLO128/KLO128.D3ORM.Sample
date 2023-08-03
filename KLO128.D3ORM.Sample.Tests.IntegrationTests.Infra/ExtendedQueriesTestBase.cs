using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Tests;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks;
using KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs;
using KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities;
using KLO128.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Infra
{
    public abstract class ExtendedQueriesTestBase
    {
        public QueryTestsHandler TestsHandler { get; set; }

        public ExtendedQueriesTestBase(DatabaseType databaseType)
        {
            ServiceConfig.InjectAll(databaseType);

            TestsHandler = new QueryTestsHandler(databaseType);
        }

        [TestInitialize]
        public void InitData()
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                TestData.InitData(scope);
            }
        }

        private List<TOUT> CompareResults<T, TOUT>(IServiceScope scope, string testCaseName) where T : class, new()
        {
            if (TestsHandler.TestCases.TryGetValue(testCaseName, out TestCase? testCase))
            {
                if (ExtendedQueriesTestData.ExpectedOrderedData.TryGetValue(testCaseName, out object? expected))
                {
                    var skipAndTakeIdx = testCaseName.IndexOf("SkipAndTake");
                    var takeCount = 10;
                    if (skipAndTakeIdx >= 0 && (testCase.Args.FirstOrDefault()?.Equals(true) ?? false))
                    {
                        takeCount = 4;
                    }

                    return CompareResults<T, TOUT>(scope, testCase, skipAndTakeIdx != -1, takeCount, expected as IEnumerable);
                }

                Assert.Fail($"Could not find expected Integration Test Data by the key: {testCaseName}");
            }

            Assert.Fail($"Test case not found by the key: {testCaseName}");

            return new List<TOUT>();
        }

        private List<TOUT> CompareResults<T, TOUT>(IServiceScope scope, TestCase testCase, bool skipAndTake, int take, IEnumerable? baseData) where T : class, new()
        {
            var ret = new List<TOUT>();

            if (scope.ServiceProvider.GetService<ID3Context>() is not ID3Context context || scope.ServiceProvider.GetService<IDbConnection>() is not IDbConnection conn)
            {
                Assert.Fail($"IDbConnection or ID3Context not injected...");
                return ret;
            }

            if (testCase.MockService is not ISpecificationWithParams specParamized)
            {
                Assert.Fail($"MockService is not {nameof(ISpecificationWithParams)}");
                return ret;
            }

            if ((specParamized as D3BaseSpecification)?.GetSelf() is not D3CoreSpecification specification)
            {
                Assert.Fail($"MockService is not {nameof(D3CoreSpecification)}");
                return ret;
            }

            var args = new List<string>();

            for (int i = 1; i < testCase.Args.Length; i++)
            {
                var arg = testCase.Args[i];

                if (arg is Array array)
                {
                    foreach (var item in array)
                    {
                        args.Add(item?.ToString() ?? string.Empty);
                    }
                }
                else
                {
                    args.Add(testCase.Args[i]?.ToString() ?? string.Empty);
                }
            }

            var countAvgMinMaxSum = typeof(TOUT) == typeof(object);

            if (countAvgMinMaxSum)
            {
                if (skipAndTake)
                {
                    ret = conn.AggCompute<object>(context, D3Specification.BuildSQL(specification, true, false, specParamized.Parameters), 0, take) as List<TOUT>;
                }
                else
                {
                    ret = conn.AggCompute<object>(context, D3Specification.BuildSQL(specification, false, false, specParamized.Parameters)) as List<TOUT>;
                }
            }
            else if (skipAndTake)
            {
                ret = conn.AggSelect<T>(context, D3Specification.BuildSQL(specification, true, false, specParamized.Parameters), 0, take) as List<TOUT>;
            }
            else
            {
                ret = conn.AggSelect<T>(context, D3Specification.BuildSQL(specification, false, false, specParamized.Parameters)) as List<TOUT>;
            }

            if (ret == null)
            {
                throw new Exception($"Invalid output list: Expected List<{nameof(TOUT)}>");
            }

            //using (var expected = conn.ExecuteReader(testCase.ExpectedResult.ToString() ?? string.Empty))
            //{
            //    var data = new DataTable();
            //    data.Load(expected);

            //    //Assertion.SortEntityCollection(baseData, data, Enumerable.Range(0, expected.FieldCount).Select(expected.GetName).ToArray(), expressions);
            //}

            if (ret is ICollection<PlayoffRoundCouple> list)
            {
                Assertion.AssertObj(baseData, list.SelectMany(x => x.Matches).ToList(), specification.TryGetAggregates(), testCase.Name);
            }
            else if (ret is ICollection<PlayoffRoundCoupleDTO> listDTO)
            {
                Assertion.AssertObj(baseData, listDTO.SelectMany(x => x.MatchesTest).ToList(), specification.TryGetAggregates(), testCase.Name);
            }
            else if (testCase.Name == QueryConstants.PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQueryAsDTO)
            {
                var dto = ret.ToDTO<List<PlayoffComputeStatsDTO>>();

                Assertion.AssertObj(baseData, dto, null, testCase.Name);
            }
            else
            {
                Assertion.AssertObj(baseData, ret, countAvgMinMaxSum ? null : specification.TryGetAggregates(), testCase.Name);
            }

            return ret;
        }

        [TestMethod]
        //
        // This is only a taste of tests!!!...
        // And so on...
        //
        [DataRow(QueryConstants.PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQuery)]
        public void ExpandoObjectQueries_CountAvgMinMaxSum(string testCaseName)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                //ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                //{
                // PlayoffInit(scope);

                var result = CompareResults<PlayoffRoundCouple, object>(scope, testCaseName);

                JsonConvert.SerializeObject(result);

                //  return new ServiceResult<object>();
                //});
            }
        }
    }
}
