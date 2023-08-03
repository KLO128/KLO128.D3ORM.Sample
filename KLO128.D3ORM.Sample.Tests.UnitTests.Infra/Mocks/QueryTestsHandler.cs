using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Common.Impl.Extensions;
using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Infra.D3ORM;
using KLO128.D3ORM.Sample.Tests.UnitTests.Mocks;
using KLO128.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks
{
    public class QueryTestsHandler
    {
        public IQueryContainer QC { get; set; }

        public ID3Context D3Context { get; set; }

        public ISpecification<Team> TeamExtendedQuery
        {
            get
            {
                return QC.TeamBaseQuery
                    .Compare(x => x.Name, ComparisonOp.LIKE, "name%", LogicalOp.NONE)
                    .Compare(x => x.LastChange, ComparisonOp.GREATER_THAN_OR_EQUAL, new DateTime(2022, 4, 19), LogicalOp.OR)
                    .Compare(x => x.LastChange, ComparisonOp.LESS_THAN, new DateTime(2022, 4, 25), LogicalOp.AND);
            }
        }

        public Dictionary<string, TestCase> TestCases { get; set; }

        private static Type D3QUeryHelperType = typeof(D3QueryHelper);

        private const string GetInsertScriptMethodName = nameof(D3QueryHelper.GetInsertScript);
        private const string GetUpdateScriptMethodName = nameof(D3QueryHelper.GetUpdateScript);
        private const string GetDeleteScriptMethodName = nameof(D3QueryHelper.GetDeleteScript);
        private const string GetBulkUpdateScriptMethodName = nameof(D3QueryHelper.GetBulkUpdateScript);
        private const string GetBulkDeleteScriptMethodName = nameof(D3QueryHelper.GetBulkDeleteScript);
        private const string FindByIdQueryMethodName = nameof(D3QueryHelper.FindByIdQuery);

        private MethodInfo? FindByIdScript { get; } = D3QUeryHelperType.GetMethod(FindByIdQueryMethodName)?.MakeGenericMethod(typeof(int));

        private ISpecification<PlayoffRoundCouple> ExtendedAllPossibleRootsBaseQuery => D3Specification.Create<PlayoffRoundCouple>(D3Context)
                .And(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam1)
                    .And(D3Specification.Create<Tournament>(D3Context).OrderBy(x => x.TournamentId, true, 1)/*.OrderBy(x => x.Name, false, 3)*/
                        .And(D3Specification.Create<TourSerie>(D3Context)))
                    .And(QC.TeamBaseQuery.OrderBy(x => x.Name, true, 3)))
                .Or(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam2)
                    .And(QC.TeamBaseQuery.OrderBy(x => x.Name, true, 3)))
                .And(D3Specification.Create<Match>(D3Context).OrderBy(x => x.MatchId, false, 7)
                    .And(D3Specification.Create<MatchSetScore>(D3Context).OrderBy(x => x.SetOrder)));

        private ISpecification<PlayoffRoundCouple> ExtendedAllPossibleRootsByMatchBaseQuery => D3Specification.Create<PlayoffRoundCouple>(D3Context)
            .And(D3Specification.Create<Match>(D3Context).OrderBy(x => x.MatchId, false, 7)
                .And(D3Specification.Create<MatchSetScore>(D3Context).OrderBy(x => x.SetOrder)))
            .And(QC.TeamBaseQuery.OrderBy(x => x.Name, true, 3))
            .And(D3Specification.Create<Tournament>(D3Context).OrderBy(x => x.TournamentId, true, 1)/*.OrderBy(x => x.Name, false, 3)*/
            .And(D3Specification.Create<TourSerie>(D3Context)));

        private MethodInfo? GetInsertScript<TEntity>()
        {
            return D3QUeryHelperType.GetMethod(GetInsertScriptMethodName, BindingFlags.Public | BindingFlags.Static)?.MakeGenericMethod(typeof(TEntity));
        }
        private MethodInfo? GetDeleteScript<TEntity>()
        {
            return D3QUeryHelperType.GetMethod(GetDeleteScriptMethodName, BindingFlags.Public | BindingFlags.Static)?.MakeGenericMethod(typeof(TEntity));
        }

        private MethodInfo? GetUpdateScript<TEntity>() where TEntity : class
        {
            return (D3QUeryHelperType.GetMembers(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(x => x.Name == GetUpdateScriptMethodName && x is MethodInfo method && method.GetParameters().Length == 2) as MethodInfo)?.MakeGenericMethod(typeof(TEntity));
        }

        private MethodInfo? GetUpdatePropScript<TEntity>() where TEntity : class
        {
            return (D3QUeryHelperType.GetMembers(BindingFlags.Public | BindingFlags.Static).LastOrDefault(x => x.Name == GetUpdateScriptMethodName && x is MethodInfo method && method.GetParameters().Length == 4) as MethodInfo)?.MakeGenericMethod(typeof(TEntity));
        }

        private MethodInfo? GetBulkUpdateScript<TEntity>() where TEntity : class
        {
            return (D3QUeryHelperType.GetMembers(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(x => x.Name == GetBulkUpdateScriptMethodName) as MethodInfo)?.MakeGenericMethod(typeof(TEntity));
        }

        private MethodInfo? GetBulkDeleteScript<TEntity>() where TEntity : class
        {
            return (D3QUeryHelperType.GetMembers(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(x => x.Name == GetBulkDeleteScriptMethodName) as MethodInfo)?.MakeGenericMethod(typeof(TEntity));
        }

        private object[] GetStringArrayArgs(bool useSkipAndTake, params string[] args)
        {
            return new object[] { useSkipAndTake, args };
        }

        public QueryTestsHandler(DatabaseType databaseType)
        {
            ID3ContextFactory d3ContextFactory;

            switch (databaseType)
            {
                case DatabaseType.MySQL:
                    d3ContextFactory = new Sample.Infra.D3ORM.MySQL.MySQLD3ContextFactory();
                    break;
                case DatabaseType.SQLite:
                    d3ContextFactory = new Sample.Infra.D3ORM.SQLite.SQLiteD3ContextFactory();
                    break;
                case DatabaseType.MSSQL:
                    d3ContextFactory = new Sample.Infra.D3ORM.MSSQL.MSSQLD3ContextFactory();
                    break;
                default:
                    throw Extensions.UnexpectedDatabaseType(databaseType.ToString());
            }

            D3Context = d3ContextFactory.Create();

            QC = new QueryContainer(D3Context);

            TestCases = new Dictionary<string, TestCase>
            {
                {// IUserDomainService
                    QueryConstants.UserIdNoPassQuery,
                        new TestCase
                        {
                            Args = GetStringArrayArgs(false),
                            Name = QueryConstants.UserIdNoPassQuery,
                            MockService = QC.CreateQueryParamized(D3Specification.Create<User>(D3Context).ExcludeSelectPropMasks("Password*"), QC.GetUserIdFilterQuery(1, null))
                        }
                },
                {// IMatchDomainService
                    QueryConstants.InsertMatchQuery,
                        new TestCase
                        {
                            Args = new object?[] { D3Context, MockData.NewMatch },
                            Name = QueryConstants.InsertMatchQuery,
                            Function = GetInsertScript<Match>(),
                            MockService = null
                        }
                },
                {// ITournamentPlayerStatDomainService
                    QueryConstants.TournamentPlayerStatCoreGetStatsQuery,
                    new TestCase
                        {
                            Args = GetStringArrayArgs(false),
                            Name = QueryConstants.TournamentPlayerStatCoreGetStatsQuery,
                            MockService = QC.GetTourPlayerStatBaseFilterQuery(1, 1)
                        }
                },
                {// ITeamDomainService
                    QueryConstants.TournamentTeamGetBasicGroupStatsQuery,
                    new TestCase
                    {
                            Args = GetStringArrayArgs(false),
                            Name = QueryConstants.TournamentTeamGetBasicGroupStatsQuery,
                            MockService = QC.GetTournamentTeamsSortedByStatsQuery(1, 0)
                    }
                },
                {// Playoff
                    QueryConstants.PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQuery,
                    new TestCase
                    {
                        Args = GetStringArrayArgs(true),
                        Name = QueryConstants.PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQuery,
                        MockService = QC.CreateQueryParamized(D3Specification.RemoveSortItem(QC.GetPlayoffRoundCoupleBaseFilterQuery(1, null), (MatchSetScore x) => x.SetOrder).And(D3Specification.Create<Match>(D3Context).Compare(x => x.HomeTeamId, ComparisonOp.EQUALS, 1).And(D3Specification.Create<MatchSetScore>(D3Context).Sum(3, false, y => y.AwayTeamScore).Sum(2, false, x => x.HomeTeamScore).Avg(0, false, x => x.HomeTeamScore, y => y.AwayTeamScore).Min(0, false, x => x.HomeTeamScore, y => y.AwayTeamScore).Max(0, false, x => x.HomeTeamScore, y => y.AwayTeamScore))
                            .CountChild<PlayoffRoundCouple, Match>(x => x.Matches)
                            .CountChild((Match x) => x.MatchSetScores, 1, false, (MatchSetScore y) => y.MatchSetScoreId)
                            .IncludeSelectProps((PlayoffRoundCouple x) => x.Matches)), QC.GetTournamentTeamFilterQuery(null, 1))
                    }
                },
                {// Inverse Root DTO
                    QueryConstants.MatchSetScoreDifferenceQuerySkipAndTakeAsDTO,
                    new TestCase
                    {
                        Args = GetStringArrayArgs(true),
                        Name = QueryConstants.MatchSetScoreDifferenceQuerySkipAndTakeAsDTO,
                        MockService = new D3SpecificationWithParams<DTOs.Entities.MatchDTO>(
                            D3Specification.Create<MatchSetScore, Match>(D3Context, x => x.MatchSetScores, x => x.MatchId)
                                .And(D3Specification.Create<MatchSetScore>(D3Context)
                                    .CompareFormat(x => x.LastChange, ComparisonOp.GREATER_THAN_OR_EQUAL, 0)
                                    .CustomAggFunc(
                                        nameof(Mocks.DTOs.Entities.MatchSetScoreDTO.ScoreDifference),
                                        ComputeType.Sum,
                                        x => x.HomeTeamScore,
                                        CrossColumnOp.CaseWhenThenElseGreaterThanOrEquals,
                                        x => x.AwayTeamScore,
                                        x => x.HomeTeamScore,
                                        x => x.AwayTeamScore,
                                        CrossColumnOp.DiffOrNone,
                                        placeParentheses: true,
                                        prop3: x => x.HomeTeamScore,
                                        op3: CrossColumnOp.CaseWhenThenElseLessThan,
                                        prop4: x => x.AwayTeamScore,
                                        x => x.HomeTeamScore,
                                        x => x.AwayTeamScore,
                                        propertySortOrder: 1,
                                        includeAllPropsByDefault: true))
                                .AsDTO(new Tuple<Expression<Func<Match, object?>>, Expression<Func<DTOs.Entities.MatchDTO, object?>>>(x => x.WinnerId, y => y.WinnerIdTest)))
                        {
                            Parameters = new Dictionary<int, object?> { { 0, new DateTime(2022, 3, 22) } }
                        }
                    }
                },
                {// Unions
                    QueryConstants.UnionsMAtchesWonAsHomeUnionAsAwayDataSkipAndTakeQuery,
                    new TestCase
                    {
                        Args = GetStringArrayArgs(true),
                        Name = QueryConstants.UnionsMAtchesWonAsHomeUnionAsAwayDataSkipAndTakeQuery,
                        MockService = new D3SpecificationWithParams<PlayoffRoundCouple>(D3Specification.Create<PlayoffRoundCouple>(D3Context)
                        // won home matches
                        .And(D3Specification.Create<Match>(D3Context).Compare(x => x.HomeTeamId, ComparisonOp.EQUALS, 1).Compare(x => x.WinnerId, ComparisonOp.EQUALS, 1))
                        // won away matches
                        .Union(D3Specification.Create<PlayoffRoundCouple>(D3Context).And(D3Specification.Create<Match>(D3Context).Compare(x => x.AwayTeamId, ComparisonOp.EQUALS, 1).Compare(x => x.WinnerId, ComparisonOp.EQUALS, 1)), true)
                        // all matches
                        .Union(D3Specification.Create<PlayoffRoundCouple>(D3Context).And(D3Specification.Create<Match>(D3Context).Compare(x => x.HomeTeamId, ComparisonOp.EQUALS, 1).Compare(x => x.AwayTeamId, ComparisonOp.EQUALS, 1, LogicalOp.OR))/*, not necessary true*/))
                    }
                },
                {//Bulk Operations
                    QueryConstants.BulkUpdateQuery,
                        new TestCase
                        {
                            Args = new object [] { D3Context, D3Specification.Create<Team>(D3Context).Compare(x => x.RegistrationDate, ComparisonOp.LESS_THAN_OR_EQUAL, new DateTime(2022, 8, 3).AddYears(-10)), new Tuple<LambdaExpression, object?>[] { new Tuple<LambdaExpression, object?>((LambdaExpression)((Team x) => x.IsActive), false) } },
                            Name = QueryConstants.BulkUpdateQuery,
                            Function = GetBulkUpdateScript<Team>(),
                            MockService = null
                        }
                }
            };

            foreach (var testCase in TestCases)
            {
                switch (databaseType)
                {
                    case DatabaseType.MySQL:
                        testCase.Value.ExpectedResult = typeof(MySQLQueries).GetField(testCase.Value.Name, BindingFlags.Public | BindingFlags.Static)?.GetValue(null);
                        break;
                    case DatabaseType.SQLite:
                        testCase.Value.ExpectedResult = typeof(SQLiteQueries).GetField(testCase.Value.Name, BindingFlags.Public | BindingFlags.Static)?.GetValue(null);
                        break;
                    case DatabaseType.MSSQL:
                        testCase.Value.ExpectedResult = typeof(MSSQLQueries).GetField(testCase.Value.Name, BindingFlags.Public | BindingFlags.Static)?.GetValue(null);
                        break;
                    default:
                        throw Extensions.UnexpectedDatabaseType(databaseType.ToString());
                }

                if (testCase.Value.Function == null)
                {
                    testCase.Value.Function = typeof(D3Specification).GetMethod(nameof(D3Specification.BuildSQL));
                }
            }
        }

        public void TestQuery(string name)
        {
            if (TestCases.TryGetValue(name, out TestCase? testCase))
            {
                Assert.IsNotNull(testCase.Function);

                string result;

                if (testCase.Function.Name == nameof(D3Specification.BuildSQL))
                {
                    if (testCase.MockService is not ISpecificationWithParams spec)
                    {
                        Assert.Fail($"BuildSQL() not possible, because the test case {name} is not of type {nameof(ISpecificationWithParams)}");
                        return;
                    }

                    result = D3Specification.BuildSQL(spec, testCase.Args.ElementAtOrDefault(0)?.Equals(true) ?? false, true, spec.Parameters).FullSQL;
                }
                else
                {
                    result = testCase.Function?.Invoke(null, testCase.Args.ToArray())?.ToString() ?? "error";
                }

                Assertion.AssertStrings(testCase.ExpectedResult?.ToString(), result, testCase.Name);
            }
            else
            {
                Assert.Fail($"Test case {name} not found.");
            }
        }
    }
}
