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
            //string data = ReadFile();

            string data = string.Empty;
            //Task<string> read = ReadFileAsync();
            Task<string> read = ReadFileAsync2();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com/");

            data = await read;

            richTextBox1.Text = data;

            //var site1 = new HttpClient().GetAsync("https://www.youtube.com/").Result.Content.ReadAsStringAsync();
            //var site2 = new HttpClient().GetAsync("https://www.google.com/").Result.Content.ReadAsStringAsync();

            //var contents = Task.WhenAll(site1, site2);
            //var sites = await contents;

            //richTextBox2.Text = sites[1];

            //richTextBox1.Text = sites[0];
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

        // If other work is to be done after the asynchronous method is called, async-await can be used
        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("names.txt"))
            {
                Task<string> myTask = s.ReadToEndAsync();

                await Task.Delay(5000);

                data = await myTask;

                return data;
            }
        }

        // If no other work will be done after the asynchronous method is called, it can be returned directly.
        private Task<string> ReadFileAsync2()
        {
            StreamReader s = new StreamReader("names.txt");
            
            return s.ReadToEndAsync();
            
        }

    }
}
