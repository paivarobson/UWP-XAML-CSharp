using SCommerce.Main.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCommerce.Main.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product> FindAsync(int id);
        Task<List<Product>> ListAsync();
    }
}