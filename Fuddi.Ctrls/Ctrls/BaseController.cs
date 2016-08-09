using Fuddi.Configuration;
using Fuddi.SiteUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls
{
    public class BaseController : Controller
    {
        protected internal SessionHelper sessionHelperInstance = SessionHelper.Instance;
        protected internal SettingsCfg setCfgInstance = SettingsCfg.Instance;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected internal JsonResult BuildJsonResult(object obj)
        {
            var jr = new JsonResult();
            jr.Data = obj;
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;//允许使用GET方式获取，否则用GET获取是会报错。  
            return jr;
        }

        

    }
}
