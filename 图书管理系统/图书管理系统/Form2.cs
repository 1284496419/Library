using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 图书管理系统
{
    public partial class Frm2 : Form
    {
        public Frm2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length<=6)
            {
                label5.Text = "应大于6个字符";
            }
            if (textBox2.Text.Length < 15&& textBox2.Text.Length>6)
            {
                label5.Text = " ";
            }
            if (textBox2.Text.Length > 15)
            {
                label5.Text = "应小于16个字符";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 6)
            {
                label4.Text = "应大于6个数字";
            }
            if (textBox1.Text.Length <= 11 && textBox2.Text.Length > 6)
            {
                label4.Text = "  ";
            }
            if (textBox1.Text.Length > 11)
            {
                label4.Text = "应小于11个数字";
            }
            int b = textBox1.Text.Length;
            if (b != 0)
            {
                if (textBox1.Text[b - 1] < '0' && textBox1.Text[b - 1] > '9')
                {
                    MessageBox.Show("账号只能填入数字");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text!=textBox2.Text)
            {
                label6.Text = "密码不一致";
            }
            if (textBox3.Text == textBox2.Text)
            {
                label6.Text = " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm1.pFrm1.Show();
            this.Hide();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length < 15 && textBox2.Text.Length > 6&& textBox1.Text.Length < 11 && textBox2.Text.Length > 6&& textBox3.Text == textBox2.Text&& textBox1.Text.Length >6)
            {
                if (!File.Exists(@"账号.txt"))
                {
                    FileStream fs1 = new FileStream(@"账号.txt", FileMode.Create, FileAccess.Write);//创建写入文件
                    fs1.Close();
                }
                if (!File.Exists(@"密码.txt"))
                {
                    FileStream fs1 = new FileStream(@"密码.txt", FileMode.Create, FileAccess.Write);//创建写入文件
                    fs1.Close();
                }
                string[] line = File.ReadAllLines(@"账号.txt");
                bool x = true;
                for (int a = 0; a < line.Length; a++)
                {
                    if (textBox1.Text == line[a])
                    {
                        x = false;
                        break;
                    }
                }
                if(x)
                {
                    StreamWriter fs = new StreamWriter(@"账号.txt", true);//文件
                    fs.WriteLine(textBox1.Text);
                    //开始写入
                    fs.Close();
                    StreamWriter fs1 = new StreamWriter(@"密码.txt", true);//文件
                    fs1.WriteLine(textBox2.Text);
                    //开始写入
                    fs1.Close();
                    MessageBox.Show("前往登录界面");
                    this.Hide();
                    Frm1.pFrm1.Show();
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("已经存在该帐号");
                }
            }
            else if (textBox3.Text != textBox2.Text)
            {
                label6.Text = "密码不一致";
            }
            else if (textBox1.Text.Length <= 6)
            {
                label4.Text = "应大于6个数字";
            }
            else if (textBox2.Text.Length <= 6)
            {
                label5.Text = "应大于6个字符";
            }

        }

        private void Frm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Frm2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
