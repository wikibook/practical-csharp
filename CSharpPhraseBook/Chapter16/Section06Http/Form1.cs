using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section06Http {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        // List 16-23
        private async void button1_Click(object sender, EventArgs e) {
            var tasks = new Task<string>[] {
                  GetPageAsync(@"http://msdn.microsoft.com/magazine/"),
                  GetPageAsync(@"http://msdn.microsoft.com/ja-jp/"),
               };
            var results = await Task.WhenAll(tasks);

            // 각각 앞의 300문자를 표시한다
            textBox1.Text =
               results[0].Substring(0, 300) +
               Environment.NewLine + Environment.NewLine +
               results[1].Substring(0, 300);
        }

        private readonly HttpClient _httpClient = new HttpClient();

        private async Task<string> GetPageAsync(string urlstr) {
            var str = await _httpClient.GetStringAsync(urlstr);
            return str;
        }
    }
}
