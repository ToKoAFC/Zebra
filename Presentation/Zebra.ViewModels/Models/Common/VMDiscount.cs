namespace Zebra.ViewModels.AdminCategory.Common
{
    public class VMDiscount
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int DiscountPercent { get; set; }
        public string Categories { get; set; }
    }
}
