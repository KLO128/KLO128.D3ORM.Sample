using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MSSQL.Db
{
    public partial class MatchSetScore
    {
        public int MatchSetScoreId { get; set; }
        public int MatchId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int SetOrder { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual Match Match { get; set; } = null!;
    }
}
