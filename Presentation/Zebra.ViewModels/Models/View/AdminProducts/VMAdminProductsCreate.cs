using System.ComponentModel.DataAnnotations;

namespace Zebra.ViewModels.View.AdminProducts
{
    public class VMAdminProductsCreate
    {
        public int ProductId { get; set; }

        [Display(Name = "Nazwa produktu")]
        [StringLength(25), Required]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [StringLength(400), Required]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        public decimal BasePrice { get; set; }
        
    }
}
