using Xamarin.Forms;
using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;


namespace YahooWeather_Forms
{
    public partial class YahooWeather_FormsPage : ContentPage
    {
        //Pickerに表示する項目の作成
        Dictionary<string, string> locationDic = new Dictionary<string, string>
            {
                {"稚内" , "https://weather.yahoo.co.jp/weather/jp/1a/1100.html"},
                {"旭川", "https://weather.yahoo.co.jp/weather/jp/1a/1200.html"},
                {"留萌", "https://weather.yahoo.co.jp/weather/jp/1a/1300.html"},
                {"札幌", "https://weather.yahoo.co.jp/weather/jp/1b/1400.html"},
                {"岩見沢", "https://weather.yahoo.co.jp/weather/jp/1b/1500.html"},
                {"倶知安", "https://weather.yahoo.co.jp/weather/jp/1b/1600.html"},
                {"網走", "https://weather.yahoo.co.jp/weather/jp/1c/1710.html"},
                {"北見", "https://weather.yahoo.co.jp/weather/jp/1c/1720.html"},
                {"紋別", "https://weather.yahoo.co.jp/weather/jp/1c/1730.html"},
                {"根室", "https://weather.yahoo.co.jp/weather/jp/1c/1800.html"},
                {"釧路", "https://weather.yahoo.co.jp/weather/jp/1c/1900.html"},
                {"帯広", "https://weather.yahoo.co.jp/weather/jp/1c/2000.html"},
                {"室蘭", "https://weather.yahoo.co.jp/weather/jp/1d/2100.html"},
                {"浦河", "https://weather.yahoo.co.jp/weather/jp/1d/2200.html"},
                {"函館", "https://weather.yahoo.co.jp/weather/jp/1d/2300.html"},
                {"江差", "https://weather.yahoo.co.jp/weather/jp/1d/2400.html"},
                {"青森", "https://weather.yahoo.co.jp/weather/jp/2/3110.html"},
                {"むつ", "https://weather.yahoo.co.jp/weather/jp/2/3120.html"},
                {"八戸", "https://weather.yahoo.co.jp/weather/jp/2/3130.html"},
                {"盛岡", "https://weather.yahoo.co.jp/weather/jp/3/3310.html"},
                {"宮古", "https://weather.yahoo.co.jp/weather/jp/3/3320.html"},
                {"大船渡", "https://weather.yahoo.co.jp/weather/jp/3/3330.html"},
                {"仙台", "https://weather.yahoo.co.jp/weather/jp/4/3410.html"},
                {"白石", "https://weather.yahoo.co.jp/weather/jp/4/3420.html"},
                {"秋田", "https://weather.yahoo.co.jp/weather/jp/5/3210.html"},
                {"横手", "https://weather.yahoo.co.jp/weather/jp/5/3220.html"},
                {"山形", "https://weather.yahoo.co.jp/weather/jp/6/3510.html"},
                {"米沢", "https://weather.yahoo.co.jp/weather/jp/6/3520.html"},
                {"酒田", "https://weather.yahoo.co.jp/weather/jp/6/3530.html"},
                {"新庄", "https://weather.yahoo.co.jp/weather/jp/6/3540.html"},
                {"福島", "https://weather.yahoo.co.jp/weather/jp/7/3610.html"},
                {"小名浜", "https://weather.yahoo.co.jp/weather/jp/7/3620.html"},
                {"若松", "https://weather.yahoo.co.jp/weather/jp/7/3630.html"},
                {"東京", "https://weather.yahoo.co.jp/weather/jp/13/4410.html"},
                {"大島", "https://weather.yahoo.co.jp/weather/jp/13/4420.html"},
                {"八丈島", "https://weather.yahoo.co.jp/weather/jp/13/4430.html"},
                {"父島", "https://weather.yahoo.co.jp/weather/jp/13/4440.html"},
                {"横浜", "https://weather.yahoo.co.jp/weather/jp/14/4610.html"},
                {"小田原", "https://weather.yahoo.co.jp/weather/jp/14/4620.html"},
                {"さいたま", "https://weather.yahoo.co.jp/weather/jp/11/4310.html"},
                {"熊谷", "https://weather.yahoo.co.jp/weather/jp/11/4320.html"},
                {"秩父", "https://weather.yahoo.co.jp/weather/jp/11/4330.html"},
                {"千葉", "https://weather.yahoo.co.jp/weather/jp/12/4510.html"},
                {"銚子", "https://weather.yahoo.co.jp/weather/jp/12/4520.html"},
                {"館山", "https://weather.yahoo.co.jp/weather/jp/12/4530.html"},
                {"水戸", "https://weather.yahoo.co.jp/weather/jp/8/4010.html"},
                {"土浦", "https://weather.yahoo.co.jp/weather/jp/8/4020.html"},
                {"宇都宮", "https://weather.yahoo.co.jp/weather/jp/9/4110.html"},
                {"大田原", "https://weather.yahoo.co.jp/weather/jp/9/4120.html"},
                {"前橋", "https://weather.yahoo.co.jp/weather/jp/10/4210.html"},
                {"みなかみ", "https://weather.yahoo.co.jp/weather/jp/10/4220.html"},
                {"甲府", "https://weather.yahoo.co.jp/weather/jp/19/4910.html"},
                {"河口湖", "https://weather.yahoo.co.jp/weather/jp/19/4920.html"},
                {"新潟", "https://weather.yahoo.co.jp/weather/jp/15/5410.html"},
                {"長岡", "https://weather.yahoo.co.jp/weather/jp/15/5420.html"},
                {"高田", "https://weather.yahoo.co.jp/weather/jp/15/5430.html"},
                {"相川", "https://weather.yahoo.co.jp/weather/jp/15/5440.html"},
                {"長野", "https://weather.yahoo.co.jp/weather/jp/20/4810.html"},
                {"松本", "https://weather.yahoo.co.jp/weather/jp/20/4820.html"},
                {"飯田", "https://weather.yahoo.co.jp/weather/jp/20/4830.html"},
                {"名古屋", "https://weather.yahoo.co.jp/weather/jp/23/5110.html"},
                {"豊橋", "https://weather.yahoo.co.jp/weather/jp/23/5120.html"},
                {"岐阜", "https://weather.yahoo.co.jp/weather/jp/21/5210.html"},
                {"高山", "https://weather.yahoo.co.jp/weather/jp/21/5220.html"},
                {"静岡", "https://weather.yahoo.co.jp/weather/jp/22/5010.html"},
                {"網代", "https://weather.yahoo.co.jp/weather/jp/22/5020.html"},
                {"三島", "https://weather.yahoo.co.jp/weather/jp/22/5030.html"},
                {"浜松", "https://weather.yahoo.co.jp/weather/jp/22/5040.html"},
                {"津", "https://weather.yahoo.co.jp/weather/jp/24/5310.html"},
                {"尾鷲", "https://weather.yahoo.co.jp/weather/jp/24/5320.html"},
                {"富山", "https://weather.yahoo.co.jp/weather/jp/16/5510.html"},
                {"伏木", "https://weather.yahoo.co.jp/weather/jp/16/5520.html"},
                {"金沢", "https://weather.yahoo.co.jp/weather/jp/17/5610.html"},
                {"輪島", "https://weather.yahoo.co.jp/weather/jp/17/5620.html"},
                {"福井", "https://weather.yahoo.co.jp/weather/jp/18/5710.html"},
                {"敦賀", "https://weather.yahoo.co.jp/weather/jp/18/5720.html"},
                {"大阪", "https://weather.yahoo.co.jp/weather/jp/27/6200.html"},
                {"神戸", "https://weather.yahoo.co.jp/weather/jp/28/6310.html"},
                {"豊岡", "https://weather.yahoo.co.jp/weather/jp/28/6320.html"},
                {"京都", "https://weather.yahoo.co.jp/weather/jp/26/6110.html"},
                {"舞鶴", "https://weather.yahoo.co.jp/weather/jp/26/6120.html"},
                {"大津", "https://weather.yahoo.co.jp/weather/jp/25/6010.html"},
                {"彦根", "https://weather.yahoo.co.jp/weather/jp/25/6020.html"},
                {"奈良", "https://weather.yahoo.co.jp/weather/jp/29/6410.html"},
                {"風屋", "https://weather.yahoo.co.jp/weather/jp/29/6420.html"},
                {"和歌山", "https://weather.yahoo.co.jp/weather/jp/30/6510.html"},
                {"潮岬", "https://weather.yahoo.co.jp/weather/jp/30/6520.html"},
                {"松江", "https://weather.yahoo.co.jp/weather/jp/32/6810.html"},
                {"浜田", "https://weather.yahoo.co.jp/weather/jp/32/6820.html"},
                {"西郷", "https://weather.yahoo.co.jp/weather/jp/32/6830.html"},
                {"鳥取", "https://weather.yahoo.co.jp/weather/jp/31/6910.html"},
                {"米子", "https://weather.yahoo.co.jp/weather/jp/31/6920.html"},
                {"岡山", "https://weather.yahoo.co.jp/weather/jp/33/6610.html"},
                {"津山", "https://weather.yahoo.co.jp/weather/jp/33/6620.html"},
                {"広島", "https://weather.yahoo.co.jp/weather/jp/34/6710.html"},
                {"庄原", "https://weather.yahoo.co.jp/weather/jp/34/6720.html"},
                {"下関", "https://weather.yahoo.co.jp/weather/jp/35/8110.html"},
                {"山口", "https://weather.yahoo.co.jp/weather/jp/35/8120.html"},
                {"柳井", "https://weather.yahoo.co.jp/weather/jp/35/8130.html"},
                {"萩", "https://weather.yahoo.co.jp/weather/jp/35/8140.html"},
                {"徳島", "https://weather.yahoo.co.jp/weather/jp/36/7110.html"},
                {"日和佐", "https://weather.yahoo.co.jp/weather/jp/36/7120.html"},
                {"高松", "https://weather.yahoo.co.jp/weather/jp/37/7200.html"},
                {"松山", "https://weather.yahoo.co.jp/weather/jp/38/7310.html"},
                {"新居浜", "https://weather.yahoo.co.jp/weather/jp/38/7320.html"},
                {"宇和島", "https://weather.yahoo.co.jp/weather/jp/38/7330.html"},
                {"高知", "https://weather.yahoo.co.jp/weather/jp/39/7410.html"},
                {"室戸岬", "https://weather.yahoo.co.jp/weather/jp/39/7420.html"},
                {"清水", "https://weather.yahoo.co.jp/weather/jp/39/7430.html"},
                {"福岡", "https://weather.yahoo.co.jp/weather/jp/40/8210.html"},
                {"八幡", "https://weather.yahoo.co.jp/weather/jp/40/8220.html"},
                {"飯塚", "https://weather.yahoo.co.jp/weather/jp/40/8230.html"},
                {"久留米", "https://weather.yahoo.co.jp/weather/jp/40/8240.html"},
                {"佐賀", "https://weather.yahoo.co.jp/weather/jp/41/8510.html"},
                {"伊万里", "https://weather.yahoo.co.jp/weather/jp/41/8520.html"},
                {"長崎", "https://weather.yahoo.co.jp/weather/jp/42/8410.html"},
                {"佐世保", "https://weather.yahoo.co.jp/weather/jp/42/8420.html"},
                {"厳原", "https://weather.yahoo.co.jp/weather/jp/42/8430.html"},
                {"福江", "https://weather.yahoo.co.jp/weather/jp/42/8440.html"},
                {"熊本", "https://weather.yahoo.co.jp/weather/jp/43/8610.html"},
                {"阿蘇乙姫", "https://weather.yahoo.co.jp/weather/jp/43/8620.html"},
                {"牛深", "https://weather.yahoo.co.jp/weather/jp/43/8630.html"},
                {"人吉", "https://weather.yahoo.co.jp/weather/jp/43/8640.html"},
                {"大分", "https://weather.yahoo.co.jp/weather/jp/44/8310.html"},
                {"中津", "https://weather.yahoo.co.jp/weather/jp/44/8320.html"},
                {"日田", "https://weather.yahoo.co.jp/weather/jp/44/8330.html"},
                {"佐伯", "https://weather.yahoo.co.jp/weather/jp/44/8340.html"},
                {"宮崎", "https://weather.yahoo.co.jp/weather/jp/45/8710.html"},
                {"延岡", "https://weather.yahoo.co.jp/weather/jp/45/8720.html"},
                {"都城", "https://weather.yahoo.co.jp/weather/jp/45/8730.html"},
                {"高千穂", "https://weather.yahoo.co.jp/weather/jp/45/8740.html"},
                {"名瀬", "https://weather.yahoo.co.jp/weather/jp/46/1000.html"},
                {"鹿児島", "https://weather.yahoo.co.jp/weather/jp/46/8810.html"},
                {"鹿屋", "https://weather.yahoo.co.jp/weather/jp/46/8820.html"},
                {"種子島", "https://weather.yahoo.co.jp/weather/jp/46/8830.html"},
                {"那覇", "https://weather.yahoo.co.jp/weather/jp/47/9110.html"},
                {"名護", "https://weather.yahoo.co.jp/weather/jp/47/9120.html"},
                {"久米島", "https://weather.yahoo.co.jp/weather/jp/47/9130.html"},
                {"南大東", "https://weather.yahoo.co.jp/weather/jp/47/9200.html"},
                {"宮古島", "https://weather.yahoo.co.jp/weather/jp/47/9300.html"},
                {"石垣島", "https://weather.yahoo.co.jp/weather/jp/47/9410.html"},
                {"与那国島", "https://weather.yahoo.co.jp/weather/jp/47/9420.html"},
            };

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            //選択している地域を取得
            var selectedURL = locationDic.ElementAt(this.picker.SelectedIndex).Value;
            //選択された地域の天候表示
            yahooWeather(selectedURL);
        }

        int timerCount = 0;

        public YahooWeather_FormsPage()
        {
            InitializeComponent();

            //BackgroundImage="wallpaper5.jpg";
            //imageBackground.Source = "wallpaper5.jpg";

            int timerInterval = 1;  //10seconds

            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                // タイマー処理
                timerCount = timerCount + 1;
                System.Diagnostics.Debug.WriteLine(timerCount);

                if (timerCount >= timerInterval * 3)
                {
                    timerCount = 0;
                    System.Diagnostics.Debug.WriteLine("Clear");
                    imageBackground.Source = "wallpaper5.jpg";
                    System.Diagnostics.Debug.WriteLine("image5");
                }
                else if (timerCount >= timerInterval * 2)
                {
                    imageBackground.Source = "wallpaper4.jpg";
                    System.Diagnostics.Debug.WriteLine("image4");
                }  
                else 
                {
                    imageBackground.Source = "wallpaper3.jpg";
                    System.Diagnostics.Debug.WriteLine("image3");
                } 

                return true;
            });

            this.btn1.Clicked += Btn1_Clicked;

            yahooWeather("https://weather.yahoo.co.jp/weather/jp/13/4410.html");

            //Pickerに項目を追加
            foreach (var key in locationDic.Keys)
            {
                this.picker.Items.Add(key);
            }
        }

        public void yahooWeather(string weatherURL)
        {
            //(1)指定したサイトのHTMLをストリームで取得する
            string url = weatherURL;
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
            labelTitle.Text = " " + node0[0].InnerText;

            //Anounce Date & Time（発表日時）
            HtmlNodeCollection node1 =
            doc.DocumentNode.SelectNodes("//div[@class='yjw_title_h2 yjw_clr']//p[@class='yjSt yjw_note_h2']");
            labelAnnounce.Text = " " + node1[0].InnerText;

            //WeatherDate（対象日）
            HtmlNodeCollection node2 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//p[@class='date']");
            labelDate.Text = " " + node2[0].InnerText;

            //Weather（天候）
            HtmlNodeCollection node3 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//p[@class='pict']");
            labelWeather.Text = " " + node3[0].InnerText;

            //High Temp（最高気温）
            HtmlNodeCollection node4 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//ul[@class='temp']//li[@class='high']");
            labelTempHigh.Text = " 最高気温 [前日差]： " + node4[0].InnerText;

            //Low Temp（最低気温）
            HtmlNodeCollection node5 =
            doc.DocumentNode.SelectNodes("//div[@class='forecastCity']//ul[@class='temp']//li[@class='low']");
            labelTempLow.Text = " 最低気温 [前日差]： " + node5[0].InnerText;

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
            imageWeather.Source = imageURL;
        }

        private async void OnTransitNextPage(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new settingPage(), true);
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            //this.btn1.Text = "クリックした";
            var uri = "https://weather.yahoo.co.jp/weather/";
            DependencyService.Get<IWebBrowserService>().Open(new Uri(uri)); // open in WebBrowser
        }

        public interface IWebBrowserService
        {
            void Open(Uri uri);
        }

    }
}
