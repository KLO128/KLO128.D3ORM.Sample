using KLO128.D3ORM.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Domain.SQLite
{
    [TestClass]
    public class TournamentDomainServiceTest : TournamentDomainServiceTestBase
    {
        public TournamentDomainServiceTest() : base(DatabaseType.SQLite)
        {
        }
    }
}
