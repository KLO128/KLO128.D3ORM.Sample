

using System;
using System.Collections.Generic;
///
/// generated file
///
namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class PlayoffRoundCoupleDTO
    {

        public int PlayoffRoundCoupleId { get; set; }
        public int TournamentTeam1Id { get; set; }
        public int TournamentTeam2Id { get; set; }
        public int PlayoffRound { get; set; }
        public int Team1Wins { get; set; }
        public int Team2Wins { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public TournamentTeamDTO TournamentTeam1 { get; set; } = null!;
        public TournamentTeamDTO TournamentTeam2 { get; set; } = null!;
        private ICollection<MatchDTO>? matches;
        public ICollection<MatchDTO> MatchesTest
        {
            get
            {
                if (matches == null)
                {
                    matches = new List<MatchDTO>();
                }

                return matches;
            }
            set
            {
                matches = value;
            }
        }

    }
}
