using System.Collections.Generic;
using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface ICategoryAccess
    {
        List<CoreCategory> GetCoreCategories();
        void AddNewCategory(string categoryName, int? categoryId);
    }
}
