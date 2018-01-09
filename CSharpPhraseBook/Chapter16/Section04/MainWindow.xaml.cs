using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Section04 {
    /// <summary>
    /// MainWindow.xaml의 상호작용 로직
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private HttpClient _httpClient = new HttpClient();

        // List 16-10
        private async void button_Click(object sender, RoutedEventArgs e) {
            textBlock.Text = "";
            var text = await GetPageAsync(@"http://www.bing.com/");
            textBlock.Text = text;
        }


        private async Task<string> GetPageAsync(string urlstr) {
            var str = await _httpClient.GetStringAsync(urlstr);
            return str;
        }


        // List 16-11
        private async void button1_Click(object sender, RoutedEventArgs e) {
            textBlock.Text = "";
            var text = await GetFromWikipediaAsync("크린룸 설계");
            textBlock.Text = text;
        }

        private async Task<string> GetFromWikipediaAsync(string keyword) {
            // UriBuilder와 FormUrlEncodedContent를 사용해서 매개변수를 붙인 URL을 조합한다
            var builder = new UriBuilder("https://ja.wikipedia.org/w/api.php");
            var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
                ["action"] = "query",
                ["prop"] = "revisions",
                ["rvprop"] = "content",
                ["format"] = "xml",
                ["titles"] = keyword,
            });
            builder.Query = await content.ReadAsStringAsync();

            // HttpClient를 사용해서 wikipedia에 있는 데이터를 가져온다
            var str = await _httpClient.GetStringAsync(builder.Uri);

            // 가져온 XML 문자열에서 LINQ to XML을 사용해 필요한 정보를 꺼낸다
            var xmldoc = XDocument.Parse(str);
            var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            return WebUtility.HtmlDecode(rev?.Value);
        }
    }
}
