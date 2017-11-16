using ComboApp.ViewModels;
using ComboApp.Views;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Services.NavigationService;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;

namespace ComboApp
{
    sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // TODO: add your long-running task here
            await NavigationService.NavigateAsync(typeof(OrderPage));
        }

        public override INavigable ResolveForPage(Page page, NavigationService navigationService)
        {
            switch (page)
            {
                case OrderPage p:
                    return ((UnityLocator)Resources["Locator"]).OrderPageViewModel;
                case OrderEditionPage p:
                    return ((UnityLocator)Resources["Locator"]).OrderEditionPageViewModel;
                default:
                    return base.ResolveForPage(page, navigationService);
            }
        }
    }
}
