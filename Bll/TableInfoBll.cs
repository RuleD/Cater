using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using Model;

namespace Bll
{
    public class TableInfoBll
    {
        private TableInfoDal mtlDal = new TableInfoDal();
        public List<TableInfo> GetList(params int[] str)
        {
            return mtlDal.GetList(str);
        }

        public bool Add(TableInfo mi)
        {
            return mtlDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return mtlDal.DeleteById(id) > 0;
        }

        public bool Update(TableInfo mi)
        {
            return mtlDal.Update(mi) > 0;
        }
    }
}
