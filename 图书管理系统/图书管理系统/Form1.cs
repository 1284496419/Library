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
    public partial class Frm1 : Form
    {
        public static Frm1 pFrm1 = null;
        public Frm1()
        {
            pFrm1 = this;
            InitializeComponent();
        }

        public static string name;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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
            if (!File.Exists(@"书籍信息.txt"))
            {
                FileStream fs1 = new FileStream(@"书籍信息.txt", FileMode.Create, FileAccess.Write);//创建写入文件
                fs1.Close();
            }
            if (!File.Exists(@"借书记录.txt"))
            {
                FileStream fs1 = new FileStream(@"借书记录.txt", FileMode.Create, FileAccess.Write);//创建写入文件
                fs1.Close();
            }

            panel1.Hide();

            //FileInfo fileInfo = new FileInfo(@"账号.txt");
            //fileInfo.Attributes |= FileAttributes.Hidden;
            //FileInfo fileInfo1 = new FileInfo(@"密码.txt");
            //fileInfo1.Attributes |= FileAttributes.Hidden;
            //FileInfo fileInfo2 = new FileInfo(@"书籍信息.txt");
            //fileInfo2.Attributes |= FileAttributes.Hidden;
            //FileInfo fileInfo3 = new FileInfo(@"借书记录.txt");
            //fileInfo3.Attributes |= FileAttributes.Hidden;

            //string filePath = @"账号.txt";
            //FileAttributes fileAttributes = File.GetAttributes(filePath);
            //string filePath1 = @"密码.txt";
            //FileAttributes fileAttributes1 = File.GetAttributes(filePath1);
            //string filePath2 = @"书籍信息.txt";
            //FileAttributes fileAttributes2 = File.GetAttributes(filePath2);
            //string filePath3 = @"借书记录.txt";
            //FileAttributes fileAttributes3 = File.GetAttributes(filePath3);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Text = "  ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] zh = File.ReadAllLines(@"账号.txt");
            string[] mm = File.ReadAllLines(@"密码.txt");
            bool b = false;
            if (textBox账号.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("请输入账号或密码");
                if (textBox账号.TextLength == 0)
                {
                    label5.Text = "请输入账号";
                }
                if (textBox2.TextLength == 0)
                {
                    label6.Text = "请输入密码";
                }
                return;
            }
            for (int a = 0; a < zh.Length; a++)
            {
                if (textBox账号.Text == zh[a] && textBox2.Text == mm[a])
                {
                    b = true;
                    break;
                }
            }
            if (b)
            {
                name = textBox账号.Text;
                Frm4 frm4 = new Frm4();
                frm4.Show();
                this.Hide();
            }
            else
            {
                if (textBox2.Text.Length != 0)
                {
                    label6.Text = "密码忘了吗";
                }
                MessageBox.Show("账号或密码错误");
            }
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (label6.Text == "密码忘了吗")
            {
                if (MessageBox.Show("去找密码？", "找回密码", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Frm3 frm3 = new Frm3();
                    this.Hide();
                    frm3.Show();
                }   
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "  ";
        }

        public void btnregister_Click(object sender, EventArgs e)
        {
            Frm2 frm2 = new Frm2();
            this.Hide();
            frm2.Show();
        }

        public void butmaster_Click(object sender, EventArgs e)
        {
            panel1.Show();
            MessageBox.Show("请输入管理员密码");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox3.Text=="awsl")
            {
                Frm6 frm6 = new Frm6();
                this.Hide();
                frm6.Show();
                panel1.Hide();
            }
        }

        private void Frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }
    }
}
