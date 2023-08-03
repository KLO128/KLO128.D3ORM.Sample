using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.SQLite.Specs
{
    public class D3UserIdFilterQuery : D3Specification<User>
    {
        public D3UserIdFilterQuery(ID3Context D3Context, int? id) : base(D3Context, id)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?>();

        public override string? SortAppendix { get; protected set; }

        protected override string? BaseSQL { get; set; } = @"SELECT
	[user].[UserId] AS '.UserId'
	, [user].[Email] AS '.Email'
	, [user].[EmailConfirmed] AS '.EmailConfirmed'
	, [user].[PasswordHash] AS '.PasswordHash'
	, [user].[SecurityStamp] AS '.SecurityStamp'
	, [user].[PhoneNumber] AS '.PhoneNumber'
	, [user].[PhoneNumberConfirmed] AS '.PhoneNumberConfirmed'
	, [user].[TwoFactorEnabled] AS '.TwoFactorEnabled'
	, [user].[LockoutEndDateUtc] AS '.LockoutEndDateUtc'
	, [user].[LockoutEnabled] AS '.LockoutEnabled'
	, [user].[AccessFailedCount] AS '.AccessFailedCount'
	, [user].[UserName] AS '.UserName'
	, [user].[FirstName] AS '.FirstName'
	, [user].[LastName] AS '.LastName'
	, [user].[Gender] AS '.Gender'
	, [user].[ExternalLogin] AS '.ExternalLogin'
	, [user].[RegistrationGuid] AS '.RegistrationGuid'
	, [user].[GuidexpirationDate] AS '.GuidexpirationDate'
 FROM [User] [user]

";

        private string? localFilterExpression;

        protected override string LocalFilterExpression
        {
            get
            {
                if (localFilterExpression == null)
                {
                    localFilterExpression = $"{GetDbName(nameof(User)).LowerizeFirst()}.{GetDbName(nameof(User.UserId))} = {{0}}";
                }

                return localFilterExpression;
            }
        }

        public override Func<ID3Context, object?[], D3Specification<User>> CloneNewFunc { get; } = (x, y) => new D3UserIdFilterQuery(x, (int?)y.First());
    }
}
