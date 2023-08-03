using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application
{
    public abstract class MatchWebServiceTestBase
    {
        public MatchWebServiceTestBase(DatabaseType databaseType)
        {
            ServiceConfig.InjectAll(databaseType);
        }

        [TestMethod]
        [DataRow(1, 2, 1)]
        [DataRow(null, 2, 1)]
        public void MatchWebService_AddMatch(int? tournamentId, int homeTeamId, int awayTeamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () => ServiceConfig.MatchWebService(scope).AddMatch(new AddMatchArgs
                {
                    HomeTeamId = homeTeamId,
                    AwayTeamId = awayTeamId,
                    TournamentId = tournamentId
                }, 1, false));

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(tournamentId, result.Result.TournamentId);
                Assert.AreEqual(homeTeamId, result.Result.HomeTeamId);
                Assert.AreEqual(awayTeamId, result.Result.AwayTeamId);
            }
        }

        [TestMethod]
        [DataRow(2, 5, 1)]
        [DataRow(2, 2, 1)]
        [DataRow(3, 2, 1)]
        [DataRow(1, 4, 1)]
        public void MatchWebService_AddMatch_Fail(int? tournamentId, int homeTeamId, int awayTeamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () => ServiceConfig.MatchWebService(scope).AddMatch(new AddMatchArgs
                {
                    HomeTeamId = homeTeamId,
                    AwayTeamId = awayTeamId,
                    TournamentId = tournamentId
                }, 1, false));

                Assert.IsFalse(result.Succeeded);

                if (homeTeamId > QueryConstants.LastTeamId || awayTeamId > QueryConstants.LastTeamId)
                {
                    Assert.AreEqual(nameof(Translations.err004), result.Error?.ErrCode);
                }
                else if (tournamentId == QueryConstants.EmptyTournamentId || homeTeamId > QueryConstants.LastTournamentTeamId || awayTeamId > QueryConstants.LastTournamentTeamId)
                {
                    Assert.AreEqual(nameof(Translations.err011), result.Error?.ErrCode);
                }
                else
                {
                    Assert.AreEqual(nameof(Translations.err007), result.Error?.ErrCode);
                }
            }
        }

        [TestMethod]
        [DataRow(1, 25, 19)]
        public void MatchWebService_AddMatchSetScore(int matchId, int homeTeamScore, int awayTeamScore)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () => ServiceConfig.MatchWebService(scope).AddMatchSetScore(new AddMatchSetScoreArgs
                {
                    MatchId = matchId,
                    HomeTeamScore = homeTeamScore,
                    AwayTeamScore = awayTeamScore,
                    SetOrder = 4
                }, 1, false));

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);

                var lastSet = result.Result.MatchSetScores.LastOrDefault();

                Assert.IsNotNull(lastSet);

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(matchId, result.Result.MatchId);
                Assert.AreEqual(4, lastSet.SetOrder);
                Assert.AreEqual(homeTeamScore, lastSet.HomeTeamScore);
                Assert.AreEqual(awayTeamScore, lastSet.AwayTeamScore);
            }
        }

        [TestMethod]
        [DataRow(5, 25, 19)]
        public void MatchWebService_AddMatchSetScore_Fail(int matchId, int homeTeamScore, int awayTeamScore)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () => ServiceConfig.MatchWebService(scope).AddMatchSetScore(new AddMatchSetScoreArgs
                {
                    MatchId = matchId,
                    HomeTeamScore = homeTeamScore,
                    AwayTeamScore = awayTeamScore,
                    SetOrder = 4
                }, 1, false));

                Assert.IsFalse(result.Succeeded);
                Assert.AreEqual(nameof(Translations.err008), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow(1, 25, 19)]
        public void MatchWebService_UpdateMatchSetScore_ThenEndMatch(int matchId, int homeTeamScore, int awayTeamScore)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var qc = ServiceConfig.QC(scope);
                var match = ServiceConfig.MatchRepository(scope).FindBy(qc.GetMatchIdBaseFilterQuery(matchId));

                Assert.IsNotNull(match);

                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var ret = new ServiceResult<List<MatchSetScoreDTO>>
                    {
                        Result = new List<MatchSetScoreDTO>()
                    };

                    foreach (var set in match.MatchSetScores)
                    {
                        var setResult = ServiceConfig.MatchWebService(scope).UpdateMatchSetScoreUnsafe(new UpdateMatchSetScoreArgs
                        {
                            MatchId = matchId,
                            HomeTeamScore = homeTeamScore,
                            AwayTeamScore = awayTeamScore,
                            SetOrder = set.SetOrder
                        }, 1, false).MatchSetScores.FirstOrDefault(x => x.SetOrder == set.SetOrder);

                        if (setResult != null)
                        {
                            ret.Result.Add(setResult);
                        }
                    }

                    var originalPoints = ServiceConfig.TeamRepository(scope).FindBy(qc.GetTeamIdBaseFilterQuery(match?.HomeTeamId))?.TournamentTeams.FirstOrDefault(x => x.TournamentId == match?.TournamentId)?.TournamentTeamStats.FirstOrDefault(x => x.TournamentPhase == 0)?.PhasePoints ?? 0;

                    var result = ServiceConfig.MatchWebService(scope).EndMatchUnsafe(new EndMatchArgs
                    {
                        MatchId = matchId
                    }, 1, false);

                    var updatedPoints = ServiceConfig.TeamRepository(scope).FindBy(qc.GetTeamIdBaseFilterQuery(match?.HomeTeamId))?.TournamentTeams.FirstOrDefault(x => x.TournamentId == match?.TournamentId)?.TournamentTeamStats.FirstOrDefault(x => x.TournamentPhase == 0)?.PhasePoints ?? 0;

                    Assert.AreEqual(updatedPoints, originalPoints + (homeTeamScore > awayTeamScore ? 3 : awayTeamScore > homeTeamScore ? 0 : 2));

                    return new ServiceResult<MatchDTO>(result);
                });

                foreach (var set in match.MatchSetScores)
                {
                    var setResult = result.Result?.MatchSetScores.FirstOrDefault(x => x.SetOrder == set.SetOrder);

                    Assert.IsNotNull(setResult);
                    Assert.AreEqual(set.MatchId, setResult.MatchId);
                    // Assert.AreEqual(set.SetOrder, setResult.SetOrder);
                    Assert.AreEqual(homeTeamScore, setResult.HomeTeamScore);
                    Assert.AreEqual(awayTeamScore, setResult.AwayTeamScore);
                }
            }
        }

        [TestMethod]
        public void MatchWebService_GetMatches()
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                TestData.InitData(scope);

                var result = ServiceConfig.MatchWebService(scope).GetMatches(1, null, null);
                var expectedMatches = TestData.StaticData.MatchesAgregates;

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);

                foreach (var match in result.Result)
                {
                    var expected = expectedMatches.FirstOrDefault(x => x.MatchId == match.MatchId)?.ToDTO<MatchDTO>();

                    Assertion.AssertObj(expected, match, new List<PropertyInfo?>(), nameof(MatchWebService_GetMatches));
                }
            }
        }

        [TestMethod]
        public void MatchWebService_GetMatches_EmptyResult()
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.MatchWebService(scope).GetMatches(2, null, null);

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(0, result.Result.Count);
            }
        }

        [TestMethod]
        public void MatchWebService_GetMatches_EmptyFilterFail()
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.MatchWebService(scope).GetMatches(null, null, 0);

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.err009), result.Error?.ErrCode);
            }
        }
    }
}
