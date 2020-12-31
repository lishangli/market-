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
    public partial class addorders : Form
    {
        public addorders()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql= $"insert into orders values('{ textBox1.Text}', '{Convert.ToDouble(textBox2.Text) }', '{textBox3.Text}', '{DateTime.Now.ToLocalTime()}', '{textBox5.Text}')";
            int n=dao.Execute(sql);
            if(n>0)
            {
                MessageBox.Show("添加成功!");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
        }
    }
}
