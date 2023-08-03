using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3MatchBaseQuery
    {
        private static ISpecification<Match>? that = null;

        public static ISpecification<Match> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<Match>(d3Context).OrderBy(x => x.MatchId) // sort order 0 + 10
                    .And(D3Specification.Create<MatchSetScore>(d3Context).OrderBy(x => x.SetOrder)) // sort order 0 + 1 (count of sorts) + 10
                    .And(D3Specification.Create<Team>(d3Context))
                    .And(D3Specification.Create<Tournament>(d3Context))
                    .And(D3Specification.Create<TourSerie>(d3Context))
                    .OrderBy(x => x.TournamentId, true, 1);                     // sort order 1

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
