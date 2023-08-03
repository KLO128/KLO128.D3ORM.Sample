using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MySQL.Db
{
    public partial class TourSerie
    {
        public TourSerie()
        {
            Tournaments = new HashSet<Tournament>();
        }

        public int TourSerieId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Category { get; set; }
        public string? Note { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
