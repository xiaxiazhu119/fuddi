using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Models;
using Fuddi.DAL;

namespace Fuddi.BLL
{
    public class MgrBLL
    {
        MgrDAL dal;

        public MgrBLL()
        {
            dal = new MgrDAL();
        }

        public OD_Manager SignIn(OD_Manager model)
        {
            return dal.SignIn(model);
        }
    }
}
