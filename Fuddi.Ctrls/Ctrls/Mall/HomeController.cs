using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls.Mall
{
    public class HomeController : MallBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
