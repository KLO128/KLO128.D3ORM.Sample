namespace KLO128.D3ORM.Sample.Domain.Models
{
    public class TournamentTeamRank
    {
        public int TournamentTeamRankId { get; set; }

        public int TournamentId { get; set; }

        public int TeamId { get; set; }

        public string? BasicGroupName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool EntryFeePaid { get; set; }

        public DateTime LastChange { get; set; } = DateTime.UtcNow;

        public int? ChangedBy { get; set; }

        public TeamRank Team { get; set; } = null!;

        private ICollection<TournamentTeamStatRank>? tournamentTeamStats;
        public ICollection<TournamentTeamStatRank> TournamentTeamStats
        {
            get
            {
                if (tournamentTeamStats == null)
                {
                    tournamentTeamStats = new List<TournamentTeamStatRank>();
                }

                return tournamentTeamStats;
            }
            set
            {
                tournamentTeamStats = value;
            }
        }
    }
}
