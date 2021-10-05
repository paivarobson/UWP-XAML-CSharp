using Prism.Unity.Windows;
using SCommerce.Main.Common;
using SCommerce.Main.Entities;
using SCommerce.Main.Services;
using SCommerce.Main.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SCommerce.Main
{
    /// <resumo>
    ///Fornece o comportamento específico do aplicativo para complementar a classe Application padrão.
    /// </summary>
    public sealed partial class App : PrismUnityApplication
    {
        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            using(var db = new SCommercecDb())
            {
                await db.Database.EnsureCreatedAsync();
            }

            NavigationService.Navigate(PageTokens.ProductsPage, null);
        }

        protected override UIElement CreateShell(Frame rootFrame)
        {
            var appShell = new AppShell();
            appShell.SetFrame(rootFrame);

            return appShell;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(IProductService), typeof(ProductService), false);
            RegisterTypeIfMissing(typeof(ICartService), typeof(CartService), true);
        }
    }
}
