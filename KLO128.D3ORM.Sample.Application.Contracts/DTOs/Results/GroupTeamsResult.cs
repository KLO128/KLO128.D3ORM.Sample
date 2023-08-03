using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results
{
    public class GroupTeamsResult
    {
        public string GroupName { get; set; } = null!;

        public int TournamentId { get; set; }

        public string TournamentName { get; set; } = null!;

        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
    }
}
