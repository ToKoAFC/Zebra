using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Common;

namespace Zebra.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryAccess _categoryAccess;
        public CategoryService(ICategoryAccess categoryAccess)
        {
            _categoryAccess = categoryAccess;
        }

        public List<VMCategory> GetCategories()
        {
            var coreCategories = _categoryAccess.GetCoreCategories();
            return coreCategories.Select(c => new VMCategory
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
        }

        public void SaveCategory(VMCategory category)
        {
            var coreCategory = new CoreCategory
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            _categoryAccess.SaveCategory(coreCategory);
        }

        public bool DeleteCategory(int categoryId)
        {
            return _categoryAccess.DeleteCategory(categoryId);
        }

        public VMCategory GetCategory(int categoryId)
        {
            var coreCat = _categoryAccess.GetCategory(categoryId);
            if (coreCat == null)
            {
                return null;
            }
            return new VMCategory
            {
                CategoryId = coreCat.CategoryId,
                CategoryName = coreCat.CategoryName,
            };
        }

        public SelectList GetCategorySelectList()
        {
            var coreCategories = _categoryAccess.GetCoreCategories();
            var selectListItems = coreCategories.Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName
            }).ToList();
            return new SelectList(selectListItems, "Value", "Text");
        }
}
}