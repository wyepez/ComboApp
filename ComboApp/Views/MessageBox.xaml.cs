using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ComboApp.Views
{
    public sealed partial class MessageBox : ContentDialog
    {
        private static MessageBox messageBox = new MessageBox();

        private MessageBox()
        {
            InitializeComponent();
        }

        public static async Task ShowAsync(string message)
        {
            messageBox.Output.Text = message;
            await messageBox.ShowAsync();
        }
    }
}
