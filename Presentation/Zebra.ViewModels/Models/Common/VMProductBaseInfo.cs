using System.Collections.Generic;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.ViewModels.Common
{
    public class VMProductBaseInfo
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BasePrice { get; set; }
        public string FileName { get; set; }
        public List<VMCategory> Categories { get; set; }
    }
}
