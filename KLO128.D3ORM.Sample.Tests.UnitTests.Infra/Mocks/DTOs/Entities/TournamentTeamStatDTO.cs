
///
/// generated file
///

using System;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class TournamentTeamStatDTO
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
        public TournamentTeamDTO TournamentTeam { get; set; } = null!;
    }
}
