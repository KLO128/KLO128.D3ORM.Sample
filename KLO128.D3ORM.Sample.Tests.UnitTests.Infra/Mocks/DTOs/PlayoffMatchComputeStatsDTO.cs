using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs
{
    public class PlayoffMatchComputeStatsDTO
    {
        public int MatchId { get; set; }
        
        public int HomeTeamId { get; set; }
        
        public int AwayTeamId { get; set; }
        
        public int? TournamentId { get; set; }
        
        public int TournamentPhase { get; set; }
        
        public int? WinnerId { get; set; }
        
        public int? RefereeId { get; set; }
        
        public DateTime? MatchDate { get; set; }
        
        public int? PlayoffRoundCoupleId { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }

        public int CNT_MatchSetScoreId { get; set; }

        public int SUM_HomeTeamScore { get; set; }

        public float AVG_HomeTeamScore { get; set; }

        public int MIN_HomeTeamScore { get; set; }

        public int MAX_HomeTeamScore { get; set; }

        public int SUM_AwayTeamScore { get; set; }

        public float AVG_AwayTeamScore { get; set; }

        public int MIN_AwayTeamScore { get; set; }

        public int MAX_AwayTeamScore { get; set; }
    }
}
