using SCommerce.Main.Events.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCommerce.Main.Services
{
    public interface ICartService
    {
       Task AddAsync(int productId, int quantity);

        List<CartEntry> ListItemsForCheckout();

        void Subtract(int productId, int quantity);

        void Remove(int productId);

    }
}