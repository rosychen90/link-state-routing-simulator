using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace LSRS
{
    public partial class Form1 : Form
    {
        Dijkstra graph = new Dijkstra();
        public int num;
        public int[,] L;
        public string tips;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Title = "Open Files";
            opendlg.Filter = "Text File(*.txt)|*.txt";
            opendlg.RestoreDirectory = true;
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                table.Text = "";
                string path = opendlg.FileName;
                FileStream myStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader myStreamReader = new StreamReader(path, System.Text.Encoding.Default);
                string str = myStreamReader.ReadLine();
                int a = 0;
                int b;
                num = str.Split(' ').Length;
                L = new int[num, num];
                while (str != null)
                {
                    string[] line = str.Split(' ');
                    for (b = 0; b < line.Length; b++)
                    {
                        table.Text = table.Text + line[b] + ' ';
                        L[a, b] = int.Parse(line[b]);
                    }
                    a++;
                    table.Text = table.Text + "\r\n";
                    str = myStreamReader.ReadLine();
                }
                myStreamReader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                if (Int32.Parse(snode.Text) > num || Int32.Parse(snode.Text) < 0)
                {
                    tips = "The router number should between 1 and " + num.ToString();
                    MessageBox.Show(tips, "ERROR");
                }
                else
                {
                    int v = int.Parse(snode.Text) - 1;
                    graph.Initial(num, L, v);
                    graph.DijkstraSolving();
                    string s1 = "";
                    string s2 = "";
                    for (int i = num - 1; i >= 0; i--)
                    {
                        s1 = graph.printPath(i) + "\r\n" + s1;
                        s2 = (i + 1).ToString() + "\r\n" + s2;
                    }
                    interf.Text = s1;
                    dest.Text = s2;              
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
          
                if (Int32.Parse(snode.Text) > num || Int32.Parse(snode.Text) < 0)
                    MessageBox.Show(tips, "ERROR");
                else
                {
                    if (Int32.Parse(dnode.Text) > num || Int32.Parse(dnode.Text) < 0)
                        MessageBox.Show(tips, "ERROR");
                    else
                    {
                        int o = Int32.Parse(dnode.Text) - 1;
                        Path.Text = graph.printPath(o);
                        Distance.Text = graph.D[o].ToString();
                    }
                }
            }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CS542 Project\r\n By Ruoxi Chen, A20284330 \r\n Yibin Qiu,A20295458","ABOUT");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult quit = MessageBox.Show("Exit CS542 Project, Bye!", "EXIT");
            if (quit == DialogResult.OK)
            {
                this.Close();
            }
        }
        }
    
}
