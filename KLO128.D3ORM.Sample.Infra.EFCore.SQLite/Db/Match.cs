using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class Match
    {
        public Match()
        {
            MatchSetScores = new HashSet<MatchSetScore>();
        }

        public long MatchId { get; set; }
        public long HomeTeamId { get; set; }
        public long AwayTeamId { get; set; }
        public long? TournamentId { get; set; }
        public long TournamentPhase { get; set; }
        public long? WinnerId { get; set; }
        public long? RefereeId { get; set; }
        public string? MatchDate { get; set; }
        public long? PlayoffRoundCoupleId { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual Team AwayTeam { get; set; } = null!;
        public virtual Team HomeTeam { get; set; } = null!;
        public virtual PlayoffRoundCouple? PlayoffRoundCouple { get; set; }
        public virtual Tournament? Tournament { get; set; }
        public virtual ICollection<MatchSetScore> MatchSetScores { get; set; }
    }
}
