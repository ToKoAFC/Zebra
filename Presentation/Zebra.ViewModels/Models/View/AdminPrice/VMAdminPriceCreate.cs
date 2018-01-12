using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Zebra.ViewModels.View.AdminPrice
{
    public class VMAdminPriceCreate
    {
        public int DiscountId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SelectList Categories { get; set; }

        [Range(1, 100)]
        public int DiscountPercent { get; set; }
    }
}
