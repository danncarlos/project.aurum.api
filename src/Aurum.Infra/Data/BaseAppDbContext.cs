using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurum.Domain.Entity.Product;
using Aurum.Infra.Map;
using Microsoft.EntityFrameworkCore;


namespace Aurum.Infra.Data {
    public class BaseAppDbContext : DbContext {
        public BaseAppDbContext(DbContextOptions<BaseAppDbContext> options) : base(options) {
            //Database.set
        }

        //DBSET
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>(entity => {            });

            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}
