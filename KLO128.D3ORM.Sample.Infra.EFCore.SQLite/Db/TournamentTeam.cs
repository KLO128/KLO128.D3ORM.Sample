using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class TournamentTeam
    {
        public TournamentTeam()
        {
            PlayoffRoundCoupleTournamentTeam1s = new HashSet<PlayoffRoundCouple>();
            PlayoffRoundCoupleTournamentTeam2s = new HashSet<PlayoffRoundCouple>();
            TournamentTeamStats = new HashSet<TournamentTeamStat>();
        }

        public long TournamentTeamId { get; set; }
        public long TournamentId { get; set; }
        public long TeamId { get; set; }
        public string? BasicGroupName { get; set; }
        public string RegistrationDate { get; set; } = null!;
        public byte[] EntryFeePaid { get; set; } = null!;
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual Tournament Tournament { get; set; } = null!;
        public virtual ICollection<PlayoffRoundCouple> PlayoffRoundCoupleTournamentTeam1s { get; set; }
        public virtual ICollection<PlayoffRoundCouple> PlayoffRoundCoupleTournamentTeam2s { get; set; }
        public virtual ICollection<TournamentTeamStat> TournamentTeamStats { get; set; }
    }
}
