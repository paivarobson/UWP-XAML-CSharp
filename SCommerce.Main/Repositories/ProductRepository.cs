using SCommerce.Main.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task AddAsync(Product product)
        {
            using (var db = new SCommerceDb())
            {
                db.Products.Add(product);

                await db.SaveChangesAsync();
            }
        }
    }
}
