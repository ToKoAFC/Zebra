using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Zebra.ViewModels.View.AdminPrice
{
    public class VMAdminPriceCreate
    {
        public int CategoryId { get; set; }

        public SelectList Categories { get; set; }

        [Range(1, 100)]
        public int DiscountPercent { get; set; }
    }
}
