namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class DrawGroupsArgs : IArgs
    {
        [Required]
        public int TournamentId { get; set; }

        public List<string>? GroupNames { get; set; }

        public int? MinNumberOfTeamsPerGroup { get; set; }

        public int? MaxNumberOfTeamsPerGroup { get; set; }

        public string? RequestToken { get; set; }
    }
}
