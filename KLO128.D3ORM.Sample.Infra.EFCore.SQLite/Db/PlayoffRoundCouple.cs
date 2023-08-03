using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class PlayoffRoundCouple
    {
        public PlayoffRoundCouple()
        {
            Matches = new HashSet<Match>();
        }

        public long PlayoffRoundCoupleId { get; set; }
        public long TournamentTeam1Id { get; set; }
        public long TournamentTeam2Id { get; set; }
        public long PlayoffRound { get; set; }
        public long Team1Wins { get; set; }
        public long Team2Wins { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual TournamentTeam TournamentTeam1 { get; set; } = null!;
        public virtual TournamentTeam TournamentTeam2 { get; set; } = null!;
        public virtual ICollection<Match> Matches { get; set; }
    }
}
