using Aurum.Domain.Entity.Product;
using Aurum.Domain.Repositories;
using Aurum.Infra.Data;
using Aurum.Infra.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Infra.Repositories
{
    public class ProductRepository(BaseAppDbContext context) : RepositoryBase<Product>(context), IProductRepository {
        //rem
    }

}
