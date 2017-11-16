using ComboApp.ViewModels;
using Windows.UI.Xaml.Controls;

namespace ComboApp.Views
{
    public sealed partial class OrderPage : Page
    {
        public OrderPageViewModel ViewModel => DataContext as OrderPageViewModel;

        public OrderPage()
        {
            InitializeComponent();
        }
    }
}
