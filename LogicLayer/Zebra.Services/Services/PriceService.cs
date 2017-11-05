using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zebra.Database.Access;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.View.AdminCategory;

namespace Zebra.Services
{
    public class PriceService
    {
        public PriceAccess _priceAccess { get; set; }
     
        public void CreateCategory(string categoryName, int? parentId)
        {
          //  _priceAccess.AddNewCategory(categoryName, parentId);
        }
    }
}