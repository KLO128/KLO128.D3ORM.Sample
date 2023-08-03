using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Domain.Services
{
    public interface IDomainService
    {
        IQueryContainer QC { get; }
    }
}
