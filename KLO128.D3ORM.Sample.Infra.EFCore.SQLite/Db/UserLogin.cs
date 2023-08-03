using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public long UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
