using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Model;

namespace Dal
{
    public class MemberTypeInfoDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MemberTypeInfo> GetList()
        {
            string sql = "select * from MemberTypeInfo where mIsDelete = 0 ";
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql);

            //构造集合对象
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    Mid = Convert.ToInt32(row["MId"]),
                    MTitle = row["MTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["MDiscount"].ToString()),
                    MIsDelete = row["MIsDelete"].ToString().Equals("1")
                });

            }
            return list;
        }

        public int Insert(MemberTypeInfo mti)
        {
            string sql = "insert into MemberTypeInfo(MTitle,MDiscount,MIsDelete) values(@MTitle,@MDiscount,@MIsDelete)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@MTitle", mti.MTitle),
                new SQLiteParameter("@MDiscount", mti.MDiscount),
                new SQLiteParameter("@MIsDelete", mti.MIsDelete),
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int DeleteById(int id)
        {
            string sql = "update MemberTypeInfo set MIsDelete=1 where MId=@MId";
            SQLiteParameter sp = new SQLiteParameter("@MId", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(MemberTypeInfo mi)
        {
            List<SQLiteParameter> listSp = new List<SQLiteParameter>();
            string sql = "update MemberTypeInfo set MTitle=@MTitle,MDiscount=@MDiscount where MId=@MId";
            listSp.Add(new SQLiteParameter("@MTitle", mi.MTitle));
            listSp.Add(new SQLiteParameter("@MDiscount", mi.MDiscount));
            listSp.Add(new SQLiteParameter("@MId", mi.Mid));
            return SqliteHelper.ExecuteNonQuery(sql, listSp.ToArray());
        }
    }
}
