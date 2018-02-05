using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zebra.Database.Models
{
    [Table("Products")]
    public class DbProduct
    {
        public DbProduct()
        {
            Categories = new HashSet<DbCategory>();
            Files = new HashSet<DbFile>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProuductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public int Barcode { get; set; }

        [Range(0,double.MaxValue)]
        public decimal BasePrice { get; set; }
        
        public virtual ICollection<DbCategory> Categories { get; set; }
        public virtual ICollection<DbFile> Files { get; set; }
    }
}
