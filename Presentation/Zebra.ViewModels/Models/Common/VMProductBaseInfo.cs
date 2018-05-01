using System.Collections.Generic;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.ViewModels.Common
{
    public class VMProductBaseInfo
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Barcode { get; set; }
        public string Description { get; set; }
        public string BasePrice { get; set; }
        public string FileName { get; set; }
        public bool HasImage { get; set; }
        public List<VMCategory> Categories { get; set; }
    }
    public class VMCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
