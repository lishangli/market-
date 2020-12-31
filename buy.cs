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
    public partial class buy : Form
    {
        string ID;
        public buy()
        {
            InitializeComponent();
            Table();
        }
        public buy(string id)
        {
            InitializeComponent();
            Table();
            ID = id;
        }
        private void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Daouser dao = new Daouser();
            string sql = $"select gname,gcost,gmount from goodsv";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(),dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
        }
        private void TableName()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Daouser dao = new Daouser();
            string sql = $"select gname,gcost,gmount from goodsv where gname='{textBox1.Text}'";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("确认购买该商品？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string gnames = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (dr == DialogResult.OK)
            {
                string date = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
                
                Daouser dao = new Daouser();
                string sql2 = $"select * from goodsv where gname ='{gnames}'";

                string sql3 = $"select * from userv where uid='{ID}'";
                IDataReader dc = dao.read(sql2);
                IDataReader dc1 = dao.read(sql3);
                dc.Read();
                dc1.Read();
                double price = Convert.ToDouble(dc[2]);
                string sqll = $"insert into buyrecode values ('{ID}','{dc[0].ToString()}','{price}','{DateTime.Now.ToLocalTime()}')";
               
                string sqlll = $"update user set balance=balance-{price} where uid='{ID}'";
                string sqllll = $"insert into sale values ('{date}','{dc[0].ToString()}','{dc[1].ToString()}','{price}','{DateTime.Now.ToLocalTime()}')";
                string sql;
                int mount = Convert.ToInt32(dc[3]);
                if (mount > 0)
                    sql = $"update goods  set gmount=gmount-1 where gname='{gnames}'";
                else
                    sql = "";

                if (Convert.ToDouble(dc1[4]) > price)
                {
                    if (dao.Execute(sql) > 0 && (dao.Execute(sqll) > 0) && (dao.Execute(sqlll) > 0) && (dao.Execute(sqllll) > 0))
                    {
                        MessageBox.Show("购买成功");

                        Table();
                    }
                    else
                    {
                        MessageBox.Show("购买失败" + sql);
                    }
                }
                else
                {
                    MessageBox.Show("余额不足，请充值！");
                }
                dao.Daoclose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
