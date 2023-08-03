using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class UserClaim
    {
        public long UserClaimId { get; set; }
        public long UserId { get; set; }
        public string ClaimType { get; set; } = null!;
        public string ClaimValue { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
