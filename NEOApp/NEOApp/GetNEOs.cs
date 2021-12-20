using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Essentials;
using RestSharp;
using Newtonsoft.Json.Linq;
using NEOApp.Models;

namespace NEOApp
{
  public static class GetNEOs
  {
    private static Regex regex = new Regex("\"[0-9]{4}-[0-9]{2}-[0-9]{2}\"");
    private static string url = "http://www.neowsapp.com/rest/v1/feed?detailed=true&start_date="
      + DateTime.Today.ToString("yyyy-MM-dd") + "&end_date="
      + DateTime.Today.ToString("yyyy-MM-dd") + "&api_key="
      + Preferences.Get("api_key", "DEMO_KEY");
    public static List<NEO> neos = new List<NEO>();

    public static async Task<Exception?> GetNEOsAsync()
    {
      if (ConnectivityTest.IsConnected)
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
        {
          neos.Add(neo);
        }
        return null;
      }

      return new Exception("No internet connection.");
    }
  }
}
