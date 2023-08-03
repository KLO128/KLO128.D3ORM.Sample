using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class TournamentPlayerStat
    {
        public int TournamentPlayerStatId { get; set; }
        public int TournamentId { get; set; }
        public int PlayerId { get; set; }
        public int? TourPoints { get; set; }
        public int? AttackPoints { get; set; }
        public float? AttackPercentage { get; set; }
        public int? ServicePoints { get; set; }
        public int? ServicePercentage { get; set; }
        public int? UnforcedErrors { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual User Player { get; set; } = null!;
        public virtual Tournament Tournament { get; set; } = null!;
    }
}
