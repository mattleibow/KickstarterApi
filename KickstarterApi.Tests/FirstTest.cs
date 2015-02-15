namespace KickstarterApi.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using KickstarterApi.Queries;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FirstTest
    {
        [TestMethod]
        public async Task FirstTestMethod()
        {
            var client = new KickstarterClient();

            var session = await client.StartSession("EMAIL", "PASSWORD");

            var tableTop = await session.Query(new FindCategory("Tabletop Games"));

            var projects = new DiscoverProjects()
                          .InCategory(tableTop)
                          .InStatus("live")
                          .SortedBy("launch_date")
                          .Take(200);

            var query = from p in await session.Query(projects) 
                        orderby p.LaunchedAt 
                        select p;

            var list = query.ToList();
        }
    }
}
