using System.Collections.Generic;
using Dal;
using Model;

namespace Bll
{
    public class HallInfoBll
    {
        private HallInfoDal mtlDal = new HallInfoDal();
        public List<HallInfo> GetList()
        {
            return mtlDal.GetList();
        }

        public bool Add(HallInfo mi)
        {
            return mtlDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return mtlDal.DeleteById(id) > 0;
        }

        public bool Update(HallInfo mi)
        {
            return mtlDal.Update(mi) > 0;
        }
    }
}
