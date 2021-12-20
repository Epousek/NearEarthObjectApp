using NEOApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NEOApp.Views
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