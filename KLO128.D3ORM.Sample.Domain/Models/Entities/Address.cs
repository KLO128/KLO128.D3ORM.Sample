
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class Address
    {

        
        public int AddressId { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string State { get; set; } = null!;
        
        public string Town { get; set; } = null!;
        
        public string Street { get; set; } = null!;
        
        public string HouseNumber { get; set; } = null!;
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
    }
}