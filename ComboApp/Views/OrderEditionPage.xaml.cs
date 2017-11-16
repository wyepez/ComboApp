using ComboApp.ViewModels;
using Windows.UI.Xaml.Controls;

namespace ComboApp.Views
{
    public sealed partial class OrderEditionPage : Page
    {
        public OrderEditionPageViewModel ViewModel => DataContext as OrderEditionPageViewModel;

        public OrderEditionPage()
        {
            this.InitializeComponent();
        }
    }
}
