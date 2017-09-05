using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using Model;

namespace Bll
{
    public class ManagerInfoBll
    {
        private ManagerInfoDal miDal = new ManagerInfoDal();
        public List<ManagerInfo> GetList()
        {
            return miDal.GetList();
        }

        public bool Add(ManagerInfo mi)
        {
            return miDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return miDal.DeleteById(id) > 0;
        }

        public bool Update(ManagerInfo mi)
        {
            bool b = mi.MPwd.Equals("******");
            return miDal.Update(mi, b) > 0;
        }
    }
}
