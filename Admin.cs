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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goods good = new goods();
            this.Hide();
            good.ShowDialog();
            this.Show();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userm user = new userm();
            this.Hide();
            user.ShowDialog();
            this.Show();

        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orders order = new orders();
            this.Hide();
            order.ShowDialog();
            this.Show();
        }

        private void 销售管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sales sale = new sales();
            this.Hide();
            sale.ShowDialog();
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
