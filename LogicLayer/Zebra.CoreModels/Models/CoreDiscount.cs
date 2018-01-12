using System.Collections.Generic;

namespace Zebra.CoreModels
{
    public class CoreDiscount
    {
        public int DiscountId { get; set; }
        public int DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CoreCategory> Categories { get; set; }
    }
}
