using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results;

namespace KLO128.D3ORM.Sample.Application.Contracts.Services
{
    public interface ITeamService
    {
        ServiceResult<TeamDTO> CreateTeamTransact(CreateTeamArgs args, int signedInUserId);

        TeamDTO CreateTeamUnsafe(CreateTeamArgs args, int signedInUserId);

        ServiceResult<TeamDTO> AddPlayerTransact(AddPlayerArgs args, int signedInUserId);

        ServiceResult<bool> RemovePlayerTransact(RemovePlayerFromTeamArgs args, int signedInUserId);

        ServiceResult<TeamDTO> GetTeamData(int teamId);

        ServiceResult<TeamDTO> GetTeamDataAndStats(int teamId);

        ServiceResult<TeamStatsResult> GetTeamStats(int? teamId, int? tournamentId);
    }
}
