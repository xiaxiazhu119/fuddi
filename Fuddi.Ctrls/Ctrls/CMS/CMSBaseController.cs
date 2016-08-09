using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Models;
using Fuddi.SiteUtils;
using Fuddi.Configuration;

namespace Fuddi.Ctrls.CMS
{
    public class CMSBaseController : BaseController
    {
        public IList<CMSSiteMapModel> siteMap = CacheHelper.Instance.CMSSiteMapList;        

        protected override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            bool needAuthorization = SiteUtil.Instance.CheckAuthorization();
            if (needAuthorization) {
                OD_Manager m = sessionHelperInstance.SessionManager;
                if (m == null) {
                    //filterContext.Result = new RedirectResult(setCfgInstance.CMS_SIGNIN);
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
