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
    public partial class Frm3 : Form
    {
        public Frm3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool c = false;
            bool d = false;
            string[] a= File.ReadAllLines(@"账号");
            string[] sa = File.ReadAllLines(@"密码");
            for (int b=0; b<a.Length;b++)
            {
                if(textBox1.Text==a[b])
                {
                    c = true;
                    MessageBox.Show("你的密码是" + a[b]);
                    break;
                }
            }
            for (int b = 0; b < sa.Length; b++)
            {
                if (textBox1.Text == sa[b])
                {
                    d = true;
                    MessageBox.Show("你的密码是" + sa[b]);
                    break;
                }
            }
            if(d==false&&c==false)
            {
                MessageBox.Show("你怕不是来盗号的哦","没有该账号");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm1.pFrm1.Show();
            this.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Frm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("返回登录界面", "hh", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Frm1.pFrm1.Show();
            }
        }
    }
}
