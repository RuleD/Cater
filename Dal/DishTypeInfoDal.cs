using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Model;

namespace Dal
{
    public class DishTypeInfoDal
    {
        public List<DishTypeInfo> GetList()
        {
            string sql = "select * from DishTypeInfo where DIsDelete = 0 ";
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql);

            //构造集合对象
            List<DishTypeInfo> list = new List<DishTypeInfo>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTitle = row["DTitle"].ToString(),
                    DIsDelete = Convert.ToBoolean(row["DIsDelete"].ToString())
                });

            }
            return list;
        }

        public int Insert(DishTypeInfo mti)
        {
            string sql = "insert into DishTypeInfo(DTitle,DIsDelete) values(@DTitle,@DIsDelete)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@DTitle", mti.DTitle),
                new SQLiteParameter("@DIsDelete", mti.DIsDelete)
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int DeleteById(int id)
        {
            string sql = "update DishTypeInfo set DIsDelete=1 where DId=@DId";
            SQLiteParameter sp = new SQLiteParameter("@DId", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(DishTypeInfo mi)
        {
            List<SQLiteParameter> listSp = new List<SQLiteParameter>();
            string sql = "update MemberTypeInfo set DTitle=@DTitle where DId=@DId";
            listSp.Add(new SQLiteParameter("@DTitle", mi.DTitle));
            listSp.Add(new SQLiteParameter("@DId", mi.DId));
            return SqliteHelper.ExecuteNonQuery(sql, listSp.ToArray());
        }
    }
}
