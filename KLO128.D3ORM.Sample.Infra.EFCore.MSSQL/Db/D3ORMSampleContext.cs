using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MSSQL.Db
{
    public partial class D3ORMSampleContext : DbContext
    {
        public D3ORMSampleContext()
        {
        }

        public D3ORMSampleContext(DbContextOptions<D3ORMSampleContext> options)
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
                optionsBuilder.UseSqlServer("Data Source=PK-DESKTOP;Initial Catalog=D3ORMSample;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(75);

                entity.Property(e => e.Town).HasMaxLength(50);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.HasIndex(e => e.AwayTeamId, "IXFK_Match_Away_Team");

                entity.HasIndex(e => e.HomeTeamId, "IXFK_Match_Home_Team");

                entity.HasIndex(e => e.PlayoffRoundCoupleId, "IXFK_Match_PlayoffRoundCouple");

                entity.HasIndex(e => e.TournamentId, "IXFK_Match_Tournament");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.Property(e => e.MatchDate).HasColumnType("datetime");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_AwayTeam");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_HomeTeam");

                entity.HasOne(d => d.PlayoffRoundCouple)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.PlayoffRoundCoupleId)
                    .HasConstraintName("FK_Match_PlayoffRoundCouple");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK_Match_Tournament");
            });

            modelBuilder.Entity<MatchSetScore>(entity =>
            {
                entity.ToTable("MatchSetScore");

                entity.HasIndex(e => e.MatchId, "IXFK_MatchSetScore_Match");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchSetScores)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchSetScore_Match");
            });

            modelBuilder.Entity<PlayoffRoundCouple>(entity =>
            {
                entity.ToTable("PlayoffRoundCouple");

                entity.HasIndex(e => e.TournamentTeam1Id, "IXFK_PlayoffRoundCouple_TournamentTeam1");

                entity.HasIndex(e => e.TournamentTeam2Id, "IXFK_PlayoffRoundCouple_TournamentTeam2");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.HasOne(d => d.TournamentTeam1)
                    .WithMany(p => p.PlayoffRoundCoupleTournamentTeam1s)
                    .HasForeignKey(d => d.TournamentTeam1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayoffRoundCouple_TournamentTeam1");

                entity.HasOne(d => d.TournamentTeam2)
                    .WithMany(p => p.PlayoffRoundCoupleTournamentTeam2s)
                    .HasForeignKey(d => d.TournamentTeam2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayoffRoundCouple_TournamentTeam2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.HasIndex(e => e.Name, "IX_TeamName");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TeamPlayer>(entity =>
            {
                entity.ToTable("TeamPlayer");

                entity.HasIndex(e => e.TeamId, "IXFK_TeamPlayer_Team");

                entity.HasIndex(e => e.PlayerId, "IXFK_TeamPlayer_User");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TeamPlayers)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamPlayer_User");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamPlayers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamPlayer_Team");
            });

            modelBuilder.Entity<TourSerie>(entity =>
            {
                entity.ToTable("TourSerie");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");

                entity.HasIndex(e => e.AddressId, "IXFK_Tournament_Address");

                entity.HasIndex(e => e.TourSerieId, "IXFK_Tournament_TourSerie");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Tournament_Address");

                entity.HasOne(d => d.TourSerie)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.TourSerieId)
                    .HasConstraintName("FK_Tournament_TourSerie");
            });

            modelBuilder.Entity<TournamentPlayerStat>(entity =>
            {
                entity.ToTable("TournamentPlayerStat");

                entity.HasIndex(e => e.TournamentId, "IXFK_TournamentPlayerStat_Tournament");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TournamentPlayerStats)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentPlayerStat_User");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentPlayerStats)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentPlayerStat_Tournament");
            });

            modelBuilder.Entity<TournamentTeam>(entity =>
            {
                entity.ToTable("TournamentTeam");

                entity.HasIndex(e => e.TeamId, "IXFK_TournamentTeam_Team");

                entity.HasIndex(e => e.TournamentId, "IXFK_TournamentTeam_Tournament");

                entity.Property(e => e.BasicGroupName).HasMaxLength(40);

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TournamentTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentTeam_Team");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentTeams)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentTeam_Tournament");
            });

            modelBuilder.Entity<TournamentTeamStat>(entity =>
            {
                entity.ToTable("TournamentTeamStat");

                entity.HasIndex(e => e.TournamentTeamId, "IXFK_TournamentTeamStat_TournamentTeam");

                entity.Property(e => e.LastChange).HasColumnType("datetime");

                entity.HasOne(d => d.TournamentTeam)
                    .WithMany(p => p.TournamentTeamStats)
                    .HasForeignKey(d => d.TournamentTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TournamentTeamStat_TournamentTeam");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(75);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GuidexpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("GUIDExpirationDate");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.RegistrationGuid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RegistrationGUID");

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.ToTable("UserClaim");

                entity.HasIndex(e => e.UserId, "IXFK_UserClaim_User");

                entity.Property(e => e.ClaimValue).HasMaxLength(500);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClaim_User");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.ToTable("UserLogin");

                entity.HasIndex(e => e.UserId, "IXFK_UserLogin_User");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLogin_User");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasIndex(e => e.RoleId, "IXFK_UserRole_Role");

                entity.HasIndex(e => e.UserId, "IXFK_UserRole_User");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
