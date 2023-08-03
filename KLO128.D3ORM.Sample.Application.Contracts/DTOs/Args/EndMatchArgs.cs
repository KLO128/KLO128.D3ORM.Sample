namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class EndMatchArgs : IArgs
    {
        [Required]
        public int MatchId { get; set; }

        public string? RequestToken { get; set; }
    }
}
