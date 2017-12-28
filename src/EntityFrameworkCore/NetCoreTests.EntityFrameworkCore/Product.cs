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

        public string Code { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductCategory> Categories { get; set; }

        public virtual void AddCategory(Category category)
        {
            _productCategories.Add(new ProductCategory
            {
                Category = category
            });
        }

        public virtual void RemoveCategory(Category category)
        {
            var productCategory = _productCategories.FirstOrDefault(c => c.Category == category);
            _productCategories.Remove(productCategory);
        }
    }
}
