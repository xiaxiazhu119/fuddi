using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Enum;

namespace Fuddi.Ctrls.Mall
{
    public class AnnouncementController : MallBaseController
    {
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            return View();
        }
    }
}
