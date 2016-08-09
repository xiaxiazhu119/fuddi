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
    public class HomeController : CMSBaseController
    {
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(OD_Manager mgr)
        {
            mgr.Pwd =  Utils.MD5(mgr.Pwd);
            OD_Manager m = (new MgrBLL().SignIn(mgr));
            if (m != null)
            {
                sessionHelperInstance.SetSessionManager(m);
                return Redirect(setCfgInstance.CMS_DEFAULT);
            }
            mgr.Pwd = "";
            TempData[setCfgInstance.RESPONSE_TEMPDATA_KEY] = ResponseEnum.SignInFailed;
            return View(mgr);
        }
        public ActionResult Default()
        {
            CMSSiteMapCfg _ = CMSSiteMapCfg.Instance;
            return View();
        }
    }
}
