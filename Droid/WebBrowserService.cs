using System;
using Android.Content;
using OpenWebBrowserSample.Android;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebBrowserService))]

namespace OpenWebBrowserSample.Android
{
    public class WebBrowserService : YahooWeather_Forms.YahooWeather_FormsPage.IWebBrowserService
    {
        public void Open(Uri uri)
        {
            Forms.Context.StartActivity(
                new Intent(Intent.ActionView,
                    global::Android.Net.Uri.Parse(uri.AbsoluteUri)));
        }
    }
}