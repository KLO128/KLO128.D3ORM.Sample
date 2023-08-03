using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Domain.Services.Impl
{
    public class TournamentPlayerStatDomainService : ITournamentPlayerStatDomainService
    {
        public IQueryContainer QC { get; set; }

        private ITournamentPlayerStatRepository TournamentPlayerStatRepository { get; set; }

        public TournamentPlayerStatDomainService(IQueryContainer QC, ITournamentPlayerStatRepository TournamentPlayerStatRepository)
        {
            this.QC = QC;
            this.TournamentPlayerStatRepository = TournamentPlayerStatRepository;
        }

        public List<TournamentPlayerStat> GetPlayerStats(int? playerIdFilter = null, int? tournamentIdFilter = null)
        {
            if (playerIdFilter == null && tournamentIdFilter == null)
            {
                throw Errors.EmptyFilter();
            }

            var stats = TournamentPlayerStatRepository.FindManyBy(QC.GetTourPlayerStatBaseFilterQuery(playerIdFilter, tournamentIdFilter));

            return stats;
        }
    }
}
