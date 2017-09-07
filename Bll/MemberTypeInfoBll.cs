using System.Collections.Generic;
using Dal;
using Model;

namespace Bll
{
    public class MemberTypeInfoBll
    {
        private MemberTypeInfoDal mtlDal = new MemberTypeInfoDal();
        public List<MemberTypeInfo> GetList()
        {
            return mtlDal.GetList();
        }

        public bool Add(MemberTypeInfo mi)
        {
            return mtlDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return mtlDal.DeleteById(id) > 0;
        }

        public bool Update(MemberTypeInfo mi)
        {
            return mtlDal.Update(mi) > 0;
        }
    }
}
