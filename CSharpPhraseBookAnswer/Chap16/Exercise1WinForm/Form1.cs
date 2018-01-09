using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1WinForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            var text = await TextReaderSample.ReadTextAsync("oop.md");
            textBox1.Text = text;
        }

        private async void button2_Click(object sender, EventArgs e) {
            await TextReaderSample.ReadLinesAsync("oop.md", new Progress<string>(
                line => textBox1.Text += line + Environment.NewLine
            ));
        }

        private void button3_Click(object sender, EventArgs e) {
            textBox1.Text = "";
        }
    }
}
