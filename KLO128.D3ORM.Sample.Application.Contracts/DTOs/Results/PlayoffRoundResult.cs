using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results
{
    public class PlayoffRoundResult
    {
        public List<PlayoffCoupleResult> Couples { get; set; } = new List<PlayoffCoupleResult>();
    }
}
