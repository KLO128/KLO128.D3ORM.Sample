using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results
{
    public class TeamStatsResult
    {
        public List<TournamentTeamDTO> Stats { get; set; } = new List<TournamentTeamDTO>();
    }
}
