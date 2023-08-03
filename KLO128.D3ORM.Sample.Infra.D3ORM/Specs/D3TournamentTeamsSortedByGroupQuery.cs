using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public class D3TournamentTeamsSortedByGroupQuery
    {
        private static ISpecification<TournamentTeam>? that = null;

        public static ISpecification<TournamentTeam> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<TournamentTeam>(d3Context).And(D3Specification.Create<TournamentTeamStat>(d3Context).OrderBy(x => x.PhasePoints, true, 2).OrderBy(x => x.ScoreMinus, false, 3));

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
