using KLO128.D3ORM.Sample.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs
{
    public class EmailAddressAttribute : ValidationAttribute
    {
        public System.ComponentModel.DataAnnotations.EmailAddressAttribute Inner { get; set; }

        public override bool RequiresValidationContext => true;

        public EmailAddressAttribute()
        {
            Inner = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
            ErrorMessageResourceName = nameof(Translations.msgInvalidEmail);
            ErrorMessageResourceType = typeof(Translations);
        }

        public override bool IsValid(object? value)
        {
            return Inner.IsValid(value);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return Inner.IsValid(value) ? ValidationResult.Success : new ValidationResult(Translations.msgInvalidEmail);
        }
    }
}
