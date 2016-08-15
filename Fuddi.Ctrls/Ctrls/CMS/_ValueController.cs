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
using PagedList;

namespace Fuddi.Ctrls.CMS
{
    public class _ValueController : CMSBaseController
    {
        ValueBLL bll = new ValueBLL();

        public ActionResult TypeList()
        {
            var list = bll.GetAllValueTypeList();

            return View(list);
        }
    }
}
