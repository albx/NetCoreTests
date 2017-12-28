using System;

namespace NetCoreTests.EntityFrameworkCore
{
    public class ProductCategory
    {
        public Guid Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Category Category { get; set; }
    }
}
