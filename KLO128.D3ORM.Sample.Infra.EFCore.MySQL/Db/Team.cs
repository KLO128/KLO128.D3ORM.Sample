using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
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

        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual ICollection<Match> MatchAwayTeams { get; set; }
        public virtual ICollection<Match> MatchHomeTeams { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }
    }
}
