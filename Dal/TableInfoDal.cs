using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Model;

namespace Dal
{
    public class TableInfoDal
    {
        public List<TableInfo> GetList(params int[] str)
        {
            string sql = "select m1.*,m2.HTitle as THallTitle from TableInfo as m1 inner join HallInfo as m2 on m1.THallId=m2.HId where m1.TIsDelete = 0 ";
            List<SQLiteParameter> listSp = new List<SQLiteParameter>();
            if (str != null && str.Length > 0)
            {
                sql += " and m2.HId = @HId";
                listSp.Add(new SQLiteParameter("HId",str[0]));
            }
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql,listSp.ToArray());
            //构造集合对象
            List<TableInfo> list = new List<TableInfo>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new TableInfo()
                {
                    TId = Convert.ToInt32(row["TId"]),
                    TTitle = row["TTitle"].ToString(),
                    THallId = Convert.ToInt32(row["THallId"]),
                    TIsFree = Convert.ToBoolean(row["TIsFree"].ToString()),
                    TIsDelete = row["TIsDelete"].ToString().Equals("1"),
                    THallTitle = row["THallTitle"].ToString()
                });

            }
            return list;
        }

        public int Insert(TableInfo mti)
        {
            string sql = "insert into TableInfo(TTitle,THallId,TIsFree,TIsDelete) values(@TTitle,@THallId,@TIsFree,@TIsDelete)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@TTitle", mti.TTitle),
                new SQLiteParameter("@THallId", mti.THallId),
                new SQLiteParameter("@TIsFree", mti.TIsFree),
                new SQLiteParameter("@TIsDelete", mti.TIsDelete)
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int DeleteById(int id)
        {
            string sql = "update TableInfo set TIsDelete=1 where TId=@TId";
            SQLiteParameter sp = new SQLiteParameter("@TId", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(TableInfo mti)
        {
            string sql = "update TableInfo set TTitle=@TTitle,THallId=@THallId where TId=@TId";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@TTitle", mti.TTitle),
                new SQLiteParameter("@THallId", mti.THallId),
                new SQLiteParameter("@TId", mti.TId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
    }
}
