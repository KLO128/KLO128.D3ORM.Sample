using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MSSQL.Db
{
    public partial class TournamentTeam
    {
        public TournamentTeam()
        {
            PlayoffRoundCoupleTournamentTeam1s = new HashSet<PlayoffRoundCouple>();
            PlayoffRoundCoupleTournamentTeam2s = new HashSet<PlayoffRoundCouple>();
            TournamentTeamStats = new HashSet<TournamentTeamStat>();
        }

        public int TournamentTeamId { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public string? BasicGroupName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool EntryFeePaid { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual Tournament Tournament { get; set; } = null!;
        public virtual ICollection<PlayoffRoundCouple> PlayoffRoundCoupleTournamentTeam1s { get; set; }
        public virtual ICollection<PlayoffRoundCouple> PlayoffRoundCoupleTournamentTeam2s { get; set; }
        public virtual ICollection<TournamentTeamStat> TournamentTeamStats { get; set; }
    }
}
