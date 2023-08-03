
///
/// generated file
///

using System;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs.Entities
{
    public class AddressDTO
    {

        public int AddressId { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Town { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
    }
}
