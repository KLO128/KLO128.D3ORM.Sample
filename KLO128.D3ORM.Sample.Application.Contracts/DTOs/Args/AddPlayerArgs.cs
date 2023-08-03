namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class AddPlayerArgs : IArgs
    {
        [Required]
        public int TeamId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public string? RequestToken { get; set; }
    }
}
