using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Enum;

namespace Fuddi.Ctrls.Mall
{
    public class ProductController : MallBaseController
    {
        public ActionResult List(int? cid)
        {
            return View();
        }
    }
}
