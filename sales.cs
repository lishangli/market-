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
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
            Table();
        }
        private void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from sale";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[4].ToString(), dc[3].ToString());
            }
            
            dc.Close();
        }
        private void TableID()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from sale where sid = '{textBox1.Text}' or gname like '%{textBox1.Text}%'";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[4].ToString(), dc[3].ToString());
            }
            dc.Close();
        }
        private void TableDate(string day)
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from sale where date like '%{day}%'";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[4].ToString(), dc[3].ToString());
            }
            dc.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            string Day = date.Day.ToString();
            string hours = date.Hour.ToString();
            string minute = date.Minute.ToString();
            string second = date.Second.ToString();
            TableDate(Day);
            Dao dao = new Dao();
            string sql = $"select sum(sprice) from sale where date like '%{year}%'";
            IDataReader dc = dao.read(sql);
            dc.Read();
            label6.Text = dc[0].ToString();
            string sql1 = $"select sum(sprice) from sale where date like '%{year}/{month}%'";
            IDataReader dc1 = dao.read(sql1);
            dc1.Read();
            label4.Text = dc1[0].ToString();
            string sql2 = $"select sum(sprice) from sale where date like '%{year}/{month}/{Day}%'";
            IDataReader dc2 = dao.read(sql2);
            dc2.Read();
            label2.Text = dc2[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
