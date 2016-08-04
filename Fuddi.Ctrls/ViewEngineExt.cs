using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls
{
    
    public class ViewEngineExt : RazorViewEngine
    {
        public ViewEngineExt()
        {
            ViewLocationFormats = new[]{
                "~/Views/{1}/{0}.cshtml",
                "~/Views/_CMS/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

    }
}
