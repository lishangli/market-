using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermatkermager
{
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();

        }
        string ID;
        public user1(string uid,string uname,string uage,string balance)
        {
            InitializeComponent();
            ID = uid;
            Table();
            /*label5.Text = uname;
            label7.Text = uage;
            label6.Text = balance;*/
        }
        private void Table()
        {
            //dataGridView1.Rows.Clear();//清空旧数据
            Daouser dao = new Daouser();
            string sql = $"select * from userv where uid ='{ID}'";
            IDataReader dc = dao.read(sql);
            dc.Read();
            label5.Text = dc[1].ToString();
            label7.Text = dc[3].ToString();
            label6.Text = dc[4].ToString();
            dc.Close();
        }
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buy buy1 = new buy(ID);
            this.Hide();
            buy1.ShowDialog();
            Table();
            this.Show();
           
        }

        private void 系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 购买记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buyrecode buyr = new buyrecode(ID);
            this.Hide();
            buyr.ShowDialog();
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            money m1 = new money();
            this.Hide();
            m1.ShowDialog();
            this.Show();

        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("README.html");
        }
    }
}
