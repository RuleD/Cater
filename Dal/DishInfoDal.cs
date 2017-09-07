using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Model;

namespace Dal
{
    public class DishInfoDal
    {
        public List<DishInfo> GetList()
        {
            string sql = "select m1.*,m2.DTitle as DTypeTitle from DishInfo as m1 inner join DishTypeInfo as m2 on m1.DTypeId=m2.DId where m1.DIsDelete = 0 ";
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql);
            //构造集合对象
            List<DishInfo> list = new List<DishInfo>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTitle = row["DTitle"].ToString(),
                    DPrice = Convert.ToDecimal(row["DPrice"].ToString()),
                    DChar = row["DChar"].ToString(),
                    DTypeId = Convert.ToInt32(row["DTypeId"]),
                    DIsDelete = row["DIsDelete"].ToString().Equals("1"),
                    DTypeTitle = row["DTypeTitle"].ToString()
                });

            }
            return list;
        }

        public int Insert(DishInfo mti)
        {
            string sql = "insert into DishInfo(DTitle,DPrice,DChar,DTypeId,DIsDelete) values(@DTitle,@DPrice,@DChar,@DTypeId,@DIsDelete)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@DTitle", mti.DTitle),
                new SQLiteParameter("@DPrice", mti.DPrice),
                new SQLiteParameter("@DChar", mti.DChar),
                new SQLiteParameter("@DTypeId", mti.DTypeId),
                new SQLiteParameter("@DIsDelete", mti.DIsDelete),
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int DeleteById(int id)
        {
            string sql = "update DishInfo set DIsDelete=1 where DId=@DId";
            SQLiteParameter sp = new SQLiteParameter("@DId", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(DishInfo mti)
        {
            string sql = "update DishInfo set DTitle=@DTitle,DPrice=@DPrice,DChar=@DChar,DTypeId=@DTypeId where DId=@DId";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@DTitle", mti.DTitle),
                new SQLiteParameter("@DPrice", mti.DPrice),
                new SQLiteParameter("@DChar", mti.DChar),
                new SQLiteParameter("@DTypeId", mti.DTypeId),
                new SQLiteParameter("@DId", mti.DId),
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
    }
}
