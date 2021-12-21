using NEOApp.Models;
using NEOApp.ViewModels;
using NEOApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NEOApp.Views
{
  public partial class ItemsPage : ContentPage
  {
    private static Regex regex = new Regex("\"[0-9]{4}-[0-9]{2}-[0-9]{2}\"");
    private static string url = "http://www.neowsapp.com/rest/v1/feed?detailed=true&start_date="
      + DateTime.Today.ToString("yyyy-MM-dd") + "&end_date="
      + DateTime.Today.ToString("yyyy-MM-dd") + "&api_key="
      + Preferences.Get("api_key", "DEMO_KEY");
    public static bool IsConnected { get; set; }
    public static List<NEO> neos = new List<NEO>();
    public ObservableCollection<NEO> NEOs { get; set; }

    public ItemsPage()
    {
      InitConnectivity();
      InitializeComponent();
      NEOs = new ObservableCollection<NEO>();
      NEOsLV.ItemsSource = NEOs;
    }

    public async Task<Exception?> GetNEOsAsync()
    {
      if (IsConnected)
      {
        var client = new RestClient(url);
        var request = new RestRequest();
        client.RemoteCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
        var response = (RestResponse)await client.ExecuteAsync(request).ConfigureAwait(false);

        if (!response.IsSuccessful)
          return response.ErrorException;

        string content = response.Content;
        content = regex.Replace(content, "\"neos\"", 1);
        JObject contentObject = JObject.Parse(content);
        NEOFeed feed = contentObject.ToObject<NEOFeed>();
        url = feed.Links.Prev;

        foreach (var neo in feed.NearEarthObjects.Neos)
          neos.Add(neo);

        NEOs = new ObservableCollection<NEO>(neos);
        NEOsLV.ItemsSource = NEOs;
        return null;
      }
      return new Exception("No internet connection.");
    }
    public async Task InitConnectivity()
    {
      IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
      Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

      if (IsConnected)
      {
        for (int i = 0; i < 5; i++)
        {
          Exception? e = await GetNEOsAsync();
          if (e != null)
          {
            await DisplayAlert("Couldn't get objects.", e.Message, "xd");
            break;
          }
          NEOsLV.ItemsSource = NEOs;
        }
      }
    }

    private static void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      IsConnected = e.NetworkAccess == NetworkAccess.Internet;
    }

    protected override async void OnAppearing()
    {
      await GetNEOsAsync();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
      Exception? exception = await GetNEOsAsync();
      if (exception != null)
        await DisplayAlert("Couldn't get objects.", exception.Message, "xd");
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
      StackLayout sl = (StackLayout)sender;
      var item = (TapGestureRecognizer)sl.GestureRecognizers[0];
      NEO neo = (NEO)item.CommandParameter;
      StringBuilder builder = new StringBuilder();

      builder.Append("ID: " + neo.Id);
      builder.Append(Environment.NewLine);
      builder.Append("Nasa jpl url: " + neo.NasaJplUrl);
      builder.Append(Environment.NewLine);
      builder.Append("Absolute magnitude: " + neo.AbsoluteMagnitudeH);
      builder.Append(Environment.NewLine);
      builder.Append("Estimated diameter (km): " + neo.EstimatedDiameter.Kilometers.EstimatedDiameterMax);
      builder.Append(Environment.NewLine);
      builder.Append("Estimated diameter (miles): " + neo.EstimatedDiameter.Miles.EstimatedDiameterMax);
      builder.Append(Environment.NewLine);
      builder.Append("Is potentially hazardous: " + neo.IsPotentiallyHazardousAsteroid);
      builder.Append(Environment.NewLine);
      builder.Append("Relative velocity (km/h): " + neo.CloseApproachData[0].RelativeVelocity.KilometersPerHour);
      builder.Append(Environment.NewLine);
      builder.Append("Miss distance (km): " + neo.CloseApproachData[0].MissDistance.Kilometers);
      builder.Append(Environment.NewLine);
      builder.Append("Miss distance (miles): " + neo.CloseApproachData[0].MissDistance.Miles);
      builder.Append(Environment.NewLine);
      builder.Append("Orbiting body: " + neo.CloseApproachData[0].OrbitingBody);
      builder.Append(Environment.NewLine);
      builder.Append("First observation: " + neo.OrbitalData.FirstObservationDate);
      builder.Append(Environment.NewLine);
      builder.Append("Last observation: " + neo.OrbitalData.LastObservationDate);
      DisplayAlert(neo.Name, builder.ToString(), "ok");
    }
  }
}