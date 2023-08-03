using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MSSQL.Db
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matches = new HashSet<Match>();
            TournamentPlayerStats = new HashSet<TournamentPlayerStat>();
            TournamentTeams = new HashSet<TournamentTeam>();
        }

        public int TournamentId { get; set; }
        public int? TourSerieId { get; set; }
        public int? AddressId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? EntryFee { get; set; }
        public int? MaxNumOfTeams { get; set; }
        public string? Note { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual Address? Address { get; set; }
        public virtual TourSerie? TourSerie { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<TournamentPlayerStat> TournamentPlayerStats { get; set; }
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
    }
}
