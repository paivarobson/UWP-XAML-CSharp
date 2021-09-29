using Prism.Events;
using SCommerce.Main.Events;
using SCommerce.Main.Events.Models;
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
        private readonly IProductService productService;
        private Dictionary<int, CartEntry> cart;

        public CartService(IEventAggregator eventAggregator, IProductService productService)
        {
            cart = new Dictionary<int, CartEntry>();
            this.eventAggregator = eventAggregator;
            this.productService = productService;
        }

        public async Task AddAsync(int productId, int quantity)
        {
            if (cart.ContainsKey(productId))
            {
                cart[productId].Quantity += quantity;
            }
            else
            {
                var product = await productService.FindAsync(productId);
                var cartEntry = new CartEntry
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Title = product.Title,
                    Price = product.Price,
                    Image = product.Images.FirstOrDefault()
                };

                cart.Add(productId, cartEntry);
            }

            eventAggregator.GetEvent<AddedToCartEvent>().Publish(new AddedToCartEvent.PayLoad
            {
                ProductId = productId,
                Quatity = quantity
            });
        }

        public void Subtract(int productId, int quantity)
        {
            if (cart.ContainsKey(productId))
            {
                cart[productId].Quantity -= quantity;

                eventAggregator.GetEvent<SubtractedFromCartEvent>().Publish(new SubtractedFromCartEvent.PayLoad
                {
                    ProductId = productId,
                    Quatity = quantity
                });
            }
        }

        public void Remove(int productId)
        {
            if (cart.ContainsKey(productId))

                cart.Remove(productId);
            {
                eventAggregator.GetEvent<RemovedFromCartEvent>().Publish(new RemovedFromCartEvent.PayLoad
                {
                    ProductId = productId
                });
            }
        }

        public List<CartEntry> ListItemsForCheckout()
        {
            return cart.Values.ToList();
        }
    }
}
