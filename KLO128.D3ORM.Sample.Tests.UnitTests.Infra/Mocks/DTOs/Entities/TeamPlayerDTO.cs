
///
/// generated file
///

using System;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class TeamPlayerDTO
    {

        public int TeamPlayerId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public UserDTO Player { get; set; } = null!;
    }
}
