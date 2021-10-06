using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Services;
using SCommerce.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Views
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly IProductService productService;

        private ObservableCollection<ProductItemViewModel> items;
        public ObservableCollection<ProductItemViewModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public ProductsPageViewModel(IProductService productService)
        {
            this.productService = productService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var products = await productService.ListAsync();

            var list = products.Select(i => new ProductItemViewModel(i));

            Items = new ObservableCollection<ProductItemViewModel>(list);
        }
    }
}
