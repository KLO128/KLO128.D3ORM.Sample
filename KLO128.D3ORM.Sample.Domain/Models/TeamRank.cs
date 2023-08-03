namespace KLO128.D3ORM.Sample.Domain.Models
{
    public class TeamRank
    {
        public int TeamRankId { get; set; }

        public string Name { get; set; } = null!;

        public string? Logo { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastChange { get; set; } = DateTime.UtcNow;

        public int? ChangedBy { get; set; }
    }
}
