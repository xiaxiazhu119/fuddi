using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;

using Fuddi.Ctrls;

namespace Fuddi.Ctrls.App
{
    public class BaseApp : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //GlobalFilters.Filters.Add(new EnableCorsAttribute());
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://test.mall.fuddi.jp");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterView();
        }

        protected void RegisterView()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new Fuddi.Ctrls.ViewEngineExt());
        }
    }
}
