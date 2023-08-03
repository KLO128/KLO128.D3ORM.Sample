using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3TournamentTeamAndStatsFilterQuery
    {
        private static ISpecification<TournamentTeam>? that = null;

        public static ISpecification<TournamentTeam> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<TournamentTeam>(d3Context)
                    .CompareFormat(x => x.TournamentId, ComparisonOp.EQUALS, 0, LogicalOp.AND)
                    .CompareFormat(x => x.TeamId, ComparisonOp.EQUALS, 1, LogicalOp.AND)
                    .And(D3Specification.Create<TournamentTeamStat>(d3Context)
                        .CompareFormat(x => x.TournamentPhase, ComparisonOp.EQUALS, 2, LogicalOp.AND));

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
