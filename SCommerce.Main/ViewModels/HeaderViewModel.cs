using Prism.Events;
using Prism.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Common;
using SCommerce.Main.Events;
using SCommerce.Main.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

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
            eventAggregator.GetEvent<SubtractedFromCartEvent>().Subscribe(HandleSubtractToCartEvent);

        }

        private void HandleSubtractToCartEvent(SubtractedFromCartEvent.PayLoad payLoad)
        {
            CartQuatity -= payLoad.Quatity;
        }

        private void HandleAddedToCartEvent(AddedToCartEvent.PayLoad payLoad)
        {
            CartQuatity += payLoad.Quatity;
        }

        public void NavigateToCartPage()
        {
            navigationService.Navigate(PageTokens.CartPage, null);
        }

        public async void OpenAddProduct()
        {
            var view = CoreApplication.CreateNewView();
            int viewId = 0;

            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var page = new ProductFormPage();
                Window.Current.Content = page;
                Window.Current.Activate();

                viewId = ApplicationView.GetForCurrentView().Id;
            });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(viewId);
        }
    }
}
