namespace KickstarterApi.Queries
{
    using System.Threading.Tasks;

    using KickstarterApi.Model;

    public class AllCategories : IQuery<CategoryList>
    {
        public Task<CategoryList> ApplyTo(IKickstarterSession session)
        {
            return session.Get<CategoryList>("v1/categories");
        }
    }
}