using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;

namespace KLO128.D3ORM.Sample.Application.Contracts.Services
{
    public interface IMatchService
    {
        ServiceResult<MatchDTO> AddMatch(AddMatchArgs args, int signedInUserId, bool authorize);

        ServiceResult<MatchDTO> AddMatchSetScore(AddMatchSetScoreArgs args, int signedInUserId, bool authorize);

        ServiceResult<MatchDTO> UpdateMatchSetScoreTransact(UpdateMatchSetScoreArgs args, int signedInUserId, bool authorize);

        ServiceResult<MatchDTO> EndMatchTransact(EndMatchArgs args, int signedInUserId, bool authorize);

        ServiceResult<List<MatchDTO>> GetMatches(int? tournamentId, int? teamId, int? tournamentPhase);
    }
}
