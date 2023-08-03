using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public class D3MatchBaseTournamentPhaseAndTeamIdFilterQuery
    {
        private static ISpecification<Match>? that = null;

        public static ISpecification<Match> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3MatchBaseQuery.GetSingleton(d3Context)
                    .CompareFormat(x => x.TournamentId, ComparisonOp.EQUALS, 0)
                    .And(D3Specification.Create<Team>(d3Context)
                        .CompareFormat(x => x.TeamId, ComparisonOp.EQUALS, 1))
                    .CompareFormat(x => x.TournamentPhase, ComparisonOp.EQUALS, 2);

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
