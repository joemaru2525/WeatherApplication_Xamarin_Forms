using Xamarin.Forms;
using System;
using HtmlAgilityPack;


namespace YahooWeather_Forms
{
    public partial class YahooWeather_FormsPage : ContentPage
    {
        public YahooWeather_FormsPage()
        {
            InitializeComponent();

            //(0) Get UI controls from the loaded layout


            //(1)指定したサイトのHTMLをストリームで取得する
            const string url = "https://weather.yahoo.co.jp/weather/jp/14/4610.html";
            var urlstring = string.Format(url);

            //(2)指定したサイトのHTMLをストリームで取得する
            var doc = new HtmlAgilityPack.HtmlDocument();
            using (var client = new System.Net.WebClient())
            {
                var html = client.DownloadString(new Uri(urlstring));

                // HtmlAgilityPack.HtmlDocumentオブジェクトにHTMLを読み込ませる
                doc.LoadHtml(html);
            }

            //(3)XPathを使って情報を抽出
            //タイトル
            HtmlNodeCollection node0 =
            doc.DocumentNode.SelectNodes("//title");
            labelTitle.Text = node0[0].InnerText;

            //Anounce Date & Time（発表日時）
            HtmlNodeCollection node1 =
            doc.DocumentNode.SelectNodes("//div[@class='yjw_title_h2 yjw_clr']//p[@class='yjSt yjw_note_h2']");
            labelAnnounce.Text = node1[0].InnerText;
 
            //WeatherDate（対象日）
            HtmlNodeCollection node2 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//p[@class='date']");
            labelDate.Text = node2[0].InnerText;
 
            //Weather（天候）
            HtmlNodeCollection node3 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//p[@class='pict']");
            labelWeather.Text = node3[0].InnerText;
 
            //High Temp（最高気温）
            HtmlNodeCollection node4 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//ul[@class='temp']//li[@class='high']");
            labelTempHigh.Text = "最高気温 [前日差]： " + node4[0].InnerText;
 
            //Low Temp（最低気温）
            HtmlNodeCollection node5 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//ul[@class='temp']//li[@class='low']");
            labelTempLow.Text = "最低気温 [前日差]： " + node5[0].InnerText;

            //Precip1[0-6]（降水確率）
            HtmlNodeCollection node6 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//tr[@class='precip']//td");
            labelPrecip01.Text = node6[0].InnerText;

            //Precip1[6-12]（降水確率）
            labelPrecip02.Text = node6[1].InnerText;

            //Precip1[12-18]（降水確率）
            labelPrecip03.Text = node6[2].InnerText;

            //Precip1[18-24]（降水確率）
            labelPrecip04.Text = node6[3].InnerText;

            //WeatherPicture（天気画像）
            HtmlNodeCollection node7 = doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//p[@class='pict']//img");
            var imageURL = node7[0].GetAttributeValue("src", "");
            imageWeather.Source=imageURL;
 

        }
    }
}
