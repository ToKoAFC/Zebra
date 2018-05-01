using System.Collections.Generic;
using System.Web.Mvc;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Common;

namespace Zebra.Services.Interfaces
{
    public interface ICategoryService
    {
        List<VMCategory> GetCategories();
        void SaveCategory(VMCategory category);
        bool DeleteCategory(int categoryId);
        VMCategory GetCategory(int categoryId);
        SelectList GetCategorySelectList();
    }
}