using System;
using System.Collections.Generic;

namespace NetCoreTests.EntityFrameworkCore
{
    public class Category
    {
        protected ICollection<Category> _children;

        public Category()
        {
            _children = new HashSet<Category>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Children => _children;

        public virtual void AddChild(Category child)
        {
            _children.Add(child);
        }
    }
}
