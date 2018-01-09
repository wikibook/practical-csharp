using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 14")]
    class SampleCode  {

		[ListNo("List 14-15")]
        public void DownloadString() {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var html = wc.DownloadString("https://www.visualstudio.com/");

            // 처음 3000 문자만 출력한다
            Console.WriteLine(html.Substring(0,3000));
        }

        // 이것은 해당 URL이 존재하지 않으므로 실행할 수 없습니다.

		[ListNo("List 14-16")]
        private void DownloadFile() {
            var wc = new WebClient();
            var url = "http://localhost/example.zip";
            var filename = @"D:\temp\example.zip";
            wc.DownloadFile(url, filename);
            Console.ReadLine();
        }

        // 이 메서드는 환경을 만들지 않으면 실행할 수 없습니다.
        // 지정한 URL이 존재하지 않으므로 예외가 발생합니다.
        // 따라서 이 콘솔 프로그램을 실행할 때 이 함수는 호출되지 않도록 했습니다.
		[ListNo("List 14-17")]
        private void DownloadFileAsync() {
            var wc = new WebClient();
            var url = new Uri("http://localhost/example.zip");
            var filename = @"D:\temp\example.zip";
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync(url, filename);
        }

        static void wc_DownloadProgressChanged(object sender,
                            DownloadProgressChangedEventArgs e) {
            Console.WriteLine("{0}% {0}/{1}", e.ProgressPercentage,
                              e.BytesReceived, e.TotalBytesToReceive);
        }

        static void wc_DownloadFileCompleted(object sender,
                            System.ComponentModel.AsyncCompletedEventArgs e) {
            Console.WriteLine("내려받기가 끝났습니다.");
        }

        

		[ListNo("List 14-18")]
        public void OpenReadSample() {
            var wc = new WebClient();
            using (var stream = wc.OpenRead(@"http://wikibook.co.kr/list/"))
            using (var sr = new StreamReader(stream, Encoding.UTF8)) {
                string html = sr.ReadToEnd();
                // 처음 2000 문자만 출력한다
                Console.WriteLine(html.Substring(0, 2000));
            }
        }


        [ListNo("List 14-19")]
        public void WeatherRSS() {
            GetWeatherReportFromWethercast();
        }

        public void GetWeatherReportFromWethercast()
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-type", "charset=UTF-8");
                var uriString = @"http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=109";
                var url = new Uri(uriString);
                var stream = wc.OpenRead(url);
                XDocument xdoc = XDocument.Load(stream);
                var nodes = xdoc.Root.Descendants("location");

                XElement xprovince = nodes.Elements("province").ElementAt(0);   // "서울·인천·경기도"는 한 번만 표시한다
                Console.WriteLine("[[ " + xprovince.Value + " ]]");

                foreach (var node in nodes)
                {
                    XElement xcity = node.Element("city");
                    Console.WriteLine("<" + xcity.Value + ">");

                    var xdatas = node.Elements("data");
                    foreach (var xwether in xdatas)
                    {
                        XElement xtmEf = xwether.Element("tmEf");
                        XElement xwf = xwether.Element("wf");
                        XElement xtmn = xwether.Element("tmn");
                        XElement xtmx = xwether.Element("tmx");

                        Console.WriteLine("시각: " + xtmEf.Value);
                        Console.WriteLine("날씨: " + xwf.Value);
                        Console.WriteLine("최저기온: " + xtmn.Value);
                        Console.WriteLine("최고기온: " + xtmx.Value);
                    }

                    Console.WriteLine("");
                }
            }
        }


        [ListNo("List 14-20")]
        public void GetWikipediaData()
        {
            var keyword = "경복궁";
            var content = GetFromWikipedia(keyword);
            Console.WriteLine(content ?? "찾을 수 없습니다.");
        }

        private static string GetFromWikipedia(string keyword)
        {
            var wc = new WebClient();
            wc.QueryString = new NameValueCollection()
            {
                ["action"] = "query",
                ["prop"] = "revisions",
                ["rvprop"] = "content",
                ["format"] = "xml",
                ["titles"] = WebUtility.UrlEncode(keyword),
            };
            wc.Headers.Add("Content-type", "charset=UTF-8");
            var result = wc.DownloadString("http://ko.wikipedia.org/w/api.php");
            var xmldoc = XDocument.Parse(result);
            var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            // 책에서는 HttpUtility 클래스를 사용했지만 이 예제에서는
            // .NET Framework4에 추가된 WebUtility를 이용했습니다.
            // .NET Framework3.5가 타깃이라면 HttpUtility 클래스를 이용하기 바랍니다.
            return WebUtility.HtmlDecode(rev?.Value);
        }

    }
}
