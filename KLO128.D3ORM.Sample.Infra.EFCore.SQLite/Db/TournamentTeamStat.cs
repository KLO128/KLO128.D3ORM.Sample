using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class TournamentTeamStat
    {
        public long TournamentTeamStatId { get; set; }
        public long TournamentTeamId { get; set; }
        public long TournamentPhase { get; set; }
        public long PhasePoints { get; set; }
        public long Wins { get; set; }
        public long Losts { get; set; }
        public long Ties { get; set; }
        public long SetsWon { get; set; }
        public long SetsLost { get; set; }
        public long ScorePlus { get; set; }
        public long ScoreMinus { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual TournamentTeam TournamentTeam { get; set; } = null!;
    }
}
