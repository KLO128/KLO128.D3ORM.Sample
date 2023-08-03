using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs
{
    public class MatchesWinPercentageDTO
    {
        public int ROWID { get; set; }

        public int PlayoffRoundCoupleId { get; set; }

        public int TournamentTeam1Id { get; set; }

        public int TournamentTeam2Id { get; set; }

        public int PlayoffRound { get; set; }

        public int Team1Wins { get; set; }

        public int Team2Wins { get; set; }

        public DateTime LastChange { get; set; }

        public int ChangedBy { get; set; }

        public decimal CNT_MatchId { get; set; }
    }
}
