using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class sample_databaseContext : DbContext
    {
        public sample_databaseContext()
        {
        }

        public sample_databaseContext(DbContextOptions<sample_databaseContext> options)
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
                optionsBuilder.UseSqlite("Data Source=..\\\\\\\\Docs\\\\\\\\SQLite\\\\\\\\sample_database.sqlite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.TournamentPhase).HasDefaultValueSql("1");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PlayoffRoundCouple)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.PlayoffRoundCoupleId);

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.TournamentId);
            });

            modelBuilder.Entity<MatchSetScore>(entity =>
            {
                entity.ToTable("MatchSetScore");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchSetScores)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PlayoffRoundCouple>(entity =>
            {
                entity.ToTable("PlayoffRoundCouple");

                entity.HasOne(d => d.TournamentTeam1)
                    .WithMany(p => p.PlayoffRoundCoupleTournamentTeam1s)
                    .HasForeignKey(d => d.TournamentTeam1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TournamentTeam2)
                    .WithMany(p => p.PlayoffRoundCoupleTournamentTeam2s)
                    .HasForeignKey(d => d.TournamentTeam2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("TeamPlayer");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamPlayers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TourSerie>(entity =>
            {
                entity.ToTable("TourSerie");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.TourSerie)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.TourSerieId);
            });

            modelBuilder.Entity<TournamentPlayerStat>(entity =>
            {
                entity.ToTable("TournamentPlayerStat");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TournamentPlayerStats)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentPlayerStats)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TournamentTeam>(entity =>
            {
                entity.ToTable("TournamentTeam");

                entity.Property(e => e.EntryFeePaid)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TournamentTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentTeams)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TournamentTeamStat>(entity =>
            {
                entity.ToTable("TournamentTeamStat");

                entity.Property(e => e.TournamentPhase).HasDefaultValueSql("1");

                entity.HasOne(d => d.TournamentTeam)
                    .WithMany(p => p.TournamentTeamStats)
                    .HasForeignKey(d => d.TournamentTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.EmailConfirmed)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ExternalLogin)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GuidexpirationDate).HasColumnName("GUIDExpirationDate");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit");

                entity.Property(e => e.PhoneNumberConfirmed)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RegistrationGuid).HasColumnName("RegistrationGUID");

                entity.Property(e => e.TwoFactorEnabled)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.ToTable("UserClaim");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.ToTable("UserLogin");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
