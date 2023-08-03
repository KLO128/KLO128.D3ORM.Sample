using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra
{
    public abstract class AllQueriesTestBase
    {
        public QueryTestsHandler TestsHandler { get; set; }

        public AllQueriesTestBase(DatabaseType databaseType)
        {
            TestsHandler = new QueryTestsHandler(databaseType);
        }

        [TestMethod]
        //
        // This is only a taste of tests!!!...
        // And so on...
        //
        // IUserDomainService
        [DataRow(QueryConstants.UserIdNoPassQuery)]
        // IMatchDomainService
        [DataRow(QueryConstants.InsertMatchQuery)]
        // ITournamentPlayerStatDomainService
        [DataRow(QueryConstants.TournamentPlayerStatCoreGetStatsQuery)]
        // ITournamentDomainService
        [DataRow(QueryConstants.TournamentTeamGetBasicGroupStatsQuery)]
        // Playoff
        [DataRow(QueryConstants.MatchSetScoreDifferenceQuerySkipAndTakeAsDTO)]
        // Unions
        [DataRow(QueryConstants.UnionsMAtchesWonAsHomeUnionAsAwayDataSkipAndTakeQuery)]
        //Bulk
        [DataRow(QueryConstants.BulkUpdateQuery)]
        public void AllQueries_Generate(string testCaseName)
        {
            TestsHandler.TestQuery(testCaseName);
        }
    }
}
