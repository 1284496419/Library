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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"借书记录.txt"))
            {
                FileStream fs1 = new FileStream(@"借书记录.txt", FileMode.Create, FileAccess.Write);//创建写入文件
                fs1.Close();
            }
            StreamReader read = new StreamReader(@"借书记录.txt", Encoding.Default, false);
            //创建一个DATATABLE
            DataTable dt = new DataTable();
            dt.Columns.Add("借书者账号");
            dt.Columns.Add("书籍编号");
            dt.Columns.Add("是否归还");
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

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm6 frm6 = new Frm6();
            this.Hide();
            frm6.Show();
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
