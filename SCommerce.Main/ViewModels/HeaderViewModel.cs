using Prism.Mvvm;
using Prism.Windows.Navigation;
using SCommerce.Main.Common;
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

        public HeaderViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void NavigateToCartPage()
        {
            navigationService.Navigate(PageTokens.CartPage, null);
        }
    }
}
