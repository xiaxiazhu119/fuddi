using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using Fuddi.Models;
using Fuddi.BLL;
using Fuddi.Enum;
using X.Common;
using PagedList;

namespace Fuddi.Ctrls.Mall
{
    public class ProductController : MallBaseController
    {
        public ActionResult List(int? cid, string kw, int? s, int? o, int? pageIndex)
        {
            int _cid = TypeConverter.ObjectToInt(cid, defaultIntValue);
            TempData["cid"] = _cid;

            kw = !string.IsNullOrEmpty(kw) ? kw : "";
            string keyword = !string.IsNullOrEmpty(kw) ? HttpUtility.UrlDecode(kw) : "";
            TempData["keyword"] = keyword;
            TempData["kw"] = kw;

            int _se = TypeConverter.ObjectToInt(s, (int)SortEnum.Popular);
            int _oe = TypeConverter.ObjectToInt(s, (int)OrderByEnum.DESC);
            SortEnum se = (SortEnum)_se;
            OrderByEnum oe = (OrderByEnum)_oe;
            TempData["se"] = _se;
            TempData["oe"] = _oe;

            int pi = TypeConverter.ObjectToInt(pageIndex, defaultPageIndex);
            ViewData[setCfgInstance.PAGE_INDEX_VIEWDATA_KEY] = pi;

            int total = 0;

            ProductSearchConditionModel sc = new ProductSearchConditionModel();
            sc.Keyword = keyword;
            sc.CategoryID = _cid;
            ProductBLL bll = new ProductBLL();
            var list = bll.GetProductListByCondition(sc, se, oe, pi, defaultPageSize, out total);
            var pagedList = new StaticPagedList<od_v_term>(list, pi, defaultPageSize, total);

            ViewData[setCfgInstance.TOTAL_ITEM_VIEWDATA_KEY] = total;

            return View(pagedList);
        }
        public ActionResult Detail(int? pid)
        {
            return View();
        }
    }
}
