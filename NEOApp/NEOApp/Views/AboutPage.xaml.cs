using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NEOApp.Views
{
  public partial class AboutPage : ContentPage
  {
    public AboutPage()
    {
      InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
      Exception? exception = await GetNEOs.GetNEOsAsync();
      if (exception != null)
        await DisplayAlert("Couldn't get objects.", exception.Message, "xd");
    }
  }
}