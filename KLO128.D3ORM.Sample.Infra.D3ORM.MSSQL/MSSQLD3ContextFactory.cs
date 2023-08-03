using KLO128.D3ORM.Common;
using KLO128.D3ORM.MSSQL;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.MSSQL
{
    public class MSSQLD3ContextFactory : ID3ContextFactory
    {
        public ID3Context Create()
        {
            return new MSSQLD3Context(EntityPropMappings.Dict, DtoPatternFormat: Constants.DtoPatternFormat);
        }
    }
}
