using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
            TournamentPlayerStats = new HashSet<TournamentPlayerStat>();
            TournamentTeams = new HashSet<TournamentTeam>();
        }

        public long TournamentId { get; set; }
        public long? TourSerieId { get; set; }
        public long? AddressId { get; set; }
        public string Name { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public double? EntryFee { get; set; }
        public long? MaxNumOfTeams { get; set; }
        public string? Note { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual Address? Address { get; set; }
        public virtual TourSerie? TourSerie { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<TournamentPlayerStat> TournamentPlayerStats { get; set; }
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
    }
}
