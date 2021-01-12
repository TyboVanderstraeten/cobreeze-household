using Presentation.MobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Presentation.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}