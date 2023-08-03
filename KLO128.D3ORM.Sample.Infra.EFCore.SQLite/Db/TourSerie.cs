using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class TourSerie
    {
        public TourSerie()
        {
            Tournaments = new HashSet<Tournament>();
        }

        public long TourSerieId { get; set; }
        public string Name { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string? EndDate { get; set; }
        public string? Category { get; set; }
        public string? Note { get; set; }
        public string LastChange { get; set; } = null!;
        public long? ChangedBy { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
