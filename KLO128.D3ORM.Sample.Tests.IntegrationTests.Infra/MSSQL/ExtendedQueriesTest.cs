﻿using KLO128.D3ORM.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Infra.MSSQL
{
    [TestClass]
    public class ExtendedQueriesTest : ExtendedQueriesTestBase
    {
        public ExtendedQueriesTest() : base(DatabaseType.MSSQL)
        {
        }
    }
}
