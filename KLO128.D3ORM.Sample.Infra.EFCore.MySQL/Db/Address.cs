using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class Address
    {
        public Address()
        {
            Tournaments = new HashSet<Tournament>();
        }

        public int AddressId { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Town { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
