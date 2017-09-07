using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Model;

namespace Dal
{
    public class HallInfoDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<HallInfo> GetList()
        {
            string sql = "select * from HallInfo where HIsDelete = 0 ";
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql);

            //构造集合对象
            List<HallInfo> list = new List<HallInfo>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new HallInfo()
                {
                    HId = Convert.ToInt32(row["HId"]),
                    HTitle = row["HTitle"].ToString(),
                    HIsDelete = row["HIsDelete"].ToString().Equals("1")
                });

            }
            return list;
        }

        public int Insert(HallInfo mti)
        {
            string sql = "insert into HallInfo(HTitle,HIsDelete) values(@HTitle,@HIsDelete)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@HTitle", mti.HTitle),
                new SQLiteParameter("@HIsDelete", mti.HIsDelete),
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int DeleteById(int id)
        {
            string sql = "update HallInfo set HIsDelete=1 where HId=@HId";
            SQLiteParameter sp = new SQLiteParameter("@HId", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(HallInfo mi)
        {
            List<SQLiteParameter> listSp = new List<SQLiteParameter>();
            string sql = "update HallInfo set HTitle=@HTitle where HId=@HId";
            listSp.Add(new SQLiteParameter("@HTitle", mi.HTitle));
            listSp.Add(new SQLiteParameter("@HId", mi.HId));
            return SqliteHelper.ExecuteNonQuery(sql, listSp.ToArray());
        }
    }
}
