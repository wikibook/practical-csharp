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
    public partial class Form1 : Form {

        private void button1_Click(object sender, EventArgs e) {
            label1.Text = "";
            Cursor = Cursors.WaitCursor;
            DoLongTimeWork();    // 시간이 소요되는 처리
            label1.Text = "종료";
            Cursor = Cursors.Arrow;
        }

        private void DoLongTimeWork() {
            // 여기에 본래는 시간이 소요되는 처리를 코딩한다
            // Thread.Sleep 메서드는 지정된 시간 동안에만 처리를 대기하는 메서드이다
            Thread.Sleep(3000); 
        }

        // List 16-1
        private void button2_Click(object sender, EventArgs e) {
            label1.Text = "";
            var th = new Thread(DoSomething);
            th.Start();
        }

        private void DoSomething() {
            DoLongTimeWork();    // 시간이 소요되는 처리
            label1.Invoke((Action)delegate () {
                label1.Text = "종료";
            });
        }

        // List 16-2
        private BackgroundWorker _worker = new BackgroundWorker();

        public Form1() {
            InitializeComponent();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e) {
            // 시간이 소요되는 처리
            DoLongTimeWork();
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            label1.Text = "종료";
        }

        private void button3_Click(object sender, EventArgs e) {
            label1.Text = "";
            _worker.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e) {
            var form = new Form2();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e) {
            var form = new Form3();
            form.Show();

        }
    }
}
