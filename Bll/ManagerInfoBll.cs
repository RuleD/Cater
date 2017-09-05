using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Dal;
using Model;

namespace Bll
{
    public class ManagerInfoBll
    {
        private ManagerInfoDal miDal = new ManagerInfoDal();
        public List<ManagerInfo> GetList(ManagerInfo mi)
        {
            return miDal.GetList(mi);
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
            if (!b)
            {
                mi.MPwd = MD5Helper.GetMD5(mi.MPwd);
            }
            return miDal.Update(mi, b) > 0;
        }

        public bool Login(ManagerInfo mi)
        {
            var miList = miDal.GetList(mi);
            if (miList.Count > 0)
            {
                mi.MType = miList[0].MType;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
