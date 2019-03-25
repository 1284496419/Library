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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm4 frm4 = new Frm4();
            this.Hide();
            frm4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader read1 = new StreamReader(@"借书记录.txt", Encoding.GetEncoding("gb2312"));
            string line1 = "";
            string[] yh = new string[100];
            string[] zk = new string[100];
            string[] bh = new string[100];
            bool flag = false;
            int a1 = 0;
            while ((line1 = read1.ReadLine()) != null)
            {
                string[] str = line1.Split('-');
                yh[a1] = str[0];
                bh[a1] = str[1];
                zk[a1] = str[2];
                a1++;
            }
            int x;
            for (int b = 0; b < a1 ; b++)
            {
                if (textBox1.Text == bh[b] && zk[b] == "N"&&Frm1.name==yh[b])
                {
                    flag = true;
                    zk[b] = "Y";
                    x = b;
                    break;
                }
            }
            read1.Close();
            if(flag)
            {
                MessageBox.Show("成功归还", "成功");
                StreamWriter fs1 = new StreamWriter(@"借书记录.txt", false);
                fs1.Write("");
                fs1.Close();
                StreamWriter fs = new StreamWriter(@"借书记录.txt", true);//文件
                for (int b = 0; b < a1; b++)
                {
                    string h = yh[b] + '-' + bh[b] + '-' + zk[b];
                    fs.WriteLine(h);
                        //开始写入
                }
                fs.Close();
            }
            else
            {
                MessageBox.Show("你还没有借这本书");
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
