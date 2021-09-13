using SCommerce.Main.Entities;
using System.Threading.Tasks;

namespace SCommerce.Main.Services
{
    public interface IProductService
    {
        Task<Product> FindAsync(int id);
    }
}