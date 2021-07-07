using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace 连接数据库
{
    class Program
    {
        static void Main(string[] args)
        {
          new  MysqlCon().ConnectMySQL();
        }
    }
    public class MysqlCon
    {
        public void ConnectMySQL()
        {
            string content = "data source=localhost;database=idcv;user id=root;password=ntrj2020;pooling=true;charset=utf8;";
            using (MySqlConnection con = new MySqlConnection(content))
            {
                con.Open();
                //写入sql语句
                string sql = "select user_name,password from cmdb_user";
                //创建命令对象
                MySqlCommand cmd = new MySqlCommand(sql, con);
                //打开数据库连接

                DataTable datatable = new DataTable();
                MySqlDataAdapter Datapter = new MySqlDataAdapter(cmd);
                Datapter.Fill(datatable);

                //执行命令,ExcuteReader返回的是DataReader对象
                // MySqlDataReader reader = cmd.ExecuteReader();

                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    Console.WriteLine("用户名为{0}，密码为{1}", datatable.Rows[i][0], datatable.Rows[i][1]);
                }
                con.Close();
            }
        }
    }
  
}
