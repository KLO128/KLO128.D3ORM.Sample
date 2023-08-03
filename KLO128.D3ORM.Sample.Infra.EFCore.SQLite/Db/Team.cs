using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class Team
    {
        public Team()
        {
            MatchAwayTeams = new HashSet<Match>();
            MatchHomeTeams = new HashSet<Match>();
            TeamPlayers = new HashSet<TeamPlayer>();
            TournamentTeams = new HashSet<TournamentTeam>();
        }

        public long TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public string RegistrationDate { get; set; } = null!;
        public long IsActive { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual ICollection<Match> MatchAwayTeams { get; set; }
        public virtual ICollection<Match> MatchHomeTeams { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
    }
}
