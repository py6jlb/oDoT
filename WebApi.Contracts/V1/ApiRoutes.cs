namespace WebApi.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Cards
        {
            public const string GetAll = Base + "/cards";

            public const string Update = Base + "/cards";

            public const string Delete = Base + "/cards/{id}";

            public const string Get = Base + "/cards/{id}";

            public const string Create = Base + "/cards";
        }

        public static class Settings
        {
            public const string Get = Base + "/settings";
            public const string Update = Base + "/settings";
            public const string GetRefs = Base + "/settings/getRefs";
        }
    }
}