using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls.Transport
{
    public class HomeController : TransportBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
