using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;

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

        public void CreateCategory(string categoryName, int? parentId)
        {
            _categoryAccess.AddNewCategory(categoryName, parentId);
        }
    }
}