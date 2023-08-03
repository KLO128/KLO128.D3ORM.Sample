
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class TournamentDTO
    {

        public int TournamentId { get; set; }
        public int? TourSerieId { get; set; }
        public int? AddressId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float? EntryFee { get; set; }
        public int? MaxNumOfTeams { get; set; }
        public string? Note { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public AddressDTO? Address { get; set; }
        public TourSerieDTO? TourSerie { get; set; }
        private ICollection<MatchDTO>? matches;
        public ICollection<MatchDTO> Matches
        {
            get
            {
                if (matches == null)
                {
                    matches = new List<MatchDTO>();
                }

                return matches;
            }
            set
            {
                matches = value;
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
