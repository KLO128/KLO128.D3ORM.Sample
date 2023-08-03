using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public class D3TournamentTeamRankSortedByStatsQuery
    {
        private static ISpecification<TournamentTeamRank>? that = null;

        public static ISpecification<TournamentTeamRank> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create(d3Context, (TournamentTeam x) => x.TournamentTeamStats, (TournamentTeamStat x) => x.TournamentTeamId)
                    .And(D3Specification.Create<TournamentTeamStat>(d3Context)
                        .OrderBy(x => x.PhasePoints, true, 3)
                        .CustomAggFunc(nameof(TournamentTeamStatRank.SetsWonLostDiff), ComputeType.NONE, x => x.SetsWon, CrossColumnOp.DiffOrNone, x => x.SetsLost, propertySortOrder: 4)
                        .CustomAggFunc(nameof(TournamentTeamStatRank.ScorePlusMinus), ComputeType.NONE, x => x.ScorePlus, CrossColumnOp.DiffOrNone, x => x.ScoreMinus, propertySortOrder: 5)
                        .CompareFormat(x => x.TournamentPhase, ComparisonOp.EQUALS, 1)
                        .OrderBy(x => x.TournamentPhase, false, 1))
                    .And(D3Specification.Create<TournamentTeam>(d3Context)
                        .CompareFormat(x => x.TournamentId, ComparisonOp.EQUALS, 0)
                        .And(D3Specification.Create<Team>(d3Context))
                        /*.OrderBy(x => x.BasicGroupName, false, 2)*/)
                    .IncludeSelectProps((TournamentTeamStat x) => x.PhasePoints, (TournamentTeamStat x) => x.TournamentPhase, (TournamentTeamStat x) => x.LastChange)
                    .IncludeSelectProps((TournamentTeam x) => x.BasicGroupName, (TournamentTeam x) => x.LastChange)
                    .IncludeSelectProps((Team x) => "*")
                    .AsDTO<TournamentTeamRank>();

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
