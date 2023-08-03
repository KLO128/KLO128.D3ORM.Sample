using KLO128.D3ORM.Common;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.SQLite;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.SQLite
{
    public class SQLiteD3ContextFactory : ID3ContextFactory
    {
        public ID3Context Create()
        {
            return new SQLiteD3Context(EntityPropMappings.Dict, DtoPatternFormat: Constants.DtoPatternFormat);
        }
    }
}
