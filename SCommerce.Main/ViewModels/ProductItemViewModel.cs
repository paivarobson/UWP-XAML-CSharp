using Prism.Mvvm;
using SCommerce.Main.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class ProductItemViewModel : BindableBase
    {
        public int Id { get; set; }

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

        public ProductItemViewModel(Product product)
        {
            Id = product.Id;
            Title = product.Title;
            Price = product.Price;
        }
    }
}
