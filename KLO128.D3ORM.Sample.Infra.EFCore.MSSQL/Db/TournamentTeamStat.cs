using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MSSQL.Db
{
    public partial class TournamentTeamStat
    {
        public int TournamentTeamStatId { get; set; }
        public int TournamentTeamId { get; set; }
        public int TournamentPhase { get; set; }
        public int PhasePoints { get; set; }
        public int Wins { get; set; }
        public int Losts { get; set; }
        public int Ties { get; set; }
        public int SetsWon { get; set; }
        public int SetsLost { get; set; }
        public int ScorePlus { get; set; }
        public int ScoreMinus { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual TournamentTeam TournamentTeam { get; set; } = null!;
    }
}
