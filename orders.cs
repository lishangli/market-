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
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();
            Table(); 
        }
        

        private void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from orders";
            IDataReader dc = dao.read(sql);

            while(dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(),dc[4].ToString());
            }
            if(dataGridView1.Rows.Count>0)
            label2.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            dc.Close();
        }
        private void TableID()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();   
            string sql = $"select * from orders where orderid='{textBox1.Text}'";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            if(dataGridView1.Rows.Count>0)
            label2.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            dc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addorders add = new addorders();
            this.Hide();
            add.ShowDialog();
        
            this.Show();
            Table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除该订单？","信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(dr==DialogResult.OK)
                {
                    string sql = $"delete from orders where orderid={id}";
                    Dao dao = new Dao();
                    if(dao.Execute(sql)>0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                    dao.Daoclose();
                }
            }
            catch
            {
                MessageBox.Show("请先选择要删除的订单记录","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            Table();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           ///// label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                double cost = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[1].Value);
                string post = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                DateTime data = Convert.ToDateTime (dataGridView1.SelectedRows[0].Cells[3].Value);
                string gid = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                chorders ch1 = new chorders(id,cost,post,data,gid);
                ch1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
