using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Events.Models;
using SCommerce.Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class CartPageViewModel : ViewModelBase
    {
        private readonly ICartService cartService;

        private List<CartEntry> items;

        public List<CartEntry> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public CartPageViewModel(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            Items = cartService.ListitemsForCheckout();
        }
    }
}
