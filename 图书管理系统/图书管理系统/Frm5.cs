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
            bool flag = true;
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
                    if (textBox2.Text == bh[b] || textBox1.Text == zz[b] || textBox3.Text == sj[b])
                    {
                        MessageBox.Show("已经存在该书");
                        flag = false;
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("书名，作者，编号不能为空");
                flag = false;
                return;
            }
            if (flag)
            {
                string path = @"书籍信息.txt";

                string str = textBox3.Text + "-" + textBox2.Text + "-" + textBox1.Text;
                FileStream fs = new FileStream(path, FileMode.Append);//文本加入不覆盖

                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);//转码

                sw.WriteLine(str);

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                //string tx = textBox3.Text + "-" + textBox2.Text + "-" + textBox1.Text;
                //StreamWriter fs = new StreamWriter(@"书籍信息.txt", true);//文件
                //fs.WriteLine(tx);
                ////开始写入
                //fs.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("你已经添加了一本图书");
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
            Form7 frm7 = new Form7();
            this.Hide();
            frm7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入书籍编号", "错误");
                return; 
            }
            StreamReader read = new StreamReader(@"书籍信息.txt", Encoding.GetEncoding("gb2312"));
            string line = "";
            string[] bh = new string[100];
            string[] zz = new string[100];
            string[] sj = new string[100];
            int a = 0;
            bool flag = true;
            while ((line = read.ReadLine()) != null)
            {
                string[] str = line.Replace("-", "-").Split('-');
                zz[a] = str[2];
                sj[a] = str[0];
                bh[a] = str[1];
                a++;
            }
            read.Close();
            for (int b = 0; b <a; b++)
            {
                if (textBox2.Text == bh[b])
                {
                    flag = false;
                }
            }
            if (flag)
            {
                MessageBox.Show("还没有这本书", "失败");
            }
            else
            {
                MessageBox.Show("成功删除", "成功");
                StreamWriter fs1 = new StreamWriter(@"书籍信息.txt", false);
                fs1.Write("");
                fs1.Close();
                StreamWriter fs = new StreamWriter(@"书籍信息.txt",  true);//文件
                for (int b = 0; b < a; b++)
                {
                    if (bh[b] != textBox2.Text)
                    {
                        string x = sj[b] + '-' + bh[b] + '-' + zz[b];
                        fs.WriteLine(x);
                        //开始写入
                    }
                }
                fs.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm1 frm1 = new Frm1();
            frm1.Show();
            this.Hide();
        }

        private void Frm6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
