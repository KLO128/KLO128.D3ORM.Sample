using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class UserRole
    {
        public long UserRoleId { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long IsActive { get; set; }
        public long TeamIdOrDefault { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
