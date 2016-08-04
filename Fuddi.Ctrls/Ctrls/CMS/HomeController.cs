using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls.CMS
{
    public class HomeController : CMSBaseController
    {
        public ActionResult Default()
        {
            return View();
        }
    }
}
