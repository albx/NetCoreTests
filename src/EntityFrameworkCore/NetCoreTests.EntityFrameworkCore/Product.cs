using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreTests.EntityFrameworkCore
{
    public class Product
    {
        protected ICollection<ProductCategory> _productCategories;

        public Product()
        {
            _productCategories = new HashSet<ProductCategory>();
        }

        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductCategory> Categories => _productCategories;

        public virtual void AddCategory(Category category)
        {
            _productCategories.Add(new ProductCategory
            {
                Id = Guid.NewGuid(),
                Category = category
            });
        }
    }
}
