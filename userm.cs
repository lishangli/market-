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
    public partial class userm : Form
    {
        public userm()
        {
            InitializeComponent();
            Table();
        }
        private void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from user";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[4].ToString(), dc[3].ToString());
            }
            label2.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            dc.Close();
        }
        
        private void TableID()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from user where uid ='{textBox1.Text}' or uname ='{textBox1.Text}'";//textBox1.Text即输入框条件
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[4].ToString(), dc[3].ToString());
            }
            if (dataGridView1.Rows.Count > 0)
                label2.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            dc.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index-1;
            string uid = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string uname = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string upsw = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string uage= dataGridView1.Rows[index].Cells[3].Value.ToString();
            string balance = dataGridView1.Rows[index].Cells[4].Value.ToString();
            double blance = Convert.ToDouble(balance);
            DialogResult dr = MessageBox.Show("确认添加该用户？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Dao dao = new Dao();
                string sql = $"insert into user values('{uid}', '{uname }', '{upsw}', '{uage}', '{blance}')";
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
            Table();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index - 1;
            string uid = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string uname = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string upsw = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string uage = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string balance = dataGridView1.Rows[index].Cells[4].Value.ToString();
            double blance = Convert.ToDouble(balance);
            DialogResult dr = MessageBox.Show("确认修改该用户" +"？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Dao dao = new Dao();
                string sql = $"update user set uid='{uid}', uname='{uname }',upsw= '{upsw}', uage='{uage}',balance= '{blance}')";//数据库执行对应的语句
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
            Table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string uid;
            int index = dataGridView1.SelectedRows[0].Index - 1;
            if(index>=0)
            uid = dataGridView1.Rows[index].Cells[0].Value.ToString();
            else
            uid = dataGridView1.Rows[0].Cells[0].Value.ToString();

            DialogResult dr = MessageBox.Show("确认删除该用户？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Dao dao = new Dao();
                string sql = $"delete from user where uid='{uid}'";
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
            Table();
        }
    }
}
