using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class TeamPlayer
    {
        public long TeamPlayerId { get; set; }
        public long TeamId { get; set; }
        public long PlayerId { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
