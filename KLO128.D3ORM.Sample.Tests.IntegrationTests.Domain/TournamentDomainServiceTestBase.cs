using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Domain.Shared.Models;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Domain
{
    //[TestClass]
    public abstract class TournamentDomainServiceTestBase
    {
        public TournamentDomainServiceTestBase(DatabaseType databaseType)
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
        [DataRow("NewTournament", 1000, 32, 0, 1, 1)]
        public void TournamentDomainService_CreateTournament(string tournamentName, int entryFee, int maxNumOfTeams, int tourSerieId, int addressId, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var tournament = ServiceConfig.TournamentDomainService(scope).CreateTournament(tournamentName, entryFee, maxNumOfTeams, tourSerieId, addressId, changedBy, DateTime.Today, DateTime.Today);

                    return new ServiceResult<Tournament>(tournament);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreNotEqual(0, result.Result.TournamentId);
                Assert.AreEqual("NewTournament", result.Result.Name);
                Assert.AreEqual(1000, result.Result.EntryFee);
            }
        }

        [TestMethod]
        [DataRow(1, null, null)]
        [DataRow(1, null, 2)]
        [DataRow(1, 0, 2)]
        public void TournamentDomainService_GetMatches(int? tournamentId, int? tournamentPhase, int? teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var matches = ServiceConfig.TournamentDomainService(scope).GetMatches(tournamentId, tournamentPhase, teamId);

                Assert.IsNotNull(matches);

                var expectedList = TestData.StaticData.TournamentAggregates.FirstOrDefault(x => tournamentId == null || x.TournamentId == tournamentId)?.Matches.Where(x => (teamId == null || x.HomeTeamId == teamId || x.AwayTeamId == teamId) && (tournamentPhase == null || x.TournamentPhase == tournamentPhase)) ?? new List<Match>();

                foreach (var item in matches)
                {
                    var expectedItem = expectedList.FirstOrDefault(x => x.MatchId == item.MatchId);

                    Assertion.AssertObj(expectedItem, item, ServiceConfig.QC(scope).MatchBaseQuery.TryGetAggregates());
                }
            }
        }

        [TestMethod]
        public void TournamentDomainService_GetMatches_EmptyFilter()
        {
            try
            {
                using (var scope = ServiceConfig.CreateScope())
                {
                    var team = ServiceConfig.TournamentDomainService(scope).GetMatches(null, null, null);

                    Assert.Fail("Empty Filter - test should fail");
                }
            }
            catch (Error err)
            {
                Assert.AreEqual(nameof(Translations.err009), err.ErrCode);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }

        [TestMethod]
        [DataRow(4, 1, 1)]
        [DataRow(1, 2, 1)]
        public void TournamentDomainService_SignUpTeam(int teamId, int tournamentId, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                Assert.IsNotNull(TestData.StaticData.TournamentAggregates.FirstOrDefault(x => x.TournamentId == tournamentId));
                Assert.IsNotNull(TestData.StaticData.TeamAggregates.FirstOrDefault(x => x.TeamId == teamId));

                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var tournamentTeam = ServiceConfig.TournamentDomainService(scope).CreateTournamentTeam(teamId, tournamentId, changedBy);

                    return new ServiceResult<TournamentTeam>(tournamentTeam);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.IsNotNull(result.Result);
                Assert.AreNotEqual(0, result.Result.TournamentTeamId);
                Assert.AreEqual(teamId, result.Result.TeamId);
                Assert.AreEqual(tournamentId, result.Result.TournamentId);
                Assert.AreEqual(changedBy, result.Result.ChangedBy);
            }
        }

        [TestMethod]
        [DataRow(3, 2, 1)]
        [DataRow(1, 2, 1)]
        [DataRow(2, 5, 1)]
        public void TournamentDomainService_SignUpTeam_Fail(int tournamentId, int teamId, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var tournamentTeam = ServiceConfig.TournamentDomainService(scope).CreateTournamentTeam(teamId, tournamentId, changedBy);

                    return new ServiceResult<TournamentTeam>(tournamentTeam);
                });

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                if (tournamentId > QueryConstants.LastTournamentId)
                {
                    Assert.AreEqual(nameof(Translations.err007), result.Error?.ErrCode);
                }
                else if (TestData.StaticData.TournamentAggregates.FirstOrDefault(x => x.TournamentId == tournamentId) != null && TestData.StaticData.TeamAggregates.FirstOrDefault(x => x.TeamId == teamId) != null)
                {
                    Assert.AreEqual(nameof(Translations.err012), result.Error?.ErrCode);
                }
                else
                {
                    Assert.AreEqual(nameof(Translations.err004), result.Error?.ErrCode);
                }
            }
        }
    }
}
