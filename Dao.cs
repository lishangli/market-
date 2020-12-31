using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace supermatkermager
{
    class Dao
    {
        MySqlConnection conn;
        public MySqlConnection connect()
        {
            string connStr = "server = localhost; user = root; database = market; port = 3306; password = 1234";
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return conn;
        }
        public MySqlCommand command(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }
        public MySqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
        public void Daoclose()
        {
            conn.Close();
        }

    }
}
