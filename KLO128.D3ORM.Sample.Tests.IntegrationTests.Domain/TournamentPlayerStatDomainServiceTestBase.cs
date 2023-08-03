using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Domain.Shared.Models;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Domain
{
    public abstract class TournamentPlayerStatDomainServiceTestBase
    {
        public TournamentPlayerStatDomainServiceTestBase(DatabaseType databaseType)
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
        [DataRow(1, 1)]
        [DataRow(1, null)]
        [DataRow(null, 1)]
        public void TournamentPlayerStatDomainService_GetPlayerStats(int? playerId, int? tournamentId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var tournament = TestData.StaticData.TournamentAggregates.First();
                var expectedPlayerStats = TestData.StaticData.PlayerStatAggregates.FindAll(x => (tournamentId == null || x.TournamentId == tournament.TournamentId) && (playerId == null || x.PlayerId == playerId));

                var playerStats = ServiceConfig.TournamentPlayerStatDomainService(scope).GetPlayerStats(playerId, tournamentId);

                Assert.IsNotNull(playerStats);
                Assert.AreEqual(expectedPlayerStats.Count, playerStats.Count);

                for (int i = 0; i < expectedPlayerStats.Count; i++)
                {
                    var expected = expectedPlayerStats[i];
                    var realPlayer = playerStats.Find(x => x.PlayerId == expected.PlayerId);

                    Assert.IsNotNull(realPlayer);

                    Assertion.AssertObj(expected, realPlayer, ServiceConfig.QC(scope).GetTourPlayerStatBaseFilterQuery(null, null).TryGetAggregates());
                }
            }
        }

        [TestMethod]
        public void TournamentPlayerStatDomainService_GetPlayerStats_EmptyFilter()
        {
            try
            {
                using (var scope = ServiceConfig.CreateScope())
                {
                    var team = ServiceConfig.TournamentPlayerStatDomainService(scope).GetPlayerStats(null, null);

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
    }
}
