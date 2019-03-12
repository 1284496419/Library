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
        public bool vip = false;
        public static Frm1 pFrm1 = null;
        public Frm1()
        {
            pFrm1 = this;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
            Frm2 frm2 = new Frm2();
            string[] zh = File.ReadAllLines(@"F:\账号.txt");
            string[] mm = File.ReadAllLines(@"F:\密码.txt");
            bool b = false;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("请输入账号或密码");
                if (textBox1.TextLength == 0)
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
                if (textBox1.Text == zh[a] && textBox2.Text == mm[a])
                {
                    b = true;
                    break;
                }
            }
            if (b)
            {
                frm2.Show();
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
            Frm4 frm4 = new Frm4();
            if (label6.Text == "密码忘了吗")
            {
                if (MessageBox.Show("去找密码？", "找回密码", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Hide();
                    frm4.Show();
                }   
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "请输入账号")
            {
                if(MessageBox.Show("来个账号？","注册账号",MessageBoxButtons.OKCancel)== DialogResult.OK)
                btnregister_Click(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "  ";
        }

        public void btnregister_Click(object sender, EventArgs e)
        {
            Frm3 frm3 = new Frm3();
            this.Hide();
            frm3.Show();
        }

        private void butmaster_Click(object sender, EventArgs e)
        {
            Frm2 frm2 = new Frm2();
            string[] szh = File.ReadAllLines(@"F:\管理员账号.txt");
            string[] smm = File.ReadAllLines(@"F:\管理员密码.txt");
            bool b = false;
            for (int a = 0; a < szh.Length; a++)
            {
                if (textBox1.Text == szh[a] && textBox2.Text == smm[a])
                {
                    b = true;
                    break;
                }
            }
            if (b)
            {
                vip = true;
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
        }
    }
}
