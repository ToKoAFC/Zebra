using System.Collections.Generic;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Services.Interfaces
{
    public interface ICategoryService
    {
        List<VMCategory> GetCategories();
        void SaveCategory(VMCategory category);
        bool DeleteCategory(int categoryId);
        VMCategory GetCategory(int categoryId);
    }
}