namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class SignUpTeamArgs : IArgs
    {
        [Required]
        public int TournamentId { get; set; }

        [Required]
        public int TeamId { get; set; }

        public string? RequestToken { get; set; }
    }
}
