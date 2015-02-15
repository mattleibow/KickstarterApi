namespace KickstarterApi.Queries
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using KickstarterApi.Model;

    public class FindCategory : IQuery<Category>
    {
        private readonly string _name;

        public FindCategory(string name)
        {
            this._name = name;
        }

        public async Task<Category> ApplyTo(IKickstarterSession session)
        {
            var categoryList = await session.Query(new AllCategories());
            return categoryList.Categories.FirstOrDefault(c => String.Equals(c.Name, this._name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}