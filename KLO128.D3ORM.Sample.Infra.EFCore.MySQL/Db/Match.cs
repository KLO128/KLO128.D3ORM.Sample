using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class Match
    {
        public Match()
        {
            MatchSetScores = new HashSet<MatchSetScore>();
        }

        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? TournamentId { get; set; }
        public int TournamentPhase { get; set; }
        public int? WinnerId { get; set; }
        public int? RefereeId { get; set; }
        public DateTime? MatchDate { get; set; }
        public int? PlayoffRoundCoupleId { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual Team AwayTeam { get; set; } = null!;
        public virtual Team HomeTeam { get; set; } = null!;
        public virtual PlayoffRoundCouple? PlayoffRoundCouple { get; set; }
        public virtual Tournament? Tournament { get; set; }
        public virtual ICollection<MatchSetScore> MatchSetScores { get; set; }
    }
}
