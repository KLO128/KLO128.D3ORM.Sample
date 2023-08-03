
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
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
