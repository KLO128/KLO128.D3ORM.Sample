namespace KLO128.D3ORM.Sample.Domain.Shared
{
    public static class Constants
    {
        public const string DefaultCulture = "en-US";

        public const string DtoPatternFormat = @"{0}(DTO|Rank)";

        public static class AppSettingKeys
        {
            public const string DefaultConnectionString = "Default";
        }

        public static class WebApi
        {
            public const string AcceptLanguage = "Accept-Language";
            public const string UserSessionKey = "user";
            public const string LanguageSessionKey = "language";
            public const string requestToken = "requestToken";
        }


        public static class MyClaimTypes
        {
            public const string Id = "Id";
            public const string RoleId = "RoleId";
        }
    }
}
