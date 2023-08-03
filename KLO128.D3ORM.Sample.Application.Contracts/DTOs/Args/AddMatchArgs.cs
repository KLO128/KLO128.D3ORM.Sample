namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class AddMatchArgs : IArgs
    {
        [Required]
        public int HomeTeamId { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        public int? TournamentId { get; set; }

        [Required]
        public int TournamentPhase { get; set; }

        public string? RequestToken { get; set; }
    }
}
