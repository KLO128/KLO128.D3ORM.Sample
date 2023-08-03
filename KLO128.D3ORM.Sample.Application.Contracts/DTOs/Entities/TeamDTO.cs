
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class TeamDTO
    {

        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        private ICollection<TeamPlayerDTO>? teamPlayers;
        public ICollection<TeamPlayerDTO> TeamPlayers
        {
            get
            {
                if (teamPlayers == null)
                {
                    teamPlayers = new List<TeamPlayerDTO>();
                }

                return teamPlayers;
            }
            set
            {
                teamPlayers = value;
            }
        }

        private ICollection<TournamentTeamDTO>? tournamentTeams;
        public ICollection<TournamentTeamDTO> TournamentTeams
        {
            get
            {
                if (tournamentTeams == null)
                {
                    tournamentTeams = new List<TournamentTeamDTO>();
                }

                return tournamentTeams;
            }
            set
            {
                tournamentTeams = value;
            }
        }

    }
}
