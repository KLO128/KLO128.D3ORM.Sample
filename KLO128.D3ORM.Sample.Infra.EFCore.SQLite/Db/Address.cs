using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class Address
    {
        public Address()
        {
            Tournaments = new HashSet<Tournament>();
        }

        public long AddressId { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Town { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
