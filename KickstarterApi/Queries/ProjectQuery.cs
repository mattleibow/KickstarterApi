namespace KickstarterApi.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using KickstarterApi.Model;
    using KickstarterApi.Queries.Entities;

    using Category = KickstarterApi.Queries.Entities.Category;

    public class ProjectQuery : KickstarterQuery
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private int _projectCap = 20;

        public ProjectQuery(KickstarterClient client)
            : base(client)
        {
        }

        public ProjectQuery FilterCategory(Category category)
        {
            return this.FilterCategory(category.Id);
        }

        public ProjectQuery FilterCategory(long categoryId)
        {
            this._parameters["category_id"] = categoryId.ToString();
            return this;
        }

        public ProjectQuery FilterStatus(ProjectStatus status)
        {
            switch (status)
            {
                case ProjectStatus.Live:
                    this._parameters["state"] = "live";
                    break;
                case ProjectStatus.Successful:
                    this._parameters["state"] = "successful";
                    break;
                case ProjectStatus.All:
                    this._parameters["state"] = string.Empty;
                    break;
                default:
                    this._parameters["state"] = string.Empty;
                    break;
            }
            return this;
        }

        public ProjectQuery FilterPage(int pageNumber)
        {
            this._parameters["page"] = pageNumber.ToString();
            return this;
        }

        public ProjectQuery SortBy(ProjectSort sort)
        {
            switch (sort)
            {
                case ProjectSort.Magic:
                    this._parameters["sort"] = "magic";
                    break;
                case ProjectSort.Popularity:
                    this._parameters["sort"] = "popularity";
                    break;
                case ProjectSort.Newest:
                    this._parameters["sort"] = "newest";
                    break;
                case ProjectSort.EndDate:
                    this._parameters["sort"] = "end_date";
                    break;
                case ProjectSort.MostFunded:
                    this._parameters["sort"] = "most_funded";
                    break;
                default:
                    this._parameters["sort"] = string.Empty;
                    break;
            }

            return this;
        }

        public async Task<ProjectPage> LoadPageAsync()
        {
            var builder = new StringBuilder("v1/discover");
            if (this._parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", this._parameters.Select(p => string.Format("{0}={1}", p.Key, p.Value))));
            }

            return await LoadPageInternalAsync(this.Client, builder.ToString());
        }

        internal static async Task<ProjectPage> LoadPageInternalAsync(KickstarterClient client, string url)
        {
            var page = await client.GetAsync<ProjectsList>(url);
            return ModelMapper.FromResult(page);
        }
    }
}