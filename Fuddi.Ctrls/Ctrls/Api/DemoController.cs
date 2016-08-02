using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls.Api
{
    public class DemoController : ApiBaseController
    {
        [EnableCors]
        public JsonResult Index()
        {
            return BuildJsonResult(new { Name = "小明", Age = 22, Sex = "男" });
        }
    }
}
