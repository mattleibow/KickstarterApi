namespace KickstarterApi.Queries.Entities
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectPage
    {
        public IEnumerable<Project> Projects { get; set; }

        public int ProjectCount { get; set; }

        public int CurrentPage { get; set; }

        internal string NextPageUrl { get; set; }
    }

    public class Project
    {
    }
}