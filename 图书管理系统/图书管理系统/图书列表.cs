using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书管理系统
{
    public partial class Frm2 : Form
    {
        public Frm2()
        {
            InitializeComponent();
        }

        private void x_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退回到登录页面", "返回", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
                Frm1.pFrm1.Show();
            }
        }

        private void Frm2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎使用全世界最没用的图书管理系统","欢迎");
        }
    }
}
