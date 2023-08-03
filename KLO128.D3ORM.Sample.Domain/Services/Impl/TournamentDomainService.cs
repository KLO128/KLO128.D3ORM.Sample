using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Domain.Services.Impl
{
    public class TournamentDomainService : ITournamentDomainService
    {
        public IQueryContainer QC { get; set; }
        private ITournamentRepository TournamentRepository { get; set; }

        public IAddressRepository AddressRepository { get; set; }

        private ITournamentTeamRepository TournamentTeamRepository { get; set; }

        private ITournamentTeamStatRepository TournamentTeamStatRepository { get; set; }

        private ITeamRepository TeamRepository { get; set; }

        private IMatchRepository MatchRepository { get; set; }

        private ITourSerieRepository TourSerieRepository { get; set; }

        public TournamentDomainService(IQueryContainer QC, ITournamentRepository TournamentRepository, IAddressRepository AddressRepository, ITournamentTeamRepository TournamentTeamRepository, ITournamentTeamStatRepository TournamentTeamStatRepository, ITeamRepository TeamRepository, IMatchRepository MatchRepository, ITourSerieRepository TourSerieRepository)
        {
            this.QC = QC;
            this.TournamentRepository = TournamentRepository;
            this.AddressRepository = AddressRepository;
            this.TournamentTeamRepository = TournamentTeamRepository;
            this.TournamentTeamStatRepository = TournamentTeamStatRepository;
            this.TeamRepository = TeamRepository;
            this.MatchRepository = MatchRepository;
            this.TourSerieRepository = TourSerieRepository;
        }

        public Tournament CreateTournament(string name, int entryFee, int maxNumOfTeams, int tourSerieId, int addressId, int changedById, DateTime startDate, DateTime endDate)
        {
            if (AddressRepository.FindByIdSingle(addressId) is not Address address)
            {
                throw Errors.GetAddressNotFound(addressId.ToString());
            }

            return CreateTournament(name, entryFee, maxNumOfTeams, tourSerieId > 0 ? TourSerieRepository.FindByIdSingle(tourSerieId) : null, address, changedById, startDate, endDate);
        }

        public Tournament CreateTournament(string name, int entryFee, int maxNumOfTeams, TourSerie? tourSerie, Address address, int changedById, DateTime startDate, DateTime endDate)
        {
            if (tourSerie == null)
            {
                tourSerie = new TourSerie
                {
                    Name = string.Concat(name, " Series"),
                    StartDate = startDate
                };

                TourSerieRepository.AddRoot(tourSerie);
            }

            var tournament = new Tournament
            {
                AddressId = address.AddressId,
                EntryFee = entryFee,
                MaxNumOfTeams = maxNumOfTeams,
                Name = name,
                TourSerieId = tourSerie.TourSerieId,
                LastChange = DateTime.UtcNow,
                ChangedBy = changedById,
                StartDate = startDate,
                EndDate = endDate
            };

            if (address.AddressId == 0)
            {
                tournament.Address = address;
            }

            //TournamentRepository.AddAsChild(tourSerie, x => x.Tournaments, tournament);

            //if ((tourSerieId ?? 0) == 0)
            //{
            //    tournament.TourSerie = tourSerie;
            //}

            TournamentRepository.AddRoot(tournament);

            return tournament;
        }

        public List<Match> GetMatches(int? tournamentIdFilter = null, int? tournamentPhase = null, int? teamIdFilter = null)
        {
            if (teamIdFilter == null && tournamentIdFilter == null)
            {
                throw Errors.EmptyFilter();
            }

            var matches = MatchRepository.FindManyBy(QC.GetMatchBaseTournamentPhaseAndTeamIdFilterQuery(tournamentIdFilter, teamIdFilter, tournamentPhase));

            return matches;
        }

        public TournamentTeam CreateTournamentTeam(int teamId, int tournamentId, int changedById)
        {
            var team = TeamRepository.FindByIdSingle(teamId);

            if (team == null)
            {
                throw Errors.GetTeamNotFound(teamId.ToString());
            }

            var tournament = TournamentRepository.FindByIdSingle(tournamentId);

            if (tournament == null)
            {
                throw Errors.GetTournamentNotFound(tournamentId.ToString());
            }

            return CreateTournamentTeam(team, tournament, changedById);
        }

        public TournamentTeam CreateTournamentTeam(Team team, Tournament tournament, int changedById)
        {
            if (TournamentTeamRepository.FindBy(QC.GetTournamentTeamFilterQuery(tournament.TournamentId, team.TeamId)) is TournamentTeam)
            {
                throw Errors.GetTeamAlreadyRegisteredToTournament(team.Name, tournament.Name);
            }

            var tournamentTeam = new TournamentTeam
            {
                TeamId = team.TeamId,
                Team = team,
                TournamentId = tournament.TournamentId,
                Tournament = tournament,
                RegistrationDate = DateTime.UtcNow,
                LastChange = DateTime.UtcNow,
                ChangedBy = changedById
            };

            TournamentTeamRepository.AddAsChild(tournament, x => x.TournamentTeams, tournamentTeam);

            tournament.TournamentTeams.Clear();

            return tournamentTeam;
        }

        public void CreateEmptyStats(TournamentTeam tournamentTeam, int tournamentPhase, int changedById)
        {
            var toAdd = new TournamentTeamStat
            {
                ChangedBy = changedById,
                LastChange = DateTime.UtcNow,
                TournamentPhase = tournamentPhase,
                TournamentTeamId = tournamentTeam.TournamentTeamId
            };

            TournamentTeamStatRepository.AddAsChild(tournamentTeam, x => x.TournamentTeamStats, toAdd);
        }
    }
}
