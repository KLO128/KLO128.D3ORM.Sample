using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3TeamIdFilterQuery
    {
        private static ISpecification<Team>? that = null;

        public static ISpecification<Team> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<Team>(d3Context).CompareFormat(x => x.TeamId, ComparisonOp.EQUALS, 0, LogicalOp.OR);

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
