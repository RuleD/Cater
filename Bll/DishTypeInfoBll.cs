using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Dal;
using Model;

namespace Bll
{
    public class DishTypeInfoBll
    {
        private DishTypeInfoDal mtlDal = new DishTypeInfoDal();
        public List<DishTypeInfo> GetList()
        {
            return mtlDal.GetList();
        }

        public bool Add(DishTypeInfo mi)
        {
            return mtlDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return mtlDal.DeleteById(id) > 0;
        }

        public bool Update(DishTypeInfo mi)
        {
            return mtlDal.Update(mi) > 0;
        }
    }
}
