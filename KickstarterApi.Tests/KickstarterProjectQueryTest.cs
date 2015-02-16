namespace KickstarterApi.Tests
{
    using System.Threading.Tasks;

    using KickstarterApi.Queries;
    using KickstarterApi.Queries.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KickstarterProjectQueryTest : KickstarterTest
    {
        [TestMethod]
        public async Task LoadAllAsyncTestMethod()
        {
            var allProjects = await this.Client.QueryProjects().LoadPageAsync();
            var idProject1 = await this.Client.QueryProjects().SortBy(ProjectSort.MostFunded).LoadPageAsync();
            var idProject2 = await this.Client.QueryProjects().FilterStatus(ProjectStatus.Live).LoadPageAsync();
            var idProject3 = await this.Client.QueryProjects().FilterStatus(ProjectStatus.Live).SortBy(ProjectSort.MostFunded).LoadPageAsync();
            var idProject4 = await this.Client.QueryProjects().FilterCategory(16).FilterStatus(ProjectStatus.All).SortBy(ProjectSort.MostFunded).LoadPageAsync();
            var category = new Category{Id=16};
            var idProject5 = await this.Client.QueryProjects().FilterCategory(category).FilterStatus(ProjectStatus.Successful).SortBy(ProjectSort.MostFunded).LoadPageAsync();

            var idProject6 = await this.Client.QueryProjects().FilterPage(3).LoadPageAsync();

            var projects = allProjects.Projects;
            var pageNumber = allProjects.CurrentPage;

            var next1 = await idProject2.LoadNextPageAsync(this.Client);


            //var tableTop = await session.Query(new FindCategory("Tabletop Games"));

            //var projects = new DiscoverProjects()
            //              .InCategory(tableTop)
            //              .InStatus("live")
            //              .SortedBy("launch_date")
            //              .Take(5);

            //var query = from p in await session.Query(projects) 
            //            orderby p.LaunchedAt 
            //            select p;

            //var list = query.ToList();
        }
    }
}