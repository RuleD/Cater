using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using Model;

namespace Bll
{
    public class MemberInfoBll
    {
        private MemberInfoDal mtlDal = new MemberInfoDal();
        public List<MemberInfo> GetList()
        {
            return mtlDal.GetList();
        }

        public bool Add(MemberInfo mi)
        {
            return mtlDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return mtlDal.DeleteById(id) > 0;
        }

        public bool Update(MemberInfo mi)
        {
            return mtlDal.Update(mi) > 0;
        }
    }
}
