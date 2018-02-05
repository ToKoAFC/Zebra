using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zebra.Database.Models
{
    [Table("Categories")]
    public class DbCategory
    {
        public DbCategory()
        {
            Products = new HashSet<DbProduct>();
            Discounts = new HashSet<DbDiscount>();
            ChildrenCategories = new HashSet<DbCategory>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Editable(false)]
        public int ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual DbCategory ParentCategory { get; set; }
        public virtual ICollection<DbProduct> Products { get; set; }
        public virtual ICollection<DbDiscount> Discounts { get; set; }
        public virtual ICollection<DbCategory> ChildrenCategories { get; set; }
    }
}
