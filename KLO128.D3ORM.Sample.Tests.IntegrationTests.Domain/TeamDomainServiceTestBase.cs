using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Domain.Shared.Models;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Domain
{
    //[TestClass]
    public abstract class TeamDomainServiceTestBase
    {
        public TeamDomainServiceTestBase(DatabaseType databaseType)
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
        [DataRow("AddedTeam", 3)]
        public void TeamDomainService_Create_Delete_Team(string name, int changedById)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var qc = ServiceConfig.QC(scope);
                    var team = ServiceConfig.TeamDomainService(scope).CreateTeam(name, changedById);
                    ServiceConfig.TeamRepository(scope).DeleteRoot(team);

                    if (ServiceConfig.TeamRepository(scope).FindBy(qc.GetTeamIdFilterQuery(team.TeamId)) is Team)
                    {
                        Assert.Fail("Could not delete team. Id: " + team.TeamId);
                    }

                    return new ServiceResult<Team>(team);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.IsTrue(result.Result.TeamId > QueryConstants.LastTeamId);
                Assert.AreEqual(result.Result.Name, name);
                Assert.AreEqual(result.Result.ChangedBy, changedById);
            }
        }

        [TestMethod]
        [DataRow(4, 7, 7)]
        [DataRow(3, 2, 7)]
        public void TeamDomainService_Add_RemovePlayer(int teamId, int playerId, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var addPlayerResult = AddTeamPlayer(scope, teamId, playerId, changedBy);

                    Assert.IsTrue(ServiceConfig.TeamDomainService(scope).RemovePlayer(addPlayerResult.Team.TeamId, addPlayerResult.PlayerId, 1));

                    Assert.IsNull(ServiceConfig.TeamPlayerRepository(scope).FindByIdSingle(addPlayerResult.TeamPlayerId));

                    return new ServiceResult<object>();
                });
            }
        }

        [TestMethod]
        [DataRow(3, 6, 6)]
        [DataRow(1, 2, 2)]
        public void TeamDomainService_Add_RemovePlayer_Fail(int teamId, int playerId, int changedBy)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var addPlayerResult = AddTeamPlayer(scope, teamId, playerId, changedBy);

                    return new ServiceResult<Team>(addPlayerResult?.Team);
                });

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.warn001), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void TeamDomainService_GetTeamData(int teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var expectedTeam = TestData.StaticData.TeamAggregates.Find(x => x.TeamId == teamId);

                var team = ServiceConfig.TeamDomainService(scope).GetTeamData(teamId);

                Assert.IsNotNull(team);

                Assertion.AssertObj(expectedTeam, team, ServiceConfig.QC(scope).TeamBaseQuery.TryGetAggregates());
            }
        }

        [TestMethod]
        [DataRow(10)]
        public void TeamDomainService_GetTeamData_Fail(int teamId)
        {
            try
            {
                using (var scope = ServiceConfig.CreateScope())
                {
                    var team = ServiceConfig.TeamDomainService(scope).GetTeamData(teamId);

                    Assert.Fail("Team not found - test should fail");
                }
            }
            catch (Error err)
            {
                Assert.AreEqual(nameof(Translations.err004), err.ErrCode);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1, null)]
        [DataRow(null, 1)]
        public void TeamDomainService_GetTeamStats(int? teamId, int? tournamentId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var teamsStats = ServiceConfig.TeamDomainService(scope).GetTeamStats(teamId, tournamentId);

                Assert.IsNotNull(teamsStats);

                var expectedList = TestData.StaticData.TournamentAggregates.First(x => tournamentId == null || x.TournamentId == tournamentId).TournamentTeams.Where(x => teamId == null || x.TeamId == teamId);

                foreach (var item in teamsStats)
                {
                    var expectedItem = expectedList.FirstOrDefault(x => x.TournamentTeamId == item.TournamentTeamId);
                    Assertion.AssertObj(expectedItem, item, ServiceConfig.QC(scope).TeamBaseQuery.TryGetAggregates());
                }
            }
        }

        [TestMethod]
        public void TeamDomainService_GetTeamStats_EmptyFilter()
        {
            try
            {
                using (var scope = ServiceConfig.CreateScope())
                {
                    var team = ServiceConfig.TeamDomainService(scope).GetTeamStats(null, null);

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

        private AddPlayerResult AddTeamPlayer(IServiceScope scope, int teamId, int playerId, int changedById)
        {
            var team = ServiceConfig.TeamDomainService(scope).AddPlayer(teamId, playerId, changedById);
            var teamPlayer = team.TeamPlayers.LastOrDefault();

            Assert.IsNotNull(team);
            Assert.IsNotNull(teamPlayer);
            Assert.AreNotEqual(0, teamPlayer.TeamPlayerId);
            Assert.AreEqual(teamId, team.TeamId);
            Assert.AreEqual(playerId, teamPlayer.PlayerId);

            return new AddPlayerResult
            {
                PlayerId = playerId,
                Team = team,
                TeamPlayerId = teamPlayer.TeamPlayerId
            };
        }

        private TeamPlayer? FindPlayerInTeam(Team team, int playerId)
        {
            return team.TeamPlayers.FirstOrDefault(x => x.PlayerId == playerId);
        }

        private class AddPlayerResult
        {
            public int PlayerId { get; set; }

            public int TeamPlayerId { get; set; }

            public Team Team { get; set; } = null!;
        }
    }
}
