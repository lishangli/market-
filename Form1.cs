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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage= Image.FromFile(@"..\..\background\back2.jpg");
        }
        /*private void label1_Click(object sender, EventArgs e)
        {

        }*/
        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();

            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }
        public Boolean Login()
        {
            if (radioButtonUser.Checked == true)
            {
                Daouser dao1 = new Daouser();
                string sql = $"select * from user where uid='{ textBox1.Text}' and upsw='{ textBox2.Text}' ;";
                IDataReader dc = dao1.read(sql);

                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    user1 user = new user1(dc[0].ToString(),dc[1].ToString(),dc[3].ToString(),dc[4].ToString());
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                    return true;
                }
                else
                {
                    MessageBox.Show("登录失败");
                    return false;
                }
            }
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao1 = new Dao();
                string sql = $"select * from admin where uid='{ textBox1.Text}' and upsw='{ textBox2.Text}' ;";
                IDataReader dc = dao1.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    Data.UID = dc["uid"].ToString();
                    Data.UName = dc["uname"].ToString();
                    Admin admin = new Admin();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                    return true;
                }
                else
                {
                    MessageBox.Show("登录失败");
                    return false;
                }
            }
            return true;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
