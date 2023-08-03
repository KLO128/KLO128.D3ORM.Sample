using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3MatchIdFilterQuery
    {
        private static ISpecification<Match>? that = null;

        public static ISpecification<Match> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<Match>(d3Context).CompareFormat(x => x.MatchId, ComparisonOp.EQUALS, 0, LogicalOp.NONE);

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
