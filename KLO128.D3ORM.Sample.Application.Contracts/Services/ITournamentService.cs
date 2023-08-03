using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results;

namespace KLO128.D3ORM.Sample.Application.Contracts.Services
{
    public interface ITournamentService
    {
        ServiceResult<TournamentTeamDTO> SignUpTeamTransact(SignUpTeamArgs args, int signedInUserId);

        TournamentTeamDTO SignUpTeamUnsafe(SignUpTeamArgs args, int signedInUserId, bool authorize);

        ServiceResult<List<GroupTeamsResult>> DrawGroupsTransact(DrawGroupsArgs args, int signedInUserId, bool authorize);

        ServiceResult<List<MatchDTO>> DrawMatchesTransact(DrawMatchesArgs args, int signedInUserId, bool authorize);

        ServiceResult<List<PlayoffRoundCoupleDTO>> CreatePlayoffFirstRoundCouplesTransact(CreatePlayoffRoundArgs args, int signedInUserId, bool authorize);

        ServiceResult<List<PlayoffRoundCoupleDTO>> GetPlayoffCouples(int tournamentId, int? playoffRound);

        ServiceResult<TournamentDTO> CreateTournament(CreateTournamentArgs args, int signedInUsedId, bool authorize);
    }
}
