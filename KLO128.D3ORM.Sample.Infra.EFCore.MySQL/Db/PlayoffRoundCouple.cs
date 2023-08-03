using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class PlayoffRoundCouple
    {
        public PlayoffRoundCouple()
        {
            Matches = new HashSet<Match>();
        }

        public int PlayoffRoundCoupleId { get; set; }
        public int TournamentTeam1Id { get; set; }
        public int TournamentTeam2Id { get; set; }
        public int PlayoffRound { get; set; }
        public int Team1Wins { get; set; }
        public int Team2Wins { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual TournamentTeam TournamentTeam1 { get; set; } = null!;
        public virtual TournamentTeam TournamentTeam2 { get; set; } = null!;
        public virtual ICollection<Match> Matches { get; set; }
    }
}
