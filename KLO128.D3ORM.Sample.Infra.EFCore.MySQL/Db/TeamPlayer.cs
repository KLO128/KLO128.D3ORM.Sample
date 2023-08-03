using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class TeamPlayer
    {
        public int TeamPlayerId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual User Player { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
