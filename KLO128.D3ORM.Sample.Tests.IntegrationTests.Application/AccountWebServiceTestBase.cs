using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application
{
    public abstract class AccountWebServiceTestBase
    {
        public AccountWebServiceTestBase(DatabaseType databaseType)
        {
            ServiceConfig.InjectAll(databaseType);
        }

        [TestMethod]
        [DataRow("player1@team1.com", "Test1234")]
        public void AccountWebService_SignIn(string email, string password)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.AccountWebService(scope).SignIn(new SignInArgs
                {
                    Password = password,
                    UserName = email
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreEqual(email, result.Result.Email);
            }
        }

        [TestMethod]
        [DataRow("player1@team1.com", "Test12345")]
        [DataRow("player10@team1.com", "Test1234")]
        public void AccountWebService_SignIn_Fail(string email, string password)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.AccountWebService(scope).SignIn(new SignInArgs
                {
                    Password = password,
                    UserName = email
                });

                Assert.IsFalse(result.Succeeded);
                Assert.IsNull(result.Result);
                Assert.AreEqual(nameof(Translations.err014), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow("mock.player@freeplayer.com", "Mock", "Player", "male", "2000-01-01", "+420123456789", "Test1234", "Test1234")]
        public void AccountWebService_SignUp(string email, string firstName, string lastName, string gender, string dateOfBirth, string phoneNumber, string password, string passwordConfirm)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var result = ServiceConfig.AccountWebService(scope).SignUpUnsafe(new SignUpArgs
                    {

                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Gender = gender,
                        DateOfBirth = DateTime.Parse(dateOfBirth),
                        PhoneNumber = phoneNumber,
                        Password = password,
                        PasswordConfirm = passwordConfirm
                    });

                    return new ServiceResult<ZUserDTO>(result);
                });

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Result);
                Assert.AreNotEqual(0, result.Result.UserId);
                Assert.AreEqual(email, result.Result.Email);
                Assert.AreEqual(firstName, result.Result.FirstName);
                Assert.AreEqual(lastName, result.Result.LastName);
                Assert.AreEqual(gender, result.Result.Gender);
                Assert.AreEqual(DateTime.Parse(dateOfBirth), result.Result.DateOfBirth);
                Assert.AreEqual(phoneNumber, result.Result.PhoneNumber);
            }
        }

        [TestMethod]
        [DataRow("player1@team1.com", "Mock", "Player", "male", "2000-01-01", "+420123456789", "Test1234", "Test1234")]
        public void AccountWebService_SignUp_Fail(string email, string firstName, string lastName, string gender, string dateOfBirth, string phoneNumber, string password, string passwordConfirm)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var result = ServiceConfig.AccountWebService(scope).SignUpUnsafe(new SignUpArgs
                    {

                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Gender = gender,
                        DateOfBirth = DateTime.Parse(dateOfBirth),
                        PhoneNumber = phoneNumber,
                        Password = password,
                        PasswordConfirm = passwordConfirm
                    });

                    return new ServiceResult<ZUserDTO>(result);
                });

                Assert.IsFalse(result.Succeeded);
                Assert.AreEqual(nameof(Translations.err013), result.Error?.ErrCode);
            }
        }

        [TestMethod]
        [DataRow(1, Roles.Admin, 0)]
        [DataRow(1, Roles.Admin, null)]
        [DataRow(1, Roles.TeamAdmin, null)]
        [DataRow(1, Roles.Admin, 1)]
        [DataRow(1, Roles.Player, 1)]
        [DataRow(2, Roles.Player, 1)]
        [DataRow(3, Roles.TeamAdmin, 2)]
        [DataRow(3, Roles.Player, 2)]
        [DataRow(4, Roles.Player, 2)]
        [DataRow(3, Roles.Player, 0)]
        public void AccountWebService_IsInRole(int userId, Roles role, int? teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                Assert.IsTrue(ServiceConfig.AccountWebService(scope).IsInRole(userId, role, teamId));
            }
        }

        [TestMethod]
        [DataRow(2, Roles.Host, 2)]
        [DataRow(3, Roles.Admin, 2)]
        [DataRow(3, Roles.Player, 1)]
        public void AccountWebService_IsInRole_Not(int userId, Roles role, int? teamId)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                Assert.IsFalse(ServiceConfig.AccountWebService(scope).IsInRole(userId, role, teamId));
            }
        }
    }
}
