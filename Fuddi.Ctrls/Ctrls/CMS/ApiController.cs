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
        public JsonResult EditCategory(int gid, int id, string name)
        {
            OD_Category model = new OD_Category();
            model.Name = name;
            int rst = 0;
            ResponseEnum rsp;

            CategoryBLL bll = new CategoryBLL();
            if (id == 0)
            {
                model.ParentID = 0;
                model.Lv = 0;
                model.DelFlag = false;
                model.CreateTime = DateTime.Now;
                rst = bll.AddCategory(model);
                if (rst > 0)
                {
                    OD_CategoryGroupRelation gr = new OD_CategoryGroupRelation();
                    gr.GroupID = gid;
                    gr.CategoryID = rst;
                    rst = bll.AddCategoryGroupRelation(gr);
                }

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

        public JsonResult EditCategoryGroup(int id, string name)
        {
            OD_CategoryGroup model = new OD_CategoryGroup();
            model.Name = name;
            int rst = 0;
            ResponseEnum rsp;
            CategoryBLL bll = new CategoryBLL();

            if (id == 0)
            {
                model.DelFlag = false;
                model.CreateTime = DateTime.Now;
                rst = bll.AddCategoryGroup(model);
                rsp = rst > 0 ? ResponseEnum.AddCategoryGroupSuccess : ResponseEnum.AddCategoryGroupFailed;
            }
            else
            {
                model.ID = id;
                rst = bll.UpdateCategoryGroup(model);
                rsp = rst > 0 ? ResponseEnum.UpdateCategoryGroupSuccess : ResponseEnum.UpdateCategoryGroupFailed;
            }
            return BuildJsonResult(rsp);
        }

        public JsonResult DeleteCategory(int id)
        {
            int rst = (new CategoryBLL()).DeleteCategory(id);
            ResponseEnum rsp = rst > 0 ? ResponseEnum.DeleteCategorySuccess : ResponseEnum.DeleteCategoryFailed;
            return BuildJsonResult(rsp);
        }

        public JsonResult DeleteCategoryGroup(int id)
        {
            int rst = (new CategoryBLL()).DeleteCategoryGroup(id);
            ResponseEnum rsp = rst > 0 ? ResponseEnum.DeleteCategoryGroupSuccess : ResponseEnum.DeleteCategoryGroupFailed;
            return BuildJsonResult(rsp);
        }

        public JsonResult ClearCategoryCache()
        {
            CategoryHelper.Instance.ClearCategoryCache();
            return BuildJsonResult(ResponseEnum.OperationSuccess);
        }
    }
}
