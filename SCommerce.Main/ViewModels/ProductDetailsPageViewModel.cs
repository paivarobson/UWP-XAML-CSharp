using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Entities;
using SCommerce.Main.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel : ViewModelBase
    {
        #region Attributes
        private readonly IProductService productService;
        private readonly ICartService cartService;
        private Product model;
        #endregion

        #region Properties
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

        private double price;
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }

        private List<BitmapImage> images;
        public List<BitmapImage> Images
        {
            get { return images; }
            set { SetProperty(ref images, value); }
        }

        private BitmapImage selectedImage;

        public BitmapImage SelectedImage
        {
            get { return selectedImage; }
            set { SetProperty(ref selectedImage, value); }
        }
        #endregion

        public ProductDetailsPageViewModel(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
            this.cartService = cartService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var productId = (int)e.Parameter;

            await LoadProductAsync(productId);
        }

        private async Task LoadProductAsync(int id)
        {
            model = await productService.FindAsync(id);

            Title = model.Title;
            Description = model.Description;
            Price = model.Price;
            Rating = model.Rating;
            
            var list = await LoadImagesAsync();
            Images = list;
            SelectedImage = list.FirstOrDefault();
        }

        private async Task<List<BitmapImage>> LoadImagesAsync()
        {
            var list = new List<BitmapImage>();
            foreach (var item in model.Images)
            {
                var path = Path.Combine("images", item.Path);

                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(path);

                using (var stream = file.OpenReadAsync().AsTask().Result)
                {
                    var bi = new BitmapImage();
                    await bi.SetSourceAsync(stream);

                    list.Add(bi);
                }
            }

            return list;
        }

        public async void AddToCart()
        {
            await cartService.AddAsync(model.Id, 1);
        }

    }
}
