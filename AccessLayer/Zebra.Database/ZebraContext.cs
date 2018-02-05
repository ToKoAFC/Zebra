using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Zebra.Database.Models;

namespace Zebra.Database
{
    public class ZebraContext : IdentityDbContext<DbAppUser>
    {
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbCategory> Categories { get; set; }
        public DbSet<DbDiscount> Discounts { get; set; }
        public DbSet<DbDelivery> Deliveries { get; set; }
        public DbSet<DbFile> Files { get; set; }
        public DbSet<DbShop> Shops { get; set; }

        public ZebraContext()
            : base("ZebraContext", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            System.Data.Entity.Database.SetInitializer<ZebraContext>(null);
            base.OnModelCreating(builder);

            builder.Entity<DbCategory>()
                .HasMany(p => p.Products)
                .WithMany(r => r.Categories)
                .Map(mc =>
                {
                    mc.MapLeftKey("CategoryId");
                    mc.MapRightKey("ProductId");
                    mc.ToTable("ProductCategories");
                });
        }

        public static ZebraContext Create()
        {
            return new ZebraContext();
        }
        
    }
}
