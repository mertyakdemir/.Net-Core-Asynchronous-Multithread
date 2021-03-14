using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousMultithread.TaskFormApp
{
    public partial class Form1 : Form
    {

        public int counter { get; set; } = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void BtnReadFile_Click(object sender, EventArgs e)
        {
            // string data = ReadFile();

            string data = string.Empty;
            Task<string> read = ReadFileAsync();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.youtube.com/");

            data = await read;

            richTextBox1.Text = data;
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        private string ReadFile()
        {
            string data = string.Empty;
            using(StreamReader s = new  StreamReader("names.txt"))
            {
                Thread.Sleep(5000);
                data = s.ReadToEnd();
            }

            return data;
        }

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("names.txt"))
            {
                Task<string> myTask = s.ReadToEndAsync();


                data = await myTask;

                return data;
            }
        }

    }
}
