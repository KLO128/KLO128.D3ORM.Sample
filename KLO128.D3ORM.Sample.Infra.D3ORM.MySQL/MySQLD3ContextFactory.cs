using KLO128.D3ORM.Common;
using KLO128.D3ORM.MySQL;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.MySQL
{
    public class MySQLD3ContextFactory : ID3ContextFactory
    {
        public ID3Context Create()
        {
            return new MySQLD3Context(EntityPropMappings.Dict, DtoPatternFormat: Constants.DtoPatternFormat);
        }
    }
}
