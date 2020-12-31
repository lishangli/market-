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
    public partial class altgoods : Form
    {
        public altgoods()
        {
            InitializeComponent();
        }
        public altgoods(string gid,string gname,string gcost,string gmount,string gfrim)
        {
            InitializeComponent();
            textBox1.Text = gid;
            textBox2.Text = gname;
            textBox3.Text = gcost;
            textBox4.Text = gmount;
            textBox5.Text = gfrim;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确任修改该商品？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Dao dao = new Dao();
                string sql = $"update goods set gid='{ textBox1.Text}', gname='{textBox2.Text }', gcost='{Convert.ToDouble(textBox3.Text)}', gmount='{Convert.ToInt32(textBox4.Text)}', gfirm='{textBox5.Text}' where gid ={textBox1.Text}";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("修改成功!");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
