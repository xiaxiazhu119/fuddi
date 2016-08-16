using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Enum;

namespace Fuddi.Ctrls.Mall
{
    public class PassportController : MallBaseController
    {
        public ActionResult SignIn(string redirect)
        {
            return View();
        }
        public ActionResult SignUp(string redirect)
        {
            return View();
        }
    }
}
