
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class PlayoffRoundCoupleDTO
    {

        public int PlayoffRoundCoupleId { get; set; }
        public int TournamentTeam1Id { get; set; }
        public int TournamentTeam2Id { get; set; }
        public int PlayoffRound { get; set; }
        public int Team1Wins { get; set; }
        public int Team2Wins { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public TournamentTeamDTO TournamentTeam1 { get; set; } = null!;
        public TournamentTeamDTO TournamentTeam2 { get; set; } = null!;
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

    }
}
