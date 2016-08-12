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
        /// 根据组ID获取类别列表
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public IList<OD_Category> GetCategoryByGroupID(int groupid)
        {
            return dal.GetCategoryByGroupID(groupid);
        }

        /// <summary>
        /// 获取组与类别列表（从视图）
        /// </summary>
        /// <returns></returns>
        public IList<CategoryGroupRelationModel> GetAllCategoryGroupRelationView()
        {
            return dal.GetAllCategoryGroupRelationView();
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

        /// <summary>
        /// 根据类别ID获取所属组列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<OD_CategoryGroup> GetCategoryGroupByCategoryID(int id)
        {
            return dal.GetCategoryGroupByCategoryID(id);
        }

        /// <summary>
        /// 获取所有类别组
        /// </summary>
        /// <returns></returns>
        public IList<OD_CategoryGroup> GetAllCategoryGroup()
        {
            return dal.GetAllCategoryGroup();
        }

        /// <summary>
        /// 添加类别组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategoryGroup(OD_CategoryGroup model)
        {
            model.DelFlag = false;
            model.CreateTime = DateTime.Now;
            return dal.AddCategoryGroup(model);
        }

        /// <summary>
        /// 更新类别组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCategoryGroup(OD_CategoryGroup model)
        {
            return dal.UpdateCategoryGroup(model);
        }

        /// <summary>
        /// 删除类别组
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public int DeleteCategoryGroup(int gid)
        {
            return dal.DeleteCategoryGroup(gid);
        }

        /// <summary>
        /// 根据类别ID删除所属组关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCategoryGroupByCategoryID(int id)
        {
            return dal.DeleteCategoryGroupByCategoryID(id);
        }

        /// <summary>
        /// 根据条件获取类别组列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<OD_CategoryGroup> GetCategoryGroupListByCondition(string name, int pageIndex, int pageSize, out int total)
        {
            return dal.GetCategoryGroupListByCondition(name, pageIndex, pageSize, out total);
        }

        /// <summary>
        /// 添加类别与组关联
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategoryGroupRelation(OD_CategoryGroupRelation model)
        {
            return dal.AddCategoryGroupRelation(model);
        }

        /// <summary>
        /// 添加类别与多个组关联
        /// </summary>
        /// <param name="gids"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int AddMultipleCategoryGroupRelation(IList<int> gids, int cid)
        {
            return dal.AddMultipleCategoryGroupRelation(gids, cid);
        }

    }
}
