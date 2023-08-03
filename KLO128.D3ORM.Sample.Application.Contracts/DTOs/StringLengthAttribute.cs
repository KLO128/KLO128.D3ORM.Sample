using KLO128.D3ORM.Sample.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs
{
    public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public StringLengthAttribute(int maximumLength, int minimumLength = 0) : base(maximumLength)
        {
            MinimumLength = minimumLength;
            ErrorMessageResourceName = nameof(Translations.msgStringLengthFailed);
            ErrorMessageResourceType = typeof(Translations);
        }
    }
}
