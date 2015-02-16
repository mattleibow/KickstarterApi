namespace KickstarterApi.Queries
{
    public static class KickstarterQueryExtensions
    {
        public static CategoryQuery QueryCategories(this KickstarterClient client)
        {
            return new CategoryQuery(client);
        }

        public static ProjectQuery QueryProjects(this KickstarterClient client)
        {
            return new ProjectQuery(client);
        }
    }
}