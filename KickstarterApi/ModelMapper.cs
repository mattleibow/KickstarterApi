namespace KickstarterApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KickstarterApi.Queries.Entities;

    internal static class ModelMapper
    {
        /// <summary>
        /// Map a collection of <see cref="KickstarterApi.Model.Category"/> to a collection of <see cref="Category"/>.
        /// </summary>
        /// <param name="categories">
        /// The <see cref="KickstarterApi.Model.Category"/> collection to map.
        /// </param>
        /// <returns>
        /// Returns the <see cref="Category"/> collection that was mapped.
        /// </returns>
        public static IEnumerable<Category> FromResult(IEnumerable<Model.Category> categories)
        {
            return categories.Select(FromResult);
        }

        /// <summary>
        /// Map a single <see cref="KickstarterApi.Model.Category"/> to a single <see cref="Category"/>.
        /// </summary>
        /// <param name="category">
        /// The <see cref="KickstarterApi.Model.Category"/> to map.
        /// </param>
        /// <returns>
        /// Returns the <see cref="Category"/> that was mapped.
        /// </returns>
        public static Category FromResult(Model.Category category)
        {
            if (category == null)
            {
                return null;
            }

            return new Category { Id = category.Id, Name = category.Name, Slug = category.Slug, ParentId = category.ParentId };
        }

        public static ProjectPage FromResult(Model.ProjectsList projectList)
        {
            var nextPageUrl = Model.HypermediaExtensions.ApiLink(projectList, "more_projects");
            var nextPage = new Uri(nextPageUrl).GetParameterValue("page", 2);
            return new ProjectPage
                       {
                           Projects = FromResult(projectList.Projects),
                           ProjectCount = projectList.Projects.Length,
                           NextPageUrl = nextPageUrl,
                           CurrentPage = nextPage - 1
                       };
        }

        public static IEnumerable<Project> FromResult(IEnumerable<Model.Project> projects)
        {
            return projects.Select(FromResult);
        }

        public static Project FromResult(Model.Project project)
        {
            if (project == null)
            {
                return null;
            }

            return new Project();
        }
    }
}