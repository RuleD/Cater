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
        public List<ManagerInfo> GetList()
        {
            return  new ManagerInfoDal().GetList();
        }
    }
}
