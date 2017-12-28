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

        public string Name { get; set; }

        public IEnumerable<Category> Children => _children;

        public virtual void AddChildren(Category child)
        {
            _children.Add(child);
        }

        public virtual void RemoveChildren(Category child)
        {
            _children.Remove(child);
        }
    }
}
