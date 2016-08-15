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

        #endregion

        #region value type

        public JsonResult EditValueType(int id, string name, decimal value)
        {
            OD_ValueType model = new OD_ValueType();
            model.Name = name;
            model.Value = value;
            int rst = 0;
            ResponseEnum rsp;

            ValueBLL bll = new ValueBLL();
            if (id == 0)
            {
                rst = bll.AddValueType(model);
                rsp = rst > 0 ? ResponseEnum.AddValueTypeSuccess : ResponseEnum.AddValueTypeFailed;
            }
            else
            {
                model.ID = id;
                rst = bll.UpdateValueType(model);
                rsp = rst > 0 ? ResponseEnum.UpdateValueTypeSuccess : ResponseEnum.UpdateValueTypeFailed;
            }
            return BuildJsonResult(rsp);
        }

        public JsonResult DeleteValueType(int id)
        {
            int rst = (new ValueBLL()).DeleteValueType(id);
            ResponseEnum rsp = rst > 0 ? ResponseEnum.DeleteValueTypeSuccess : ResponseEnum.DeleteValueTypeFailed;
            return BuildJsonResult(rsp);
        }

        #endregion
    }
}
