using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Model;

namespace Dal
{
    public class MemberInfoDal
    {
        public List<MemberInfo> GetList()
        {
            string sql = "select m1.*,m2.MTitle from MemberInfo as m1 inner join MemberTypeInfo as m2 on m1.MTypeId=m2.MId where m1.mIsDelete = 0 ";
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql);
            //构造集合对象
            List<MemberInfo> list = new List<MemberInfo>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MName = row["MName"].ToString(),
                    MPhone = row["MPhone"].ToString(),
                    MMoney = Convert.ToDecimal(row["MMoney"].ToString()),
                    MTitle = row["MTitle"].ToString(),
                    MTypeId = Convert.ToInt32(row["MTypeId"]),
                    MIsDelete = row["MIsDelete"].ToString().Equals("1")
                });

            }
            return list;
        }

        public int Insert(MemberInfo mti)
        {
            string sql = "insert into MemberInfo(MName,MPhone,MMoney,MTypeId,MIsDelete) values(@MName,@MPhone,@MMoney,@MTypeId,@MIsDelete)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@MName", mti.MName),
                new SQLiteParameter("@MPhone", mti.MPhone),
                new SQLiteParameter("@MMoney", mti.MMoney),
                new SQLiteParameter("@MTypeId", mti.MTypeId),
                new SQLiteParameter("@MIsDelete", mti.MIsDelete),
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int DeleteById(int id)
        {
            string sql = "update MemberInfo set MIsDelete=1 where MId=@MId";
            SQLiteParameter sp = new SQLiteParameter("@MId", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(MemberInfo mti)
        {
            string sql = "update MemberInfo set MName=@MName,MPhone=@MPhone,MMoney=@MMoney,MTypeId=@MTypeId where MId=@MId";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@MName", mti.MName),
                new SQLiteParameter("@MPhone", mti.MPhone),
                new SQLiteParameter("@MMoney", mti.MMoney),
                new SQLiteParameter("@MTypeId", mti.MTypeId),
                new SQLiteParameter("@MId", mti.MId),
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
    }
}
