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

        public ActionResult CategoryList(string name)
        {
            /*
            int pi = TypeConverter.ObjectToInt(pageIndex, defaultPageIndex);
            ViewData[setCfgInstance.PAGE_INDEX_VIEWDATA_KEY] = pi;
            int total = 0;
            name = string.IsNullOrEmpty(name) ? "" : Utils.UrlDecode(name);
            var list = bll.GetCategoryListByCondition(name, pi, defaultPageSize, out total);

            var pagedList = new StaticPagedList<OD_Category>(list, pi, defaultPageSize, total);

            ViewData[setCfgInstance.TOTAL_ITEM_VIEWDATA_KEY] = total;
             * */
            var list = CacheHelper.Instance.CategoryList;
            if (!string.IsNullOrEmpty(name))
                list = list.Where(m => m.Name.Contains(name)).ToList();
            TempData["name"] = name;

            return View(list);
        }

        public ActionResult CategoryEdit(int? act, int? id, string redirect)
        {
            string r = HttpUtility.UrlDecode(redirect);
            OD_Category m = new OD_Category();
            if (act != null)
            {
                if (ActionEnum.Edit == (ActionEnum)((int)act))
                {
                    if (id == null)
                        return Redirect(r);

                    m = bll.GetCategoryByID((int)id);
                    if (m == null)
                        return Redirect(r);
                }
            }
            TempData[setCfgInstance.REDIRECT_TEMPDATA_KEY] = r;
            return View(m);
        }

        [HttpPost]
        public ActionResult CategoryEdit(int act, OD_Category m, string gs, string redirect)
        {
            int rst = 0;
            if (ActionEnum.Edit == (ActionEnum)((int)act))
            {
                rst = bll.UpdateCategory(m);
            }
            else
            {
                rst = bll.AddCategory(m);
                m.ID = rst;
            }
            TempData[setCfgInstance.REDIRECT_TEMPDATA_KEY] = redirect;
            TempData[setCfgInstance.RESPONSE_MSG_TEMPDATA_KEY] = rst > 0 ? ResponseEnum.UpdateCategorySuccess : ResponseEnum.UpdateCategoryFailed;
            TempData[setCfgInstance.RESPONSE_CODE_TEMPDATA_KEY] = rst;

            CacheHelper.Instance.ClearCategoryCache();

            return View(m);
        }
    }
}
