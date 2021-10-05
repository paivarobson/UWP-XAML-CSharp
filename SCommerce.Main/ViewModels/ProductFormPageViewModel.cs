using Prism.Windows.Mvvm;
using SCommerce.Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class ProductFormPageViewModel : ViewModelBase
    {
        private readonly IProductService productService;

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        public ProductFormPageViewModel(IProductService productService)
        {
            this.productService = productService;
        }
    
        public async void Save()
        {
            await productService.CreateAsync(Title,
                                            Description,
                                            Rating,
                                            Price);
        }
    }
}
