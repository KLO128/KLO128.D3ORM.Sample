using KLO128.D3ORM.Sample.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs
{
    public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute
    {
        public CompareAttribute(string otherProperty) : base(otherProperty)
        {
            ErrorMessageResourceName = nameof(Translations.msgCompareFailed);
            ErrorMessageResourceType = typeof(Translations);
        }
    }
}
