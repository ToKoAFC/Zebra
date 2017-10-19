using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;

namespace Zebra.Database.Access
{
    public class CategoryAccess
    {
        private readonly ZebraContext _context;
        public CategoryAccess(ZebraContext context)
        {
            _context = context;
        }

        public List<CoreCategory> GetCoreCategories()
        {
            return _context.Categories
                .Select(cat => new CoreCategory
                {
                    CategoryId = cat.CategoryId,
                    CategoryName = cat.Name
                })
                .ToList();
        }
    }
}
