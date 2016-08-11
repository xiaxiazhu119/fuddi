using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls.CMS
{
    public class ApiController : CMSBaseController
    {
        public JsonResult EditCategory(int gid, int id, string name)
        {
            return BuildJsonResult(new { Name = "小明", Age = 22, Sex = "男" });
        }
        public JsonResult EditCategoryGroup(int id, string name)
        {
            return BuildJsonResult(new { Name = "小明", Age = 22, Sex = "男" });
        }
    }
}
