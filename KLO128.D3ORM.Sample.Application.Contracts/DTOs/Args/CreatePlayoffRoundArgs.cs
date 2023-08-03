namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class CreatePlayoffRoundArgs : IArgs
    {
        [Required]
        public int TournamentId { get; set; }

        public int? PlayoffPass { get; set; }

        public string? RequestToken { get; set; }
    }
}
