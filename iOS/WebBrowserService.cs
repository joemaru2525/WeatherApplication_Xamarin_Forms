using System;
using OpenWebBrowserSample.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebBrowserService))]

namespace OpenWebBrowserSample.iOS
{
    public class WebBrowserService : YahooWeather_Forms.YahooWeather_FormsPage.IWebBrowserService
    {
        public void Open(Uri uri)
        {
            UIApplication.SharedApplication.OpenUrl(uri);
        }
    }
}