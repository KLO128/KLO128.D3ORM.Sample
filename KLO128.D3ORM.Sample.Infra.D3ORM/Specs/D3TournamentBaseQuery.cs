using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3TournamentBaseQuery
    {
        private static ISpecification<Tournament>? that = null;

        public static ISpecification<Tournament> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<Tournament>(d3Context)
                    .And(D3Specification.Create<TournamentTeam>(d3Context))
                    .And(D3Specification.Create<Team>(d3Context))
                    .And(D3Specification.Create<TournamentTeamStat>(d3Context))
                    .And(D3Specification.Create<TourSerie>(d3Context))
                    .OrderBy(x => x.Name, true); // sort order 10

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
