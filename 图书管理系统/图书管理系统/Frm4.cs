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
    public partial class Frm4 : Form
    {
        public Frm4()
        {
            InitializeComponent();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(@"书籍信息.txt", Encoding.GetEncoding("gb2312"));
            //创建一个DATATABL
            DataTable dt = new DataTable();
            dt.Columns.Add("书名", typeof(String));
            dt.Columns.Add("编号", typeof(String));
            dt.Columns.Add("作者", typeof(String));
            //循环读取行数，一行一行的读
            string line = "";
            while ((line = read.ReadLine()) != null)
            {
                string[] str = line.Split('-'); //使用空格分隔的内容
                DataRow dr = dt.NewRow();
                // 也可以这样写，但是如果文本后面有空格，会出错dr.ItemArray =str ;
                dr[0] = str[0];
                dr[1] = str[1];
                dr[2] = str[2];
                dt.Rows.Add(dr);
            }
            this.dataGridView1.DataSource = dt;
            read.Close();
        }

        private void Frm4_Load(object sender, EventArgs e)
        {
            MessageBox.Show("点击刷新显示书籍哦", "提示");
            panel1.Show();
            label2.Text += Frm1.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(@"书籍信息.txt", Encoding.Default, false);
            string line = "";
            string[] bh = new string[100];
            int a = 0;
            while ((line = read.ReadLine()) != null)
            {
                string[] str = line.Split('-');
                bh[a] = str[1];
                a++;
            }
            read.Close();
            //检查是否已借出
            StreamReader read1 = new StreamReader(@"借书记录.txt", Encoding.Default, false);
            string line1 = "";
            string[] zk= new string[100];
            string[] bh1 = new string[100];
            bool flag = true;
            bool flag1 = false;
            int a1 = 0;
            while ((line1 = read1.ReadLine()) != null)
            {
                string[] str = line1.Split('-');
                bh1[a1] = str[1];
                zk[a1] = str[2];
                a1++;
            }
            for (int b = 0; b < a; b++)
            {
                if (textBox1.Text == bh1[b]&&zk[b]== "N")
                {
                    flag1 = true;
                    flag = false;
                    break;
                }
            }
            read1.Close();
            //检查是否有这本书
            bool x = true;
            for(int b =0; b<a ;b++ )
            {
                if(textBox1.Text==bh[b])
                {
                    x = false;
                    if (flag)
                    {
                        MessageBox.Show("你可以去拿书了", "成功");
                        StreamWriter fs = new StreamWriter(@"借书记录.txt", true);//文件
                        fs.WriteLine(Frm1.name + '-' + textBox1.Text + '-' + "N");
                        //开始写入
                        fs.Close();
                        break;
                    }
                }
            }
            if(x)
            {
                MessageBox.Show("还没有这本书", "失败");
            }
            if(flag1)
            {
                MessageBox.Show("这本书已经借出，过一段时间再来吧", "失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void Frm4_FontChanged(object sender, EventArgs e)
        {

        }

        private void Frm4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
