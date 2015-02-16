namespace KickstarterApi.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KickstarterApi.Model;

    using Category = KickstarterApi.Queries.Entities.Category;

    public class CategoryQuery : KickstarterQuery
    {
        public CategoryQuery(KickstarterClient client)
            : base(client)
        {
        }

        public async Task<IEnumerable<Category>> LoadAllAsync()
        {
            var result = await this.Client.GetAsync<CategoryList>("v1/categories");
            return ModelMapper.FromResult(result.Categories);
        }

        public async Task<Category> LoadBySlugAsync(string slug)
        {
            if (slug.Contains("/") || slug.Contains("\\"))
            {
                throw new QueryException("Only root categories can be loaded from slugs.");
            }

            var result = await this.Client.GetAsync<Model.Category>(string.Format("v1/categories/{0}", slug));
            return ModelMapper.FromResult(result);
        }

        public async Task<Category> LoadByIdAsync(long id)
        {
            var result = await this.Client.GetAsync<Model.Category>(string.Format("v1/categories/{0}", id));
            return ModelMapper.FromResult(result);
        }
    }
}