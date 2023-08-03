using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Domain
{
    public abstract class MatchDomainServiceTestBase
    {
        public MatchDomainServiceTestBase(DatabaseType databaseType)
        {
            ServiceConfig.InjectAll(databaseType);
        }

        [TestInitialize]
        public void InitData()
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                TestData.InitData(scope);
            }
        }

        [TestMethod]
        [DataRow(1, 3, 1, 0, 1)]
        [DataRow(1, 4, null, 0, 2)]
        [DataRow(2, 1, 1, 2, 1)]
        public void MatchDomainService_AddMatch(int homeTeamId, int awayTeamId, int? tournamentId, int tournamentPhase, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var match = ServiceConfig.MatchDomainService(scope).AddMatch(homeTeamId, awayTeamId, tournamentId, tournamentPhase, changedBy);

                    return new ServiceResult<Match>(match);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(result.Result.HomeTeamId, homeTeamId);
                Assert.AreEqual(result.Result.AwayTeamId, awayTeamId);
                Assert.AreEqual(result.Result.TournamentId, tournamentId);
                Assert.AreEqual(result.Result.TournamentPhase, tournamentPhase);
                Assert.AreEqual(result.Result.ChangedBy, changedBy);
            }
        }

        [TestMethod]
        [DataRow(1, 3, 2, 0, 1)]
        public void MatchDomainService_AddMatch_Fail(int homeTeamId, int awayTeamId, int? tournamentId, int tournamentPhase, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var match = ServiceConfig.MatchDomainService(scope).AddMatch(homeTeamId, awayTeamId, tournamentId, tournamentPhase, changedBy);

                    return new ServiceResult<Match>(match);
                });

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.err011), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow(1, 4, 25, 19, 1)]
        [DataRow(2, 5, 19, 25, 1)]
        public void MatchDomainService_AddMatchScore(int matchId, int setOrder, int homeTeamScore, int awayTeamScore, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var match = ServiceConfig.MatchRepository(scope).FindByIdSingle(matchId);

                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {


                    Assert.IsNotNull(match);

                    var result = ServiceConfig.MatchDomainService(scope).AddMatchSetScore(match, setOrder, homeTeamScore, awayTeamScore, changedBy);




                    return new ServiceResult<Match>(result);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assertion.AssertObj(match, result.Result, new List<System.Reflection.PropertyInfo?> { typeof(Match).GetProperty(nameof(Match.HomeTeam))!, typeof(Match).GetProperty(nameof(Match.AwayTeam))!, typeof(Match).GetProperty(nameof(Match.MatchSetScores))! });

                var score = result.Result.MatchSetScores.LastOrDefault();

                Assert.IsNotNull(score);
                Assert.AreNotEqual(0, score.MatchSetScoreId);
                Assert.AreEqual(homeTeamScore, score.HomeTeamScore);
                Assert.AreEqual(awayTeamScore, score.AwayTeamScore);
            }
        }

        [TestMethod]
        [DataRow(1, 1, 25, 19, 1)]
        [DataRow(2, 1, 19, 25, 1)]
        public void MatchDomainService_UpdateMatchScore(int matchId, int setOrder, int homeTeamScore, int awayTeamScore, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var match = ServiceConfig.MatchRepository(scope).FindByIdSingle(matchId);

                    Assert.IsNotNull(match);

                    var result = ServiceConfig.MatchDomainService(scope).UpdateMatchSetScore(match, setOrder, homeTeamScore, awayTeamScore, changedBy);

                    Assert.IsNotNull(result);

                    var setScore = result.MatchSetScores.FirstOrDefault(x => x.SetOrder == setOrder);
                    Assert.IsNotNull(setScore);

                    ServiceConfig.MatchSetScoreRepository(scope).UpdateEntity(setScore);    // only to test all variants of UpdateSingle

                    awayTeamScore++;
                    ServiceConfig.MatchSetScoreRepository(scope).UpdateProperties(setScore, x => x.AwayTeamScore, awayTeamScore);    // only to test all variants of UpdateSingle

                    Assertion.AssertObj(match, result, new List<System.Reflection.PropertyInfo?> { typeof(Match).GetProperty(nameof(Match.HomeTeam))!, typeof(Match).GetProperty(nameof(Match.AwayTeam))!, typeof(Match).GetProperty(nameof(Match.MatchSetScores))! });

                    return new ServiceResult<object>();
                });
            }
        }

        [TestMethod]
        [DataRow(1, null, null)]
        [DataRow(1, 2, 0)]
        [DataRow(1, 1, 1)]
        public void MatchDomainService_GetMatches(int tournamentId, int? teamId, int? tournamentPhase)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var matches = ServiceConfig.MatchDomainService(scope).GetMatches(tournamentId, teamId, tournamentPhase);

                Assert.IsNotNull(matches);

                var filteredExpected = TestData.StaticData.MatchesAgregates.Where(x => x.TournamentId == tournamentId && (teamId == null || x.HomeTeamId == teamId || x.AwayTeamId == teamId) && (tournamentPhase == null || x.TournamentPhase == tournamentPhase)).ToList();

                for (int i = 0; i < matches.Count; i++)
                {
                    var match = matches[i];
                    var expected = filteredExpected.FirstOrDefault(x => x.MatchId == match.MatchId);

                    Assert.IsNotNull(match);
                    Assertion.AssertObj(expected, match, new List<System.Reflection.PropertyInfo?> { typeof(Match).GetProperty(nameof(Match.MatchSetScores))! });
                }
            }
        }
    }
}
