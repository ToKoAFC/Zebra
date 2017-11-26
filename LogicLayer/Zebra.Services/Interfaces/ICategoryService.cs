using System.Collections.Generic;
using System.Web.Mvc;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Services.Interfaces
{
    public interface ICategoryService
    {
        List<VMCategory> GetCategories();
        SelectList GetCategorySelectList();
        void CreateCategory(string categoryName, int? parentId);
    }
}