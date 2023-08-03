using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public long RoleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
