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
            if (!File.Exists(@"书籍信息.txt"))
            {
                FileStream fs1 = new FileStream(@"书籍信息.txt", FileMode.Create, FileAccess.Write);//创建写入文件
                fs1.Close();
            }

            StreamReader read = new StreamReader(@"书籍信息.txt", Encoding.GetEncoding("gb2312"));
            //创建一个DATATABLE
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
        }

        private void Frm4_Load(object sender, EventArgs e)
        {
            MessageBox.Show("点击刷新显示书籍哦", "提示");
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
            bool x = true;
            for(int b =0; b<a-1 ;b++ )
            {
                if(textBox1.Text==bh[b])
                {
                    MessageBox.Show("你可以去拿书了", "成功");
                    x = false;
                   break;
                }
            }
            if(x)
            {
                MessageBox.Show("还没有这本书", "失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
