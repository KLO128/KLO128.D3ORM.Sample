using KLO128.D3ORM.Sample.Domain.Shared;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Presentation.WebApi.Extensions
{
    public class MyLocalizer : IStringLocalizer
    {
        public static Dictionary<string, CultureInfo> AllCultures { get; } = CultureInfo.GetCultures(CultureTypes.AllCultures).ToDictionary(x => x.Name);

        public ResourceManager ResourceManager { get; set; }

        public MyLocalizer(ResourceManager ResourceManager)
        {
            this.ResourceManager = ResourceManager;
        }

        private CultureInfo? culture;
        private string? cultureStr;

        public string CultureString
        {
            get
            {
                if (cultureStr == null)
                {
                    cultureStr = CultureInfo.DefaultThreadCurrentUICulture?.Name ?? Constants.DefaultCulture;
                }

                return cultureStr;
            }
            set
            {
                if (AllCultures.ContainsKey(value))
                {
                    cultureStr = value;
                    Culture = new CultureInfo(value);
                }
            }
        }

        protected CultureInfo Culture
        {
            get
            {
                return culture ?? CultureInfo.DefaultThreadCurrentUICulture ?? new CultureInfo(Constants.DefaultCulture);
            }
            set
            {
                culture = value;
            }
        }

        public LocalizedString this[string name]
        {
            get
            {
                return new LocalizedString(name, ResourceManager.GetString(name, Culture) ?? name);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                return new LocalizedString(name, string.Format(ResourceManager.GetString(name, Culture) ?? name, arguments));
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }
    }
}
