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

namespace KLO128.D3ORM.Sample.Infra.D3ORM.MySQL.Specs
{
    public class D3UserEmailQuery : D3Specification<User>
    {
        public D3UserEmailQuery(ID3Context D3Context, string email) : base(D3Context, email)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?>();

        public override string? SortAppendix { get; protected set; }

        protected override string? BaseSQL { get; set; } = @"SELECT
	`user`.`user_id` AS '.UserId'
	, `user`.`email` AS '.Email'
	, `user`.`email_confirmed` AS '.EmailConfirmed'
	, `user`.`password_hash` AS '.PasswordHash'
	, `user`.`security_stamp` AS '.SecurityStamp'
	, `user`.`phone_number` AS '.PhoneNumber'
	, `user`.`phone_number_confirmed` AS '.PhoneNumberConfirmed'
	, `user`.`two_factor_enabled` AS '.TwoFactorEnabled'
	, `user`.`lockout_end_date_utc` AS '.LockoutEndDateUtc'
	, `user`.`lockout_enabled` AS '.LockoutEnabled'
	, `user`.`access_failed_count` AS '.AccessFailedCount'
	, `user`.`user_name` AS '.UserName'
	, `user`.`first_name` AS '.FirstName'
	, `user`.`last_name` AS '.LastName'
	, `user`.`gender` AS '.Gender'
	, `user`.`external_login` AS '.ExternalLogin'
	, `user`.`registration_guid` AS '.RegistrationGuid'
	, `user`.`guidexpiration_date` AS '.GuidexpirationDate'
 FROM `user` `user`

";

        private string? localFilterExpression;

        protected override string LocalFilterExpression
        {
            get
            {
                if (localFilterExpression == null)
                {
                    localFilterExpression = $"{GetDbName(nameof(User)).LowerizeFirst()}.{GetDbName(nameof(User.Email))} = {{0}}";
                }

                return localFilterExpression;
            }
        }

        public override Func<ID3Context, object?[], D3Specification<User>> CloneNewFunc { get; } = (x, y) => new D3UserEmailQuery(x, y.FirstOrDefault()?.ToString() ?? string.Empty);
    }
}
