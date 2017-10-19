using System.Collections.Generic;
using System.Linq;
using Zebra.Database.Access;
using Zebra.ViewModels.AdminCategory;

namespace Zebra.Services
{
    public class CategoryService
    {
        private CategoryAccess _categoryAccess { get; set; }

        public List<VMCategory> GetCategories()
        {
            var coreCategories = _categoryAccess.GetCoreCategories();
            return coreCategories.Select(c => new VMCategory
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
        }
    }
}
