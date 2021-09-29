using Prism.Mvvm;
using SCommerce.Main.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class CartItemViewModel : BindableBase
    {
        private int productId;
        public int ProductId
        {
            get { return productId; }
            set { SetProperty(ref productId, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        private Action<int, int> addItemAction;
        private Action<int, int> subtractItemAction;
        private Action<int> removeItemAction;

        public static CartItemViewModel Create(CartEntry model, Action<int, int> addItem, Action<int, int> subtractItem, Action<int> removeItem)
        {
            return new CartItemViewModel
            {
                ProductId = model.ProductId,
                Title = model.Title,
                Price = model.Price,
                Quantity = model.Quantity,
                Image = model.Image,
                addItemAction = addItem,
                subtractItemAction = subtractItem,
                removeItemAction = removeItem
            };
        }

        public void Add()
        {
            addItemAction?.Invoke(ProductId, 1);
        }

        public void Subtract()
        {
            subtractItemAction?.Invoke(ProductId, 1);
        }

        public void Remove()
        {
            removeItemAction?.Invoke(ProductId);
        }
    }
}
