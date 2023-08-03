
///
/// generated file
///

using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class MatchDTO
    {

        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int? TournamentId { get; set; }
        public int TournamentPhase { get; set; }
        public int? WinnerIdTest { get; set; }
        // public int? RefereeId { get; set; } // omitted
        public DateTime? MatchDate { get; set; }
        public int? PlayoffRoundCoupleId { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public TeamDTO AwayTeam { get; set; } = null!;
        public TeamDTO HomeTeam { get; set; } = null!;
        public PlayoffRoundCoupleDTO? PlayoffRoundCouple { get; set; }
        public TournamentDTO? Tournament { get; set; }
        private ICollection<MatchSetScoreDTO>? matchSetScores;
        public ICollection<MatchSetScoreDTO> MatchSetScores
        {
            get
            {
                if (matchSetScores == null)
                {
                    matchSetScores = new List<MatchSetScoreDTO>();
                }

                return matchSetScores;
            }
            set
            {
                matchSetScores = value;
            }
        }

    }
}
