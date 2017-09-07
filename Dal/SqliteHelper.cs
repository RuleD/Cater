using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Dal
{
    public class SqliteHelper
    {
        private static string _connStr = ConfigurationManager.ConnectionStrings["CATER"].ConnectionString;

        public static DataTable GetList(string sql, params SQLiteParameter[] sp)
        {
            //构造链接对象
            using (SQLiteConnection con=new SQLiteConnection(_connStr))
            {
                //构造桥接器对象
                SQLiteDataAdapter adapter=new SQLiteDataAdapter(sql,con);
                adapter.SelectCommand.Parameters.AddRange(sp);
                //数据表对象
                DataTable table=new DataTable();
                //将数据库存储到table
                adapter.Fill(table);
                //返回数据表
                return table;
            }
        }

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] sp)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connStr))
            {
                SQLiteCommand cmd=new SQLiteCommand(sql,conn);
                cmd.Parameters.AddRange(sp);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
