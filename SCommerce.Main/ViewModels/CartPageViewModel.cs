using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Events.Models;
using SCommerce.Main.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class CartPageViewModel : ViewModelBase
    {
        private readonly ICartService cartService;

        private ObservableCollection<CartItemViewModel> items;

        public ObservableCollection<CartItemViewModel> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public CartPageViewModel(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var list = cartService.ListItemsForCheckout()
                                .Select(i => CartItemViewModel.Create(i, AddItem, SubtractItem, RemoveItem))
                                .ToList();

            Items = new ObservableCollection<CartItemViewModel>(list);
        }

        private async void AddItem(int productId, int quatity)
        {
            await cartService.AddAsync(productId, quatity);
        }

        private void SubtractItem(int productId, int quatity)
        {
            cartService.Subtract(productId, quatity);
        }

        private void RemoveItem(int productId)
        {
            cartService.Remove(productId);
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            Items.Remove(item);
        }
    }
}
