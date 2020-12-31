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
    public partial class chorders : Form
    {
        string ID = "";
        public chorders()
        {
            InitializeComponent();
        }
        public chorders(string id, double cost, string post, DateTime data, string gid)
        {
            InitializeComponent();
            textBox1.Text = id;
            ID = id;
            textBox2.Text = cost.ToString();
            textBox3.Text = post;
            textBox4.Text = data.ToString();
            textBox5.Text = gid;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update orders set orderid='{textBox1.Text}',ocost='{Convert.ToDouble(textBox2.Text)}',opost='{textBox3.Text}',data='{Convert.ToDateTime(textBox4.Text)}',gid='{textBox5.Text}' where orderid='{ID}'";
            Dao dao = new Dao();
            if(dao.Execute(sql)>0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
