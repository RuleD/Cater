using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Model;

namespace Dal
{
    public class ManagerInfoDal
    {
        public List<ManagerInfo> GetList(ManagerInfo mi)
        {
            string sql = "select * from managerinfo ";
            List<SQLiteParameter> listSp = new List<SQLiteParameter>();
            if (mi != null)
            {
                sql += " where mname=@mname and mpwd=@mpwd";
                listSp.Add(new SQLiteParameter("@mname", mi.MName));
                listSp.Add(new SQLiteParameter("@mpwd", mi.MPwd));
            }

            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql, listSp.ToArray());
            
            //构造集合对象
            List<ManagerInfo> list=new List<ManagerInfo>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    Mid=Convert.ToInt32(row["mid"]),
                    MName=row["mname"].ToString(),
                    MPwd=row["mpwd"].ToString(),
                    MType=Convert.ToInt32(row["mtype"])
                });

            }
            return list;
        }

        public int Insert(ManagerInfo mi)
        {
            string sql = "insert into managerinfo(mname,mpwd,mtype) values(@mname,@mpwd,@mtype)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@mname", mi.MName),
                new SQLiteParameter("@mpwd", mi.MPwd),
                new SQLiteParameter("@mtype", mi.MType),
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int DeleteById(int id)
        {
            string sql = "delete from managerinfo where mid=@mid";
            SQLiteParameter sp=new SQLiteParameter("@mid",id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(ManagerInfo mi, bool b)
        {
            List<SQLiteParameter> listSp = new List<SQLiteParameter>();
            string sql = "update managerinfo set mname=@mname";
            if (!b)
            {
                sql += ",mpwd=@mpwd";
                listSp.Add(new SQLiteParameter("@mpwd",mi.MPwd));
            }
            sql+=",mtype=@mtype where mid=@mid";
            listSp.Add(new SQLiteParameter("@mname", mi.MName));
            listSp.Add(new SQLiteParameter("@mtype", mi.MType));
            listSp.Add(new SQLiteParameter("@mid", mi.Mid));
            return SqliteHelper.ExecuteNonQuery(sql, listSp.ToArray());
        }
    }
}
