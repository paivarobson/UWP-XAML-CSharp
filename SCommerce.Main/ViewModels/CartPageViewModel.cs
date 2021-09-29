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

        private List<string> steps;
        public List<string> Steps
        {
            get { return steps; }
            set { SetProperty(ref steps, value); }
        }

        private string selectedStep;
        public string  SelectedStep
        {
            get { return selectedStep; }
            set { SetProperty(ref selectedStep, value); }
        }

        public CartPageViewModel(ICartService cartService)
        {
            this.cartService = cartService;
            Steps = new List<string>
            {
                "Checkout",
                "Address",
                "Payment"
            };

            SelectedStep = Steps.First();
        }
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            var list = cartService.ListItemsForCheckout()
                                .Select(i => CartItemViewModel.Create(i, AddItem, SubtractItem, RemoveItem))
                                .ToList();

            Items = new ObservableCollection<CartItemViewModel>(list);
        }

        int count = 0;
        public void ChangeSelectStep()
        {
            count++;
            SelectedStep = Steps[count % Steps.Count];
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
