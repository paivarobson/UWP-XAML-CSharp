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

        private int cartQuatity;
        public int CartQuatity
        {
            get { return cartQuatity; }
            set { SetProperty(ref cartQuatity, value); }
        }

        public HeaderViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;

            eventAggregator.GetEvent<AddedToCartEvent>().Subscribe(HandleAddedToCartEvent);

        }

        private void HandleAddedToCartEvent(AddedToCartEvent.PayLoad payLoad)
        {
            CartQuatity += payLoad.Quatity;
        }

        public void NavigateToCartPage()
        {
            navigationService.Navigate(PageTokens.CartPage, null);
        }
    }
}
