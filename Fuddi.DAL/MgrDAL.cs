using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Models;
using Fuddi.Enum;

namespace Fuddi.DAL
{
    public class MgrDAL : BaseDAL
    {
        public OD_Manager SignIn(OD_Manager model)
        {
            var rst = (from a in entityInstance.OD_Manager
                       where a.UserName.Equals(model.UserName) && a.Pwd.Equals(model.Pwd) && a.Status.Equals((int)AccountStatusEnum.Normal) && !a.DelFlag
                       select new MgrModel()
                       {
                           ID = a.ID,
                           UserName = a.UserName
                       }).FirstOrDefault();
            return rst;
        }
    }
}
