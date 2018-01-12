﻿namespace Zebra.CoreModels
{
    public class CoreCategoryDiscount
    {
        public int CategoryId { get; set; }
        public int DiscountId { get; set; }
        public int DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
