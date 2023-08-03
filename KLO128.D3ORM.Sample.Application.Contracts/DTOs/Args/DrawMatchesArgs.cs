namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class DrawMatchesArgs : IArgs
    {
        [Required]
        public int TournamentId { get; set; }

        public string? RequestToken { get; set; }
    }
}
