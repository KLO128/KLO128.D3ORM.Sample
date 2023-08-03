
///
/// generated file
///

using System;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class TournamentPlayerStatDTO
    {

        public int TournamentPlayerStatId { get; set; }
        public int TournamentId { get; set; }
        public int PlayerId { get; set; }
        public int? TourPoints { get; set; }
        public int? AttackPoints { get; set; }
        public float? AttackPercentage { get; set; }
        public int? ServicePoints { get; set; }
        public int? ServicePercentage { get; set; }
        public int? UnforcedErrors { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public UserDTO Player { get; set; } = null!;
        public TournamentDTO Tournament { get; set; } = null!;
    }
}
