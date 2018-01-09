using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        // List 16-6
        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await Task.Run(() => DoSomething());
            toolStripStatusLabel1.Text = "종료";
        }

        // 반환값이 없는 동기 메서드
        private void DoSomething() {
            Thread.Sleep(4000); // 본래는 시간이 소요되는 처리
        }

        // List 16-7
        private async void button2_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(() => DoSomething2());
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        // 반환값이 있는 동기 메서드
        private long DoSomething2() {
            var sw = Stopwatch.StartNew();
            Thread.Sleep(4000); // 본래는 시간이 소요되는 처리
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        // List 16-8
        private async void button3_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await DoSomethingAsync();
            toolStripStatusLabel1.Text = "종료";
        }

        // 비동기 메서드 - DoSomethingAsync는 아무것도 반환하지 않는다
        private async Task DoSomethingAsync() {
            await Task.Run(() => {
                Thread.Sleep(4000); // 본래는 시간이 소요되는 처리
            });
        }

        // List 16-9
        private async void button4_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoSomethingAsync(4000);
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        // 비동기 메서드 - DoSomethingAsync는 long형 값을 반환한다
        private async Task<long> DoSomethingAsync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                Thread.Sleep(4000); // 본래는 시간이 소요되는 처리
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

    }
    
}
