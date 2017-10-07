using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zebra.Database.Models
{
    public class DbProductPrice
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductPriceId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal Value { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual DbProduct Product { get; set; }
    }
}
