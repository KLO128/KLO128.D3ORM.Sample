using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application
{
    public abstract class PlayerWebServiceTestBase
    {
        public PlayerWebServiceTestBase(DatabaseType databaseType)
        {
            ServiceConfig.InjectAll(databaseType);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(1, null)]
        [DataRow(null, 1)]
        public void PlayerWebService_GetPlayerStats(int? tournamentId, int? playerId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                TestData.InitData(scope);
                var result = ServiceConfig.PlayerWebService(scope).GetPlayerStats(tournamentId, playerId);

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);

                var expectedStats = TestData.StaticData.PlayerStatAggregates.Where(x => (playerId == null || x.PlayerId == playerId) && (tournamentId == null || x.TournamentId == tournamentId)).ToList();

                foreach (var item in result.Result.Stats)
                {
                    var expected = expectedStats.FirstOrDefault(x => x.TournamentPlayerStatId == item.TournamentPlayerStatId)?.ToDTO<TournamentPlayerStatDTO>();

                    Assert.IsNotNull(expected);
                    Assertion.AssertObj(expected, item, new List<System.Reflection.PropertyInfo?>(), nameof(PlayerWebService_GetPlayerStats));
                }
            }
        }

        [TestMethod]
        [DataRow(2, 1)]
        [DataRow(2, null)]
        [DataRow(1, 8)]
        [DataRow(null, 8)]
        public void PlayerWebService_GetPlayerStats_EmptyResult(int? tournamentId, int? playerId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                TestData.InitData(scope);
                var result = ServiceConfig.PlayerWebService(scope).GetPlayerStats(tournamentId, playerId);

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(0, result.Result.Stats.Count);
            }
        }

        public void PlayerWebService_GetPlayerStats_EmptyFilterFail()
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.PlayerWebService(scope).GetPlayerStats(null, null);

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.err009), result.Error?.ErrCode);
            }
        }
    }
}
