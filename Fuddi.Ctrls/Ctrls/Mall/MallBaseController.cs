using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Ctrls.Mall
{
    public class MallBaseController : BaseController
    {
        protected override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}
