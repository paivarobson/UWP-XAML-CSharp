using SCommerce.Main.Entities;
using System.Threading.Tasks;

namespace SCommerce.Main.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
    }
}