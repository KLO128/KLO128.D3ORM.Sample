
///
/// generated file
///

using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class TournamentTeamDTO
    {

        public int TournamentTeamId { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public string? BasicGroupName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool EntryFeePaid { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public TeamDTO Team { get; set; } = null!;
        public TournamentDTO Tournament { get; set; } = null!;
        private ICollection<TournamentTeamStatDTO>? tournamentTeamStats;
        public ICollection<TournamentTeamStatDTO> TournamentTeamStats
        {
            get
            {
                if (tournamentTeamStats == null)
                {
                    tournamentTeamStats = new List<TournamentTeamStatDTO>();
                }

                return tournamentTeamStats;
            }
            set
            {
                tournamentTeamStats = value;
            }
        }

    }
}
