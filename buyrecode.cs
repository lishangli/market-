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
    public partial class buyrecode : Form
    {
        string ID;
        public buyrecode()
        {
            InitializeComponent();
        }
        public buyrecode(string id)
        {
            InitializeComponent();
            ID = id;
            Table();
            
        }
        private void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Daouser dao = new Daouser();
            string sql = $"select * from buyrecode  where uid='{ID}'";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
        }
        private void TableName()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Daouser dao = new Daouser();
            string sql = $"select * from buyrecode where uid = '{ID}'and gid='{textBox1.Text}'";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[1].ToString(), Convert.ToDouble(dc[2]), Convert.ToDateTime(dc[3]));
            }
            dc.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
