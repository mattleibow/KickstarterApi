namespace KickstarterApi.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using KickstarterApi.Model;

    public class DiscoverProjects : IQuery<IEnumerable<Project>>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private int _projectCap = 20;

        public DiscoverProjects InCategory(Category category)
        {
            this._parameters["category_id"] = category.Id;
            return this;
        }

        public DiscoverProjects InStatus(string status)
        {
            this._parameters["state"] = status;
            return this;
        }

        public DiscoverProjects SortedBy(string sort)
        {
            this._parameters["sort"] = sort;
            return this;
        }

        public DiscoverProjects Take(int numberOfProjects)
        {
            this._projectCap = numberOfProjects;
            return this;
        }

        public async Task<IEnumerable<Project>> ApplyTo(IKickstarterSession session)
        {
            var results = new List<Project>();

            var currentUrl = this.MakeUrl();
            var numberOfProjects = 0;

            while(true)
            {
                var page = await session.Get<ProjectsList>(currentUrl);
                results.AddRange(page.Projects);
                numberOfProjects += page.Projects.Count();
                if (!page.Projects.Any() || numberOfProjects >= this._projectCap)
                    break;
                currentUrl = page.ApiLink("more_projects");
            }

            return results;
        }

        private string MakeUrl()
        {
            var builder = new StringBuilder("v1/discover");
            if (this._parameters.Any())
                builder.Append("?");
            builder.Append(String.Join("&", from p in this._parameters select String.Format("{0}={1}", p.Key, p.Value)));
            return builder.ToString();
        }
    }
}