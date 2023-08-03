using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class MatchSetScore
    {
        public long MatchSetScoreId { get; set; }
        public long MatchId { get; set; }
        public long HomeTeamScore { get; set; }
        public long AwayTeamScore { get; set; }
        public long SetOrder { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual Match Match { get; set; } = null!;
    }
}
