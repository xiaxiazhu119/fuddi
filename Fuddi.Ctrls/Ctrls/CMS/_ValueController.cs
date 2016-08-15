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
    public class _ValueController : CMSBaseController
    {
        ValueBLL bll = new ValueBLL();

        public ActionResult TypeList()
        {
            var list = bll.GetAllValueType();

            return View(list);
        }

        public ActionResult RelationList(int? pageIndex, int? vid)
        {
            int pi = TypeConverter.ObjectToInt(pageIndex, defaultPageIndex);
            int valueid = TypeConverter.ObjectToInt(vid, defaultIntValue);
            ViewData[setCfgInstance.PAGE_INDEX_VIEWDATA_KEY] = pi;

            int total = 0;
            var list = bll.GetValueProductRelationListByCondition(valueid, pi, defaultPageSize, out total);

            var pagedList = new StaticPagedList<v_value_product_relation>(list, pi, defaultPageSize, total);

            ViewData[setCfgInstance.TOTAL_ITEM_VIEWDATA_KEY] = total;
            TempData["vid"] = valueid;

            return View(pagedList);
        }
    }
}
