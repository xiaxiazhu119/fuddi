using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.DAL;
using Fuddi.Models;

namespace Fuddi.BLL
{
    public class CategoryBLL
    {
        CategoryDAL dal;
        public CategoryBLL()
        {
            dal = new CategoryDAL();
        }

        //public IList<OD_CategoryGroupRelation> GetAllCategoryGroupRelation()
        //{
        //    return dal.GetAllCategoryGroupRelation();
        //}

        /// <summary>
        /// 获取所有类别
        /// </summary>
        /// <returns></returns>
        public IList<OD_Category> GetAllCategory()
        {
            return dal.GetAllCategory();
        }

        /// <summary>
        /// 根据ID获取类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OD_Category GetCategoryByID(int id)
        {
            return dal.GetCategoryByID(id);
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategory(OD_Category model)
        {
            model.ParentID = 0;
            model.Lv = 0;
            model.DelFlag = false;
            model.CreateTime = DateTime.Now;
            return dal.AddCategory(model);
        }

        /// <summary>
        /// 更新类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCategory(OD_Category model)
        {
            return dal.UpdateCategory(model);
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCategory(int id)
        {
            return dal.DeleteCategory(id);
        }

        /// <summary>
        /// 根据条件获取类别列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<OD_Category> GetCategoryListByCondition(string name, int pageIndex, int pageSize, out int total)
        {
            return dal.GetCategoryListByCondition(name, pageIndex, pageSize, out total);
        }

    }
}
