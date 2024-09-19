using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Infra.Data {
    internal class BaseAppDbContextFactory : IDesignTimeDbContextFactory<BaseAppDbContext> {
        public BaseAppDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<BaseAppDbContext>();
            
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new BaseAppDbContext(optionsBuilder.Options);
        }
    }
}
