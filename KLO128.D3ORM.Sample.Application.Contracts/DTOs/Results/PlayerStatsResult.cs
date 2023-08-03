using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results
{
    public class PlayerStatsResult
    {
        public List<TournamentPlayerStatDTO> Stats { get; set; } = new List<TournamentPlayerStatDTO>();
    }
}
