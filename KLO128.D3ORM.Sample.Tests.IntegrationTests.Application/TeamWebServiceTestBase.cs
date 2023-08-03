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

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application
{
    public abstract class TeamWebServiceTestBase
    {
        public TeamWebServiceTestBase(DatabaseType databaseType)
        {
            ServiceConfig.InjectAll(databaseType);
        }

        [TestMethod]
        [DataRow("MockTeam", 1)]
        [DataRow("MockTeam2", 2)]
        public void TeamWebService_CreateTeam(string name, int userId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var result = ServiceConfig.TeamWebService(scope).CreateTeamUnsafe(new CreateTeamArgs
                    {
                        Name = name
                    }, userId);

                    Assert.IsTrue(ServiceConfig.UserDomainService(scope).FindUser(userId, true)?.UserRoles.Any(x => x.TeamIdOrDefault == result.TeamId && x.RoleId == (int)Roles.TeamAdmin));

                    return new ServiceResult<TeamDTO>
                    {
                        Result = result
                    };
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreNotEqual(0, result.Result.TeamId);
                Assert.AreEqual(name, result.Result.Name);
                Assert.AreEqual(userId, result.Result.ChangedBy);
            }
        }

        [TestMethod]
        [DataRow(1, 3)]
        public void TeamWebService_AddPlayer(int playerId, int teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {


                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var result = ServiceConfig.TeamWebService(scope).AddPlayerUnsafe(new AddPlayerArgs
                    {
                        PlayerId = playerId,
                        TeamId = teamId
                    }, 1, false);

                    return new ServiceResult<TeamDTO>(result);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);

                var teamPlayer = result.Result.TeamPlayers.FirstOrDefault(x => x.PlayerId == playerId);

                Assert.IsNotNull(teamPlayer);
                Assert.AreNotEqual(0, teamPlayer.TeamPlayerId);
                Assert.AreEqual(teamPlayer.TeamId, teamPlayer.TeamId);
            }
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 5)]
        [DataRow(8, 2)]
        [DataRow(8, 5)]
        public void TeamWebService_AddPlayer_Fail(int playerId, int teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var result = ServiceConfig.TeamWebService(scope).AddPlayerUnsafe(new AddPlayerArgs
                    {
                        PlayerId = playerId,
                        TeamId = teamId
                    }, 1, false);

                    return new ServiceResult<TeamDTO>(result);
                });

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);

                if (teamId > QueryConstants.LastTeamId)
                {
                    Assert.AreEqual(nameof(Translations.err004), result.Error?.ErrCode);
                }
                else if (playerId > QueryConstants.LastPlayerId)
                {
                    Assert.AreEqual(nameof(Translations.err002), result.Error?.ErrCode);
                }
                else
                {
                    Assert.AreEqual(nameof(Translations.warn001), result.Error?.ErrCode);
                }
            }
        }

        [TestMethod]
        [DataRow(1, 1)]
        public void TeamWebService_RemovePlayer(int playerId, int teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var result = ServiceConfig.TeamWebService(scope).RemovePlayerUnsafe(new RemovePlayerFromTeamArgs
                    {
                        PlayerId = playerId,
                        TeamId = teamId
                    }, 1, false);

                    return new ServiceResult<bool>(result);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsTrue(result.Result);
            }
        }

        [TestMethod]
        [DataRow(1, 3)]
        [DataRow(8, 3)]
        public void TeamWebService_RemovePlayer_Fail(int playerId, int teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var result = ServiceConfig.TeamWebService(scope).RemovePlayerUnsafe(new RemovePlayerFromTeamArgs
                    {
                        PlayerId = playerId,
                        TeamId = teamId
                    }, 1, false);

                    return new ServiceResult<bool>(result);
                });

                Assert.IsFalse(result.Succeeded);
                Assert.IsFalse(result.Result);
                Assert.AreEqual(nameof(Translations.err005), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow(1)]
        public void TeamWebService_GetTeamData(int teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                TestData.InitData(scope);

                var result = ServiceConfig.TeamWebService(scope).GetTeamData(teamId);

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);

                var expected = TestData.StaticData.TeamAggregates.Find(x => x.TeamId == teamId);

                Assert.IsNotNull(expected);

                Assert.AreEqual(expected.TeamId, result.Result.TeamId);
                Assert.AreEqual(expected.Name, result.Result.Name);
                Assert.AreEqual(expected.RegistrationDate, result.Result.RegistrationDate);
            }
        }

        [TestMethod]
        [DataRow(5)]
        public void TeamWebService_GetTeamData_Fail(int teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.TeamWebService(scope).GetTeamData(teamId);

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.err004), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1, null)]
        public void TeamWebService_GetTeamStats(int teamId, int? tournamentId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                TestData.InitData(scope);

                var result = ServiceConfig.TeamWebService(scope).GetTeamStats(teamId, tournamentId);

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);

                var expectedTeam = TestData.StaticData.TeamAggregates.Find(x => x.TeamId == teamId);

                Assert.IsNotNull(expectedTeam);

                foreach (var item in result.Result.Stats)
                {
                    var expectedTeamInTournament = expectedTeam.TournamentTeams.FirstOrDefault(x => x.TournamentTeamId == item.TournamentTeamId);

                    Assert.IsNotNull(expectedTeamInTournament);

                    foreach (var stat in item.TournamentTeamStats)
                    {
                        var expected = expectedTeamInTournament.TournamentTeamStats.FirstOrDefault(x => x.TournamentTeamStatId == stat.TournamentTeamStatId)?.ToDTO<TournamentTeamStatDTO>();

                        Assert.IsNotNull(expected);
                        Assertion.AssertObj(expected, stat, new List<System.Reflection.PropertyInfo?>(), nameof(TeamWebService_GetTeamStats));
                    }
                }
            }
        }

        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(5, 1)]
        [DataRow(5, null)]
        [DataRow(null, 2)]
        public void TeamWebService_GetTeamStats_EmptyResult(int? teamId, int? tournamentId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.TeamWebService(scope).GetTeamStats(teamId, tournamentId);

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(0, result.Result.Stats.Count);
            }
        }

        [TestMethod]
        public void TeamWebService_GetTeamStats_EmptyFilterFail()
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.TeamWebService(scope).GetTeamStats(null, null);

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.err009), result.Error?.ErrCode);
            }
        }
    }
}
