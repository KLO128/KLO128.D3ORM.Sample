namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class CreateTournamentArgs : IArgs
    {
        [Required]
        public string Name { get; set; } = null!;

        public int? AddressId { get; set; }

        public int? TourSerieId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float? EntryFee { get; set; }

        public int? MaxNumOfTeams { get; set; }

        public string? RequestToken { get; set; }
    }
}
