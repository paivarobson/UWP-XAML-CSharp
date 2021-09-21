using Prism.Events;
using Prism.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Common;
using SCommerce.Main.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
        private readonly INavigationService navigationService;
        private int cartQuatity = 0;

        private string cartLabel;
        public string CartLabel
        {
            get { return cartLabel; }
            set { SetProperty(ref cartLabel, value); }
        }

        public HeaderViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;

            eventAggregator.GetEvent<AddedToCartEvent>().Subscribe(HandleAddedToCartEvent);

        }

        private void HandleAddedToCartEvent(AddedToCartEvent.PayLoad payLoad)
        {
            cartQuatity += payLoad.Quatity;
            cartLabel = $"Cart ({cartQuatity})";
        }

        public void NavigateToCartPage()
        {
            navigationService.Navigate(PageTokens.CartPage, null);
        }
    }
}
