using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using Fuddi.Models;
using Fuddi.SiteUtils;
using Fuddi.BLL;
using Fuddi.Configuration;
using Fuddi.Enum;

using X.Common;

namespace Fuddi.Ctrls.CMS
{
    public class CategoryController : CMSBaseController
    {


        public ActionResult CategoryList()
        {
            return View();
        }

        public ActionResult CategoryEdit(int? action, string redirect)
        {
            TempData[setCfgInstance.REDIRECT_TEMPDATA_KEY] = HttpUtility.UrlDecode(redirect);
            return View();
        }

        public ActionResult Tree()
        {
            return View();
        }
    }
}
