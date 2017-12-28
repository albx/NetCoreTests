using NetCoreTests.EntityFrameworkCore.Data;
using NetCoreTests.EntityFrameworkCore.Tests.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace NetCoreTests.EntityFrameworkCore.Tests
{
    public class BackingFieldsTest : IClassFixture<TestContextFixture>
    {
        private TestContextFixture _fixture;

        private TestContext _context;

        public BackingFieldsTest(TestContextFixture fixture)
        {
            _fixture = fixture;
            _context = fixture.Context;
        }

        [Fact]
        public void Products_AddCategory_Should_Increment_Categories_Number()
        {
            var product = _context.Products.FirstOrDefault();
            Assert.NotNull(product);

            int categories = product.Categories.Count();

            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Category #2"
            };

            product.AddCategory(newCategory);
            _context.SaveChanges();

            Assert.Equal(categories + 1, product.Categories.Count());
        }

        [Fact]
        public void Categories_AddChild_Should_Increment_Children_Number()
        {
            var category = _context.Categories.FirstOrDefault();
            Assert.NotNull(category);

            var child = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Child #2"
            };

            int children = category.Children.Count();

            category.AddChild(child);
            _context.SaveChanges();

            Assert.Equal(children + 1, category.Children.Count());
        }
    }
}
