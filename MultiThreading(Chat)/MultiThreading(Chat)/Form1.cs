using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading_Chat_
{
    public partial class Form1 : Form
    {
        List<string> words = new List<string>();
        List<string> tmp = new List<string>();
        List<string> _new = new List<string>();
        Thread thread;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            thread = new Thread(new ThreadStart(Search));
            thread.IsBackground = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOp = new OpenFileDialog();
            
            if (DialogResult.OK == dlgOp.ShowDialog())
            {               
                if (File.Exists(dlgOp.FileName))
                {
                    using (StreamReader reader = new StreamReader(dlgOp.FileName, Encoding.UTF8))
                    {
                        string str = reader.ReadToEnd();
                        _new = str.Split(("!@#$%^&*()_+=-{}][\"\'|\\?/.,<>;: \n\t" + Convert.ToChar(13)).ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                        words.AddRange(_new);
                        words = words.Distinct().ToList();
                        words.Sort();
                    }
                }               
                label1.Text = words.Count.ToString();
            }
        }

        public void Search()
        {
            
            string text = textBox1.Text.Split(' ').Last();
            if (text == "") { return; }
            foreach (var i in words)
            {
                if (i.StartsWith(text))
                {
                    listBox2.BeginInvoke(new Action(() =>
                    {
                        listBox2.Items.Add(i);
                    }));                    
                }
            }
        }

        private void Text_Changed(object sender, EventArgs e)
        {

            listBox2.Items.Clear();
            switch(thread.ThreadState)
            {
                case ThreadState.Unstarted | ThreadState.Background:
                    {
                        thread.Start();
                        break;
                    }
                case ThreadState.Running: case ThreadState.Stopped:
                case ThreadState.Background:
                    {
                        thread.Abort();
                        thread = new Thread(new ThreadStart(Search));
                        thread.IsBackground = true;
                        thread.Start();
                        break;
                    }
            }
            
            
            //Task.Run(() =>
            //{
            //    Search();
            //});

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ListBox).SelectedItem.ToString().Length.ToString());
        }
    }
}
