﻿using KLO128.D3ORM.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application.MySQL
{
    [TestClass]
    public class PlayerWebServiceTest : PlayerWebServiceTestBase
    {
        public PlayerWebServiceTest() : base(DatabaseType.MySQL)
        {
        }
    }
}
