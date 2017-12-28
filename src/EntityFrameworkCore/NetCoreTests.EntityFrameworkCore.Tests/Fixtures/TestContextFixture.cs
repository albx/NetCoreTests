using Microsoft.EntityFrameworkCore;
using NetCoreTests.EntityFrameworkCore.Data;
using System;

namespace NetCoreTests.EntityFrameworkCore.Tests.Fixtures
{
    public class TestContextFixture : IDisposable
    {
        public TestContext Context { get; protected set; }

        public TestContextFixture()
        {
            BuildContext();
            PrepareData();
        }

        public void Dispose()
        {
            CleanData();
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        #region Private Methods
        private void PrepareData()
        {
            var product = new Product
            {
                Code = "PR01",
                Name = "Product #1"
            };
            Context.Products.Add(product);

            var category = new Category
            {
                Name = "Category #1"
            };
            Context.Categories.Add(category);

            var childCategory = new Category
            {
                Name = "Child category #1"
            };
            category.AddChildren(childCategory);

            product.AddCategory(category);

            Context.SaveChanges();
        }

        private void CleanData()
        {
            Context.ProductCategories.RemoveRange(Context.ProductCategories);
            Context.Categories.RemoveRange(Context.Categories);
            Context.Products.RemoveRange(Context.Products);
        }

        private void BuildContext()
        {
            var options = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase(databaseName: "InMemory-Test")
                .Options;

            Context = new TestContext(options);
        }
        #endregion
    }
}
