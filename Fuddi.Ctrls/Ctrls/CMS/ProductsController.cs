using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Models;
using Fuddi.SiteUtils;
using Fuddi.BLL;
using Fuddi.Configuration;
using Fuddi.Enum;

using X.Common;

namespace Fuddi.Ctrls.CMS
{
    public class ProductsController : CMSBaseController
    {
        public ActionResult ProductList()
        {
            return View();
        }
        public ActionResult ProductDetail()
        {
            return View();
        }
    }
}
