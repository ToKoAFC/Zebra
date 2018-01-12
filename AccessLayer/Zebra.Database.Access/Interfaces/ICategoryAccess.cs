using System.Collections.Generic;
using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface ICategoryAccess
    {
        List<CoreCategory> GetCoreCategories();
        CoreCategory GetCategory(int categoryId);
        void SaveCategory(CoreCategory category);        
        bool DeleteCategory(int categoryId);
    }
}
