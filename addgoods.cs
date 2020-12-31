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
    public partial class addgoods : Form
    {
        public addgoods()
        {
            InitializeComponent();
        }

        private void addgoods_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认添加该商品？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Dao dao = new Dao();
                string sql = $"insert into goods values('{ textBox1.Text}', '{textBox2.Text }', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}')";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功!");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
