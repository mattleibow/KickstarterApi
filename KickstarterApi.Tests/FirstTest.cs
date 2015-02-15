using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kickstarter.Api;
using Kickstarter.Api.Queries;

namespace Kickstarter.KickstarterApi.Tests
{
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
