using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Models;
using Fuddi.BLL;
using Fuddi.Enum;
using Fuddi.SiteUtils;

namespace Fuddi.Ctrls.CMS
{
    public class ApiController : CMSBaseController
    {
        #region category & group

        public JsonResult EditCategory(int gid, int id, string name)
        {
            OD_Category model = new OD_Category();
            model.Name = name;
            int rst = 0;
            ResponseEnum rsp;

            CategoryBLL bll = new CategoryBLL();
            if (id == 0)
            {
                rst = bll.AddCategory(model);

                rsp = rst > 0 ? ResponseEnum.AddCategorySuccess : ResponseEnum.AddCategoryFailed;
            }
            else
            {
                model.ID = id;
                rst = bll.UpdateCategory(model);
                rsp = rst > 0 ? ResponseEnum.UpdateCategorySuccess : ResponseEnum.UpdateCategoryFailed;
            }
            return BuildJsonResult(rsp);
        }

        public JsonResult DeleteCategory(int id)
        {
            int rst = (new CategoryBLL()).DeleteCategory(id);
            ResponseEnum rsp = rst > 0 ? ResponseEnum.DeleteCategorySuccess : ResponseEnum.DeleteCategoryFailed;
            return BuildJsonResult(rsp);
        }

        public JsonResult ClearCategoryCache()
        {
            CacheHelper.Instance.ClearCategoryCache();
            return BuildJsonResult(ResponseEnum.OperationSuccess);
        }

        #endregion
    }
}
