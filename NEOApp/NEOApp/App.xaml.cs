using NEOApp.Services;
using NEOApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace NEOApp
{
  public partial class App : Application
  {
    public App()
    {
      Preferences.Set("api_key", "cU20o4olVJ0EfymDmYrkCMxn8TqjDVBAUL0ugsrD");
      ConnectivityTest.Init();

      InitializeComponent();

      DependencyService.Register<MockDataStore>();
      MainPage = new AppShell();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
