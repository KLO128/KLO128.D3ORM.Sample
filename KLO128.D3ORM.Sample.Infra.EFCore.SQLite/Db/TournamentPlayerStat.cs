using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class TournamentPlayerStat
    {
        public long TournamentPlayerStatId { get; set; }
        public long TournamentId { get; set; }
        public long PlayerId { get; set; }
        public long? TourPoints { get; set; }
        public long? AttackPoints { get; set; }
        public double? AttackPercentage { get; set; }
        public long? ServicePoints { get; set; }
        public long? ServicePercentage { get; set; }
        public long? UnforcedErrors { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual User Player { get; set; } = null!;
        public virtual Tournament Tournament { get; set; } = null!;
    }
}
