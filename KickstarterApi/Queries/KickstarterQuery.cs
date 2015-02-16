namespace KickstarterApi
{
    public abstract class KickstarterQuery
    {
        protected readonly KickstarterClient Client;

        protected KickstarterQuery(KickstarterClient client)
        {
            this.Client = client;
        }
    }
}