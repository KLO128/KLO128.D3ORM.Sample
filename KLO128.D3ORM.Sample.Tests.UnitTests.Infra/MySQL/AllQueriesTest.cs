using KLO128.D3ORM.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.MySQL
{
    [TestClass]
    public class AllQueriesTest : AllQueriesTestBase
    {
        public AllQueriesTest() : base(DatabaseType.MySQL)
        {
        }
    }
}
