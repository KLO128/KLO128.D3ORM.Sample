using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class d3orm_sampleContext : DbContext
    {
        public d3orm_sampleContext()
        {
        }

        public d3orm_sampleContext(DbContextOptions<d3orm_sampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<MatchSetScore> MatchSetScores { get; set; } = null!;
        public virtual DbSet<PlayoffRoundCouple> PlayoffRoundCouples { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamPlayer> TeamPlayers { get; set; } = null!;
        public virtual DbSet<TourSerie> TourSeries { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;
        public virtual DbSet<TournamentPlayerStat> TournamentPlayerStats { get; set; } = null!;
        public virtual DbSet<TournamentTeam> TournamentTeams { get; set; } = null!;
        public virtual DbSet<TournamentTeamStat> TournamentTeamStats { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserClaim> UserClaims { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=d3orm_sample;uid=d3orm;pwd=Test1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(50)
                    .HasColumnName("house_number");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.Name)
                    .HasMaxLength(70)
                    .HasColumnName("name");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasMaxLength(75)
                    .HasColumnName("street");

                entity.Property(e => e.Town)
                    .HasMaxLength(50)
                    .HasColumnName("town");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("match");

                entity.HasIndex(e => e.AwayTeamId, "ixfk__match__away_team");

                entity.HasIndex(e => e.HomeTeamId, "ixfk__match__home_team");

                entity.HasIndex(e => e.PlayoffRoundCoupleId, "ixfk__match__playoff_round_couple");

                entity.HasIndex(e => e.TournamentId, "ixfk__match__tournament");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.AwayTeamId).HasColumnName("away_team_id");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.HomeTeamId).HasColumnName("home_team_id");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.MatchDate)
                    .HasColumnType("datetime")
                    .HasColumnName("match_date");

                entity.Property(e => e.PlayoffRoundCoupleId).HasColumnName("playoff_round_couple_id");

                entity.Property(e => e.RefereeId).HasColumnName("referee_id");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.Property(e => e.TournamentPhase).HasColumnName("tournament_phase");

                entity.Property(e => e.WinnerId).HasColumnName("winner_id");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__match__away_team");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__match__home_team");

                entity.HasOne(d => d.PlayoffRoundCouple)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.PlayoffRoundCoupleId)
                    .HasConstraintName("fk__match__playoff_round_couple");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("fk__match__tournament");
            });

            modelBuilder.Entity<MatchSetScore>(entity =>
            {
                entity.ToTable("match_set_score");

                entity.HasIndex(e => e.MatchId, "ixfk__match_set_score__match");

                entity.Property(e => e.MatchSetScoreId).HasColumnName("match_set_score_id");

                entity.Property(e => e.AwayTeamScore).HasColumnName("away_team_score");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.HomeTeamScore).HasColumnName("home_team_score");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.SetOrder).HasColumnName("set_order");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchSetScores)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__match_set_score__match");
            });

            modelBuilder.Entity<PlayoffRoundCouple>(entity =>
            {
                entity.ToTable("playoff_round_couple");

                entity.HasIndex(e => e.TournamentTeam1Id, "ixfk__playoff_round_couple__tournament_team1");

                entity.HasIndex(e => e.TournamentTeam2Id, "ixfk__playoff_round_couple__tournament_team2");

                entity.Property(e => e.PlayoffRoundCoupleId).HasColumnName("playoff_round_couple_id");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.PlayoffRound).HasColumnName("playoff_round");

                entity.Property(e => e.Team1Wins).HasColumnName("team1_wins");

                entity.Property(e => e.Team2Wins).HasColumnName("team2_wins");

                entity.Property(e => e.TournamentTeam1Id).HasColumnName("tournament_team1_id");

                entity.Property(e => e.TournamentTeam2Id).HasColumnName("tournament_team2_id");

                entity.HasOne(d => d.TournamentTeam1)
                    .WithMany(p => p.PlayoffRoundCoupleTournamentTeam1s)
                    .HasForeignKey(d => d.TournamentTeam1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__playoff_round_couple_tournament_team1");

                entity.HasOne(d => d.TournamentTeam2)
                    .WithMany(p => p.PlayoffRoundCoupleTournamentTeam2s)
                    .HasForeignKey(d => d.TournamentTeam2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__playoff_round_couple_tournament_team2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.HasIndex(e => e.Name, "ix__team_name");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.Logo)
                    .HasMaxLength(4000)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("team_player");

                entity.HasIndex(e => e.TeamId, "ixfk__team_player__team");

                entity.HasIndex(e => e.PlayerId, "ixfk__team_player__user");

                entity.Property(e => e.TeamPlayerId).HasColumnName("team_player_id");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TeamPlayers)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__team_player__user");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamPlayers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__team_player__team");
            });

            modelBuilder.Entity<TourSerie>(entity =>
            {
                entity.ToTable("tour_serie");

                entity.Property(e => e.TourSerieId).HasColumnName("tour_serie_id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("tournament");

                entity.HasIndex(e => e.AddressId, "ixfk__tournament__address");

                entity.HasIndex(e => e.TourSerieId, "ixfk__tournament__tour_serie");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.EntryFee).HasColumnName("entry_fee");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.MaxNumOfTeams).HasColumnName("max_num_of_teams");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.TourSerieId).HasColumnName("tour_serie_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk__tournament__address");

                entity.HasOne(d => d.TourSerie)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.TourSerieId)
                    .HasConstraintName("fk__tournament__tour_serie");
            });

            modelBuilder.Entity<TournamentPlayerStat>(entity =>
            {
                entity.ToTable("tournament_player_stat");

                entity.HasIndex(e => e.PlayerId, "fk__tournament_player_stat__user");

                entity.HasIndex(e => e.TournamentId, "ixfk__tournament_player_stat__tournament");

                entity.Property(e => e.TournamentPlayerStatId).HasColumnName("tournament_player_stat_id");

                entity.Property(e => e.AttackPercentage).HasColumnName("attack_percentage");

                entity.Property(e => e.AttackPoints).HasColumnName("attack_points");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.ServicePercentage).HasColumnName("service_percentage");

                entity.Property(e => e.ServicePoints).HasColumnName("service_points");

                entity.Property(e => e.TourPoints).HasColumnName("tour_points");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.Property(e => e.UnforcedErrors).HasColumnName("unforced_errors");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TournamentPlayerStats)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__tournament_player_stat__user");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentPlayerStats)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__tournament_player_stat__tournament");
            });

            modelBuilder.Entity<TournamentTeam>(entity =>
            {
                entity.ToTable("tournament_team");

                entity.HasIndex(e => e.TeamId, "ixfk__tournament_team__team");

                entity.HasIndex(e => e.TournamentId, "ixfk__tournament_team__tournament");

                entity.Property(e => e.TournamentTeamId).HasColumnName("tournament_team_id");

                entity.Property(e => e.BasicGroupName)
                    .HasMaxLength(25)
                    .HasColumnName("basic_group_name");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.EntryFeePaid).HasColumnName("entry_fee_paid");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TournamentTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__tournament_team__team");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentTeams)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__tournament_team__tournament");
            });

            modelBuilder.Entity<TournamentTeamStat>(entity =>
            {
                entity.ToTable("tournament_team_stat");

                entity.HasIndex(e => e.TournamentTeamId, "ixfk__tournament_team_stat__tournament_team");

                entity.Property(e => e.TournamentTeamStatId).HasColumnName("tournament_team_stat_id");

                entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("last_change");

                entity.Property(e => e.Losts).HasColumnName("losts");

                entity.Property(e => e.PhasePoints).HasColumnName("phase_points");

                entity.Property(e => e.ScoreMinus).HasColumnName("score_minus");

                entity.Property(e => e.ScorePlus).HasColumnName("score_plus");

                entity.Property(e => e.SetsLost).HasColumnName("sets_lost");

                entity.Property(e => e.SetsWon).HasColumnName("sets_won");

                entity.Property(e => e.Ties).HasColumnName("ties");

                entity.Property(e => e.TournamentPhase).HasColumnName("tournament_phase");

                entity.Property(e => e.TournamentTeamId).HasColumnName("tournament_team_id");

                entity.Property(e => e.Wins).HasColumnName("wins");

                entity.HasOne(d => d.TournamentTeam)
                    .WithMany(p => p.TournamentTeamStats)
                    .HasForeignKey(d => d.TournamentTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__tournament_team_stat__tournament_team");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AccessFailedCount).HasColumnName("access_failed_count");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");

                entity.Property(e => e.ExternalLogin).HasColumnName("external_login");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(75)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.GuidexpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("guidexpiration_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.LockoutEnabled).HasColumnName("lockout_enabled");

                entity.Property(e => e.LockoutEndDateUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("lockout_end_date_utc");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(2000)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");

                entity.Property(e => e.RegistrationGuid)
                    .HasMaxLength(100)
                    .HasColumnName("registration_guid");

                entity.Property(e => e.SecurityStamp)
                    .HasMaxLength(2000)
                    .HasColumnName("security_stamp");

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("two_factor_enabled");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.ToTable("user_claim");

                entity.HasIndex(e => e.UserId, "ixfk__user_claim__user");

                entity.Property(e => e.UserClaimId).HasColumnName("user_claim_id");

                entity.Property(e => e.ClaimType)
                    .HasMaxLength(1000)
                    .HasColumnName("claim_type");

                entity.Property(e => e.ClaimValue)
                    .HasMaxLength(500)
                    .HasColumnName("claim_value");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__user_claim__user");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("user_login");

                entity.HasIndex(e => e.UserId, "ixfk__user_login__user");

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .HasColumnName("login_provider");

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(128)
                    .HasColumnName("provider_key");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__user_login__user");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.HasIndex(e => e.RoleId, "ixfk__user_role__role");

                entity.HasIndex(e => e.UserId, "ixfk__user_role__user");

                entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.TeamIdOrDefault).HasColumnName("team_id_or_default");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__user_role__role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__user_role__user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
