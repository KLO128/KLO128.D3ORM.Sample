using KLO128.D3ORM.Sample.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class CreateTeamArgs : IArgs
    {
        [Display(Name = nameof(Translations.Name), ResourceType = typeof(Translations))]
        [Required]
        public string Name { get; set; } = null!;

        public string? RequestToken { get; set; }
    }
}
