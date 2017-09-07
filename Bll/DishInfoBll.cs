using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using Model;

namespace Bll
{
    public class DishInfoBll
    {
        private DishInfoDal mtlDal = new DishInfoDal();
        public List<DishInfo> GetList()
        {
            return mtlDal.GetList();
        }

        public bool Add(DishInfo mi)
        {
            return mtlDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return mtlDal.DeleteById(id) > 0;
        }

        public bool Update(DishInfo mi)
        {
            return mtlDal.Update(mi) > 0;
        }
    }
}
