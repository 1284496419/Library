using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书管理系统
{
    public partial class Frm6 : Form
    {
        public Frm6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(@"书籍信息.txt", Encoding.GetEncoding("gb2312"));
            string line = "";
            string[] bh = new string[100];
            string[] sj = new string[100];
            string[] zz = new string[100];
            int a = 0;
            while ((line = read.ReadLine()) != null)
            {
                string[] str = line.Split('-');
                sj[a] = str[0];
                bh[a] = str[1];
                zz[a] = str[2];
                a++;
            }
            read.Close();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                for (int b = 0; b < a - 1; b++)
                {
                    if (textBox2.Text == bh[b]||textBox1.Text == zz[b]|| textBox3.Text == sj[b])
                    {
                        MessageBox.Show("已经存在该书");
                    }
                    else
                    {
                        string tx = textBox3.Text + "-" + textBox2.Text + "-" + textBox1.Text;
                        StreamWriter fs = new StreamWriter(@"书籍信息.txt", true);//文件
                        fs.WriteLine(tx);
                        //开始写入
                        fs.Close();
                        MessageBox.Show("你已经添加了一本图书"); ;
                    }
                }
            }
            else
            {
                MessageBox.Show("书名，作者，编号不能为空");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }

        private void Frm6_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form7 from7 = new Form7();
            this.Hide();
            from7.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("书籍信息.txt");
            var query = lines.Where(x => !x.Contains(textBox2.Text)).ToArray();
            File.WriteAllLines("1.txt", query);
        }
    }
}
