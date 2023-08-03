namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class AddMatchSetScoreArgs : IArgs
    {
        [Required]
        public int MatchId { get; set; }

        [Required]
        public int SetOrder { get; set; }

        [Required]
        public int HomeTeamScore { get; set; }

        [Required]
        public int AwayTeamScore { get; set; }

        public string? RequestToken { get; set; }
    }
}
