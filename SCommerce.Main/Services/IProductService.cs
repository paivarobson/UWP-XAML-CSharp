using SCommerce.Main.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace SCommerce.Main.Services
{
    public interface IProductService
    {
        Task<Product> FindAsync(int id);

        Task<Product> CreateAsync(string title, string description, int rating, double price, IList<StorageFile> images);
        Task<List<Product>> ListAsync();
    }
}