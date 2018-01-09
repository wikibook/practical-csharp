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
    // Lsit 16-3
    public partial class Form2 : Form {

        private BackgroundWorker _worker = new BackgroundWorker();

        public Form2() {
            InitializeComponent();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.WorkerReportsProgress = true;
        }

        // 본래의 처리를 실행한다
        private void _worker_DoWork(object sender, DoWorkEventArgs e) {
            var collection = Enumerable.Range(1, 200).ToArray();
            int count = 0;
            foreach (var n in collection) {
                // n에 대한 처리를 실행한다
                // DoWork(n);
                Thread.Sleep(10);  // DoWork 대신에 존재하는 코드
                // 몇 퍼센트까지 처리됐는지를 구한다
                var per = count * 100 / collection.Length;
                // 프로그레스 바를 업데이트하기 위해 처리 상황을 알린다
                _worker.ReportProgress(Math.Min(per, toolStripProgressBar1.Maximum), null);
                count++;
            }
        }

        // 프로그레스 바를 업데이트한다
        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        // 처리가 끝났을 때 호출된다
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            toolStripStatusLabel1.Text = "완료";
        }

        private void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            // 처리를 시작한다
            _worker.RunWorkerAsync();

        }
    }
}
