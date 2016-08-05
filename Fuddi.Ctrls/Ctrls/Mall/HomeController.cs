using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Enum;

namespace Fuddi.Ctrls.Mall
{
    public class HomeController : MallBaseController
    {
        public ActionResult Index()
        {
            string a = EnumClass.GetAccountStatusDesc(AccountStatusEnum.Normal);
            return View();
        }
    }
}
