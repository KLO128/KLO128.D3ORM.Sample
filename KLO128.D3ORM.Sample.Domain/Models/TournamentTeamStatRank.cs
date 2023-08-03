namespace KLO128.D3ORM.Sample.Domain.Models
{
    public class TournamentTeamStatRank
    {
        public int TournamentTeamStatRankId { get; set; }

        public int TournamentTeamRankId { get; set; }

        public int TournamentPhase { get; set; }

        public int PhasePoints { get; set; }

        public int Wins { get; set; }

        public int Losts { get; set; }

        public int Ties { get; set; }

        public int SetsWonLostDiff { get; set; }

        public int ScorePlusMinus { get; set; }

        public DateTime LastChange { get; set; } = DateTime.UtcNow;

        public int? ChangedBy { get; set; }

        public TournamentTeamRank TournamentTeamRank { get; set; } = null!;
    }
}
