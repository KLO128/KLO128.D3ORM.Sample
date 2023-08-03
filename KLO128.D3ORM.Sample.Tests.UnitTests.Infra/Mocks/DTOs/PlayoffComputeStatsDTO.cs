using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs
{
    public class PlayoffComputeStatsDTO
    {
        public int PlayoffRoundCoupleId { get; set; }

        public List<PlayoffMatchComputeStatsDTO> Matches { get; set; } = new List<PlayoffMatchComputeStatsDTO>();
    }
}
