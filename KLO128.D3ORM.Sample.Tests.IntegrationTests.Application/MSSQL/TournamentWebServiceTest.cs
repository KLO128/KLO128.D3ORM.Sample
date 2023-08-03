using KLO128.D3ORM.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application.MSSQL
{
    [TestClass]
    public class TournamentWebServiceTest : TournamentWebServiceTestBase
    {
        public TournamentWebServiceTest() : base(DatabaseType.MSSQL)
        {
        }
    }
}
