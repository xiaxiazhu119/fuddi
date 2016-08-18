using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Enum;
using X.Common;

namespace Fuddi.Ctrls.Mall
{
    public class ProductController : MallBaseController
    {
        public ActionResult List(int? cid)
        {
            int _cid = TypeConverter.ObjectToInt(cid, setCfgInstance.DEFAULT_INT_VALUE);
            TempData["cid"] = _cid;
            return View();
        }
        public ActionResult Detail(int? pid)
        {
            return View();
        }
    }
}
