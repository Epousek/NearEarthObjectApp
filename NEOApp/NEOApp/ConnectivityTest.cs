using Xamarin.Essentials;

namespace NEOApp
{
  public static class ConnectivityTest
  {
    public static bool IsConnected { get; set; }

    public static void Init()
    {
      IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
      Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    private static void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      IsConnected = e.NetworkAccess == NetworkAccess.Internet;
    }
  }
}
