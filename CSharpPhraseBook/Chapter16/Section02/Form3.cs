using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section02 {
    public partial class Form3 : Form {
        public Form3() {
            InitializeComponent();
        }

        // List 16-4
        private void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            Task.Run(() => DoSomething());
        }

        private void DoSomething() {
            Thread.Sleep(4000);// 본래는 시간이 소요되는 처리
            statusStrip1.Invoke((Action)(() => {
                toolStripStatusLabel1.Text = "종료";
            }));
        }

        // List 16-5
        private void button2_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var currentContext = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() => {
                DoSomething2();
            })
            .ContinueWith(task => {
                toolStripStatusLabel1.Text = "종료";
            }, currentContext);
        }

        private void DoSomething2() {
            Thread.Sleep(4000); // 본래는 시간이 소요되는 처리
        }

    }
}
