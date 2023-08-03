
///
/// generated file
///

using System;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class MatchSetScoreDTO
    {

        public int MatchSetScoreId { get; set; }
        public int MatchId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public int ScoreDifference { get; set; }

        public int SetOrder { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
    }
}
