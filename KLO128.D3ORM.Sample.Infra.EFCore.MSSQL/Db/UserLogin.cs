using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MSSQL.Db
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
