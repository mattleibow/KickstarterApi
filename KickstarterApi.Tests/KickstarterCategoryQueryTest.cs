namespace KickstarterApi.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using KickstarterApi.Queries;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KickstarterCategoryQueryTest : KickstarterTest
    {
        [TestMethod]
        public async Task LoadAllAsyncShouldLoadACollection()
        {
            var categories = await this.Client.QueryCategories().LoadAllAsync();
            Assert.IsNotNull(categories, "NULL category collection was returned.");

            var list = categories.ToList();
            Assert.IsTrue(list.Any(), "An empty category collection was returned.");

            var first = list[0];
            Assert.IsTrue(first.Id > 0, "ID is valid.");
            Assert.IsTrue(first.ParentId == 0, "Parent ID is valid.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(first.Name), "Name is valid.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(first.Slug), "Slug is valid.");

            var withParent = list.First(x => x.ParentId > 0);
            Assert.IsNotNull(withParent, "At least one category has a parent.");
        }

        [TestMethod]
        public async Task LoadBySlugAsyncWithChildSlugShouldThrow()
        {
            try
            {
                await this.Client.QueryCategories().LoadBySlugAsync("technology/apps");

                Assert.Fail("Expected a QueryException.");
            }
            catch (QueryException)
            {
                // do nothing
            }
        }

        [TestMethod]
        public async Task LoadBySlugAsyncWithRootSlugShouldSucceed()
        {
            var category = await this.Client.QueryCategories().LoadBySlugAsync("technology");
            Assert.IsNotNull(category, "NULL category was returned.");

            Assert.AreEqual(category.Id, 16, "ID is valid.");
            Assert.AreEqual(category.Name, "Technology", "Name is valid.");
            Assert.AreEqual(category.Slug, "technology", "Slug is valid.");
            Assert.AreEqual(category.ParentId, 0, "Parent ID is valid.");
        }

        [TestMethod]
        public async Task LoadByIdAsyncShouldSucceed()
        {
            var category = await this.Client.QueryCategories().LoadByIdAsync(332);
            Assert.IsNotNull(category, "NULL category was returned.");

            Assert.AreEqual(category.Id, 332, "ID is valid.");
            Assert.AreEqual(category.Name, "Apps", "Name is valid.");
            Assert.AreEqual(category.Slug, "technology/apps", "Slug is valid.");
            Assert.AreEqual(category.ParentId, 16, "Parent ID is valid.");
        }
    }
}
