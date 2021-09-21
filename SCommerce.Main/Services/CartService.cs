using Prism.Events;
using SCommerce.Main.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Services
{
    public class CartService : ICartService
    {
        private readonly IEventAggregator eventAggregator;
        private Dictionary<int, int> cart;

        public CartService(IEventAggregator eventAggregator)
        {
            cart = new Dictionary<int, int>();
            this.eventAggregator = eventAggregator;
        }

        public void Add(int productId, int quantity)
        {
            if (cart.ContainsKey(productId))
            {
                cart[productId] += quantity;
            }
            else
            {
                cart.Add(productId, quantity);
            }

            eventAggregator.GetEvent<AddedToCartEvent>().Publish(new AddedToCartEvent.PayLoad
            {
                ProductId = productId,
                Quatity = quantity
            });
        }
    }
}
