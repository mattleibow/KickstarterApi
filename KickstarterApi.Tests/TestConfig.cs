namespace KickstarterApi.Tests
{
    using System.Configuration;

    public static class TestConfig
    {
        public static string EmailAddress
        {
            get { return ConfigurationManager.AppSettings["emailAddress"]; }
        }

        public static string Password
        {
            get { return ConfigurationManager.AppSettings["password"]; }
        }
    }
}