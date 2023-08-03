using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3UserEmailFilterQuery
    {
        private static ISpecification<User>? that = null;

        public static ISpecification<User> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<User>(d3Context).CompareFormat(x => x.Email, ComparisonOp.EQUALS, 0, LogicalOp.NONE).ExcludeSelectPropMasks(QueryContainer.UserSensitiveData);

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
