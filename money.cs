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
    public partial class money : Form
    {
        public money()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确任充值该账号？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Daouser dao = new Daouser();
                string sql = $"update userv set balance =balance + {Convert.ToDouble(textBox3.Text)} where uid='{textBox1.Text} 'and upsw ='{textBox2.Text}'";
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
