namespace KickstarterApi.Tests
{
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KickstarterClientTest
    {
        [TestMethod]
        public async Task CreateAsyncShouldSucceed()
        {
            var client = await KickstarterClient.CreateAsync(TestConfig.EmailAddress, TestConfig.Password);

            Assert.IsNotNull(client, "Client was not created.");
            Assert.IsNotNull(client.User, "User was not logged in.");
        }
    }
}