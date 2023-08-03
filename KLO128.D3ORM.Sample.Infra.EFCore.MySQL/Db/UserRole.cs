using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public int TeamIdOrDefault { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
