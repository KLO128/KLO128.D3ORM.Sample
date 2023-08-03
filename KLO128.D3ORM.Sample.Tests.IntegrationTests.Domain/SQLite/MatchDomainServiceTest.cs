using KLO128.D3ORM.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Domain.SQLite
{
    [TestClass]
    public class MatchDomainServiceTest : MatchDomainServiceTestBase
    {
        public MatchDomainServiceTest() : base(DatabaseType.SQLite)
        {
        }
    }
}
