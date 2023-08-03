
///
/// generated file
///

using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class UserDTO
    {

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        private ICollection<TournamentPlayerStatDTO>? tournamentPlayerStats;
        public ICollection<TournamentPlayerStatDTO> TournamentPlayerStats
        {
            get
            {
                if (tournamentPlayerStats == null)
                {
                    tournamentPlayerStats = new List<TournamentPlayerStatDTO>();
                }

                return tournamentPlayerStats;
            }
            set
            {
                tournamentPlayerStats = value;
            }
        }

    }
}
