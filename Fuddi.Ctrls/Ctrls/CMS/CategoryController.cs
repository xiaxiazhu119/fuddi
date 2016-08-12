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
    public class CategoryController : CMSBaseController
    {
        CategoryBLL bll = new CategoryBLL();

        public ActionResult CategoryList(int? pageIndex, string name)
        {
            int pi = TypeConverter.ObjectToInt(pageIndex, defaultPageIndex);
            ViewData[setCfgInstance.PAGE_INDEX_VIEWDATA_KEY] = pi;
            int total = 0;
            var list = bll.GetCategoryListByCondition(name, pi, defaultPageSize, out total);

            var pagedList = new StaticPagedList<OD_Category>(list, pi, defaultPageSize, total);

            ViewData[setCfgInstance.TOTAL_ITEM_VIEWDATA_KEY] = total;

            return View(pagedList);
        }

        public ActionResult CategoryEdit(int? action, string redirect)
        {
            TempData[setCfgInstance.REDIRECT_TEMPDATA_KEY] = HttpUtility.UrlDecode(redirect);
            return View();
        }

        public ActionResult Tree()
        {
            return View();
        }
    }
}
