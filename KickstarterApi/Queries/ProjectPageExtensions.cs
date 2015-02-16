namespace KickstarterApi.Queries
{
    using System.Threading.Tasks;

    using KickstarterApi.Queries.Entities;

    public static class ProjectPageExtensions
    {
        public static Task<ProjectPage> LoadNextPageAsync(this ProjectPage projectPage, KickstarterClient client)
        {
            return ProjectQuery.LoadPageInternalAsync(client, projectPage.NextPageUrl);
        }
    }
}