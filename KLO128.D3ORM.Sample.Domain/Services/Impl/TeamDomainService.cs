using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Domain.Services.Impl
{
    public class TeamDomainService : ITeamDomainService
    {
        public IQueryContainer QC { get; set; }
        private ITeamRepository TeamRepository { get; set; }

        private ITeamPlayerRepository TeamPlayerRepository { get; set; }

        private IUserRepository UserRepository { get; set; }

        public TeamDomainService(IQueryContainer QC, ITeamRepository TeamRepository, ITeamPlayerRepository TeamPlayerRepository, IUserRepository UserRepository)
        {
            this.QC = QC;
            this.TeamRepository = TeamRepository;
            this.TeamPlayerRepository = TeamPlayerRepository;
            this.UserRepository = UserRepository;
        }

        public Team AddPlayer(int teamId, int playerId, int changedById)
        {
            if (TeamRepository.FindBy(QC.GetTeamIdBaseFilterQuery(teamId)) is not Team team)
            {
                throw Errors.GetTeamNotFound(teamId.ToString());
            }

            return AddPlayer(team, playerId, changedById);
        }

        public Team AddPlayer(Team team, int playerId, int changedById)
        {
            if (UserRepository.FindByIdSingle(playerId) is not User player)
            {
                throw Errors.GetPlayerNotExists(playerId.ToString());
            }
            else if (team.TeamPlayers.Any(x => x.PlayerId == playerId))
            {
                throw Errors.GetPlayerAlreadyInTeam(player.Email, team.Name);
            }

            var toAdd = new TeamPlayer
            {
                PlayerId = playerId,
                TeamId = team.TeamId,
                Player = player
            };

            TeamPlayerRepository.AddAsChild(team, x => x.TeamPlayers, toAdd);
            TeamRepository.UpdateProperties(team, x => x.LastChange, DateTime.UtcNow, x => x.ChangedBy, changedById);

            return team;
        }

        public Team CreateTeam(string name, int changedById)
        {
            if (TeamRepository.FindBy(QC.GetTeamNameFilterQuery(name)) is Team team)
            {
                throw Errors.GetTeamAlreadyExists(name);
            }

            var now = DateTime.UtcNow;

            var toAdd = new Team
            {
                IsActive = true,
                Name = name,
                RegistrationDate = now,
                ChangedBy = changedById,
                LastChange = now,
            };

            TeamRepository.AddRoot(toAdd);

            return toAdd;
        }

        public Team GetTeamData(int teamId)
        {
            var team = TeamRepository.FindBy(QC.GetTeamIdBaseFilterQuery(teamId));

            if (team == null)
            {
                throw Errors.GetTeamNotFound(teamId.ToString());
            }

            return team;
        }

        public bool RemovePlayer(int teamId, int playerId, int changedById)
        {
            var teamData = GetTeamData(teamId);

            if (teamData.TeamPlayers.FirstOrDefault(x => x.PlayerId == playerId) is not TeamPlayer player)
            {
                throw Errors.GetPlayerNotFoundInTeam(playerId.ToString(), teamData.Name);
            }

            TeamPlayerRepository.DeleteFromParent(teamData, x => x.TeamPlayers, player);
            TeamRepository.UpdateProperties(teamData, x => x.LastChange, DateTime.UtcNow, x => x.ChangedBy, changedById);

            return true;
        }

        public List<TournamentTeam> GetTeamStats(int? teamIdFilter = null, int? tournamentIdFilter = null, int? tournamentPhase = null)
        {
            if (teamIdFilter == null && tournamentIdFilter == null)
            {
                throw Errors.EmptyFilter();
            }

            var teamData = GetTeamsAndStats(teamIdFilter, false, tournamentIdFilter, tournamentPhase);

            return teamData.Select(x => x.TournamentTeams).SelectMany(x => x).ToList();
        }

        public Team GetTeamAndStats(int teamId, int? tournamentIdFilter = null, int? tournamentPhase = null)
        {
            return GetTeamsAndStats(teamId, true, tournamentIdFilter, tournamentPhase).First();
        }

        private List<Team> GetTeamsAndStats(int? teamId, bool throwExp, int? tournamentId = null, int? tournamentPhase = null)
        {
            var teamData = TeamRepository.FindManyBy(QC.GetTeamBaseTournamentTeamStatsFilterQuery(tournamentId, teamId, tournamentPhase));

            if (throwExp && teamData.Count == 0)
            {
                throw Errors.GetTournamentTeamStatsNotFound(teamId?.ToString() ?? "n.a.");
            }

            return teamData;
        }
    }
}
