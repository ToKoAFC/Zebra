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
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<DbProduct> Products { get; set; }
    }
}
