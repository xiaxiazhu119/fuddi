using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;

namespace Fuddi.Ctrls.App
{
    public class ApiApp : BaseApp
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            GlobalFilters.Filters.Add(new EnableCorsAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://test.mall.fuddi.jp");
        }
    }
}
