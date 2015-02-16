namespace KickstarterApi.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class KickstarterTest
    {
        protected KickstarterClient Client;

        [TestInitialize]
        public void InitializeTest()
        {
            // create a new client for each test
            this.Client = KickstarterClient.CreateAsync(TestConfig.EmailAddress, TestConfig.Password).Result;
        }

        [TestCleanup]
        public void CleanupTest()
        {
            // make sure that the client is never used again
            this.Client = null;
        }
    }
}