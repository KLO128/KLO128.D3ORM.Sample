﻿using KLO128.D3ORM.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application.MSSQL
{
    [TestClass]
    public class TeamWebServiceTest : TeamWebServiceTestBase
    {
        public TeamWebServiceTest() : base(DatabaseType.MSSQL)
        {
        }
    }
}
