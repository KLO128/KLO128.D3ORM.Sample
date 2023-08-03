using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Domain.Shared.Models;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks;
using KLO128.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Domain
{
    public abstract class UserDomainServiceTestBase
    {
        public UserDomainServiceTestBase(DatabaseType databaseType)
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
        [DataRow("newplayer@email.com", "Test", "New", "Player", "male", 2002, 1, 1, "+420123456789", 1)]
        [DataRow("newplayer@email.com", "Test", "New", "Player", "female", 2007, 11, 1, null, 1)]
        public void UserDomainService_CreatePlayer(string email, string password, string firstName, string lastName, string gender, int yearOfBirth, int monthOfBirth, int dayOfBirth, string? phoneNumber, int roleId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var dateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);

                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {

                    var user = ServiceConfig.UserDomainService(scope).CreatePlayer(email, password, firstName, lastName, gender, dateOfBirth, phoneNumber, roleId);



                    return new ServiceResult<User>(user);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreNotEqual(0, result.Result.UserId);
                Assert.AreEqual(email, result.Result.Email);
                Assert.AreEqual(firstName, result.Result.FirstName);
                Assert.AreEqual(lastName, result.Result.LastName);
                Assert.AreEqual(gender, result.Result.Gender);
                Assert.AreEqual(dateOfBirth, result.Result.DateOfBirth);
                Assert.AreEqual(roleId, result.Result.UserRoles.FirstOrDefault()?.RoleId);
            }
        }

        [TestMethod]
        [DataRow(QueryConstants.player1Email)]
        public void UserDomainService_CreatePlayer_Fail(string email)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var user = ServiceConfig.UserDomainService(scope).CreatePlayer(email, "Test", "New", "Player", "male", new DateTime(2002, 1, 1), "+420123456789", 1);

                    return new ServiceResult<User>(user);
                });

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.err013), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow(3, 2)]
        [DataRow(1, null)]
        public void UserDomainService_FindUser_InTeam(int userId, int? teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var expected = TestData.StaticData.UserAggregates.Find(x => x.UserId == userId);

                if (teamId != null)
                {
                    Assert.IsNotNull(TestData.StaticData.TeamAggregates.Find(x => x.TeamId == teamId)?.TeamPlayers.FirstOrDefault(x => x.PlayerId == userId));
                }

                var user = ServiceConfig.UserDomainService(scope).FindUser(userId, teamId);

                Assertion.AssertObj(expected, user, new List<System.Reflection.PropertyInfo?>());
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void UserDomainService_FindUser_ById(int userId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var expected = TestData.StaticData.UserAggregates.Find(x => x.UserId == userId);

                var user = ServiceConfig.UserDomainService(scope).FindUser(userId, true);

                Assert.IsNotNull(user);
                Assert.IsNotNull(expected);

                foreach (var item in user.UserRoles)
                {
                    Assert.IsTrue(expected.UserRoles.Any(x => x.TeamIdOrDefault == item.TeamIdOrDefault && x.RoleId == item.RoleId));
                }

                Assertion.AssertObj(expected, user, new List<System.Reflection.PropertyInfo?>());
            }
        }

        [TestMethod]
        [DataRow("player1@team1.com")]
        [DataRow("player2@team1.com")]
        public void UserDomainService_FindUser_ByEmail(string email)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var expected = TestData.StaticData.UserAggregates.Find(x => x.Email == email);

                var user = ServiceConfig.UserDomainService(scope).FindUser(email, true);

                Assert.IsNotNull(user);
                Assert.IsNotNull(expected);

                foreach (var item in user.UserRoles)
                {
                    Assert.IsTrue(expected.UserRoles.Any(x => x.TeamIdOrDefault == item.TeamIdOrDefault && x.RoleId == item.RoleId));
                }

                Assertion.AssertObj(expected, user, new List<System.Reflection.PropertyInfo?>());
            }
        }

        [TestMethod]
        [DataRow(20, null)]
        [DataRow(20, 1)]
        public void UserDomainService_GetPlayer_Fail(int userId, int? teamId)
        {
            try
            {
                using (var scope = ServiceConfig.CreateScope())
                {
                    var team = ServiceConfig.UserDomainService(scope).GetUser(userId, teamId);

                    Assert.Fail("Not found - test should fail");
                }
            }
            catch (Error err)
            {
                Assert.AreEqual(nameof(Translations.err002), err.ErrCode);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }

        [TestMethod]
        [DataRow(1, 1, Roles.Player)]
        [DataRow(2, 1, Roles.TeamAdmin)]
        public void UserDomainService_UpsertRole(int userId, int? teamId, Roles role)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                UserRole? roleTmp = null;
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var user = ServiceConfig.UserDomainService(scope).FindUser(userId, teamId);
                    ServiceConfig.UserDomainService(scope).UpsertRole(userId, teamId, role);

                    user = ServiceConfig.UserDomainService(scope).FindUser(userId, teamId);
                    roleTmp = user?.UserRoles.FirstOrDefault(x => x.UserId == userId && x.TeamIdOrDefault == (teamId ?? 0));

                    return new ServiceResult<User>(user);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(userId, result.Result.UserId);
                Assert.IsNotNull(roleTmp);
                Assert.AreEqual(teamId ?? 0, roleTmp.TeamIdOrDefault);
                Assert.AreEqual(userId, roleTmp.UserId);
                Assert.AreEqual((int)role, roleTmp.RoleId);
            }
        }
    }
}
