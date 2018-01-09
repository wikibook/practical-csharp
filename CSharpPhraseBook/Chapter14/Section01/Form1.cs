using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            label1.Text = "";
            RunNotepad();
        }

        // List 14-1
        private void RunNotepad() {
            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables(path);
            Process.Start(fullpath);
        }

        private void button2_Click(object sender, EventArgs e) {
            label1.Text = "";
            RunAndWaitNotepad();
            MessageBox.Show("종료");
        }

        // List 14-2
        private static int RunAndWaitNotepad() {
            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables(path);
            using (var process = Process.Start(fullpath)) {
                if (process.WaitForExit(10000))
                    return process.ExitCode;
                throw new TimeoutException();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            label1.Text = "";
            RunNotepadUsingEvent();
        }

        // List 14-3
        private void RunNotepadUsingEvent() {
            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables(path);
            var process = Process.Start(fullpath);
            process.EnableRaisingEvents = true;
            process.Exited += (sender, eventArgs) => {
                this.Invoke((Action)delegate {
                    label1.Text = "종료";
                });
            };
        }

        private void button4_Click(object sender, EventArgs e) {
            label1.Text = "";
            RunMaximized();
        }

        // List 14-4
        private static void RunMaximized() {
            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables(path);
            var startInfo = new ProcessStartInfo {
                FileName = fullpath,
                Arguments = @"C:\temp\Sample.txt",
                WindowStyle = ProcessWindowStyle.Maximized
            };
            Process.Start(startInfo);
        }

        private void button5_Click(object sender, EventArgs e) {
            PlaySound();
        }

        // List 14-5
        private static void PlaySound() {
            var startInfo = new ProcessStartInfo {
                FileName = @"C:\Windows\Media\Alarm01.wav",
                WindowStyle = ProcessWindowStyle.Normal,
                Verb = "Play",
            };
            Process.Start(startInfo);
        }
    }
}
