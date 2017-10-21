using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Zebra.ViewModels.View.AdminCategory
{
    public class VMAdminCategoryCreate
    {
        [Display(Name ="Nazwa kategorii")]
        [StringLength(25), Required]
        public string CategoryName { get; set; }

        public int ParentCategoryId { get; set; }

        [Display(Name = "Kategoria nadrzędna")]
        public SelectList CategoryList { get; set; }
    }
}
