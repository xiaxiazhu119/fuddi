using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Models;
using Fuddi.Enum;

namespace Fuddi.DAL
{
    public class CategoryDAL : BaseDAL
    {

        //public IList<OD_CategoryGroupRelation> GetAllCategoryGroupRelation()
        //{
        //    var list = entityInstance.OD_CategoryGroupRelation.ToList();
        //    return list;
        //}

        /// <summary>
        /// 获取所有类别
        /// </summary>
        /// <returns></returns>
        public IList<OD_Category> GetAllCategory()
        {
            var list = entityInstance.OD_Category.Where(m => !m.DelFlag).OrderByDescending(m => m.ID).ToList();
            return list;
        }

        /// <summary>
        /// 根据组ID获取类别列表
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public IList<OD_Category> GetCategoryByGroupID(int groupid)
        {
            var list = from a in entityInstance.OD_CategoryGroupRelation
                       join b in entityInstance.OD_Category on a.CategoryID equals b.ID
                       where a.GroupID.Equals(groupid) && !b.DelFlag
                       select b;
            return list.ToList();
        }

        /// <summary>
        /// 获取组与类别列表（从视图）
        /// </summary>
        /// <returns></returns>
        public IList<CategoryGroupRelationModel> GetAllCategoryGroupRelationView()
        {
            var list = entityInstance.v_category_group_relation.Select(m => new CategoryGroupRelationModel() { GroupID = m.GroupID, GroupName = m.GroupName, CategoryID = (int)m.CategoryID, CategoryName = m.CategoryName }).ToList();
            return list;
        }

        /// <summary>
        /// 根据ID获取类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OD_Category GetCategoryByID(int id)
        {
            var a = entityInstance.OD_Category.FirstOrDefault(m => m.ID.Equals(id) && !m.DelFlag);
            return a;
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategory(OD_Category model)
        {
            entityInstance.OD_Category.Add(model);
            entityInstance.SaveChanges();
            return model.ID;
        }

        /// <summary>
        /// 更新类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCategory(OD_Category model)
        {
            var a = entityInstance.OD_Category.First(m => m.ID.Equals(model.ID));
            a.Name = model.Name;
            int rst = entityInstance.SaveChanges();
            return rst;
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCategory(int id)
        {
            var a = entityInstance.OD_Category.First(m => m.ID.Equals(id));
            a.DelFlag = true;
            int rst = entityInstance.SaveChanges();
            if (rst > 0)
            {
                rst += DeleteCategoryGroupByCategoryID(id);
            }
            return rst;
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
            var entity = entityInstance.OD_Category.Where(m => !m.DelFlag);
            if (!string.IsNullOrEmpty(name))
            {
                entity = entity.Where(m => m.Name.Contains(name));
            }
            total = entity.Count();
            if (total > 0)
            {
                entity = entity.OrderByDescending(m => m.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return entity.ToList();
        }

        /// <summary>
        /// 根据类别ID获取所属组列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<OD_CategoryGroup> GetCategoryGroupByCategoryID(int id)
        {
            var list = from a in entityInstance.OD_CategoryGroup
                       join b in entityInstance.OD_CategoryGroupRelation on a.ID equals b.GroupID
                       where !a.DelFlag && b.CategoryID.Equals(id)
                       select a;
            return list.ToList();
        }

        /// <summary>
        /// 获取所有类别组
        /// </summary>
        /// <returns></returns>
        public IList<OD_CategoryGroup> GetAllCategoryGroup()
        {
            var list = entityInstance.OD_CategoryGroup.Where(m => !m.DelFlag).ToList();
            return list;
        }

        /// <summary>
        /// 添加类别组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategoryGroup(OD_CategoryGroup model)
        {
            entityInstance.OD_CategoryGroup.Add(model);
            entityInstance.SaveChanges();
            return model.ID;
        }

        /// <summary>
        /// 更新类别组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCategoryGroup(OD_CategoryGroup model)
        {
            var a = entityInstance.OD_CategoryGroup.First(m => m.ID.Equals(model.ID));
            a.Name = model.Name;
            int rst = entityInstance.SaveChanges();
            return rst;
        }

        /// <summary>
        /// 删除类别组
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public int DeleteCategoryGroup(int gid)
        {
            var a = entityInstance.OD_CategoryGroup.First(m => m.ID.Equals(gid));
            a.DelFlag = true;
            int rst = entityInstance.SaveChanges();
            if (rst > 0)
            {
                entityInstance.OD_CategoryGroupRelation.RemoveRange(entityInstance.OD_CategoryGroupRelation.Where(m => m.GroupID.Equals(gid)));
                rst += entityInstance.SaveChanges();
            }
            return rst;
        }

        /// <summary>
        /// 根据类别ID删除所属组关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCategoryGroupByCategoryID(int id)
        {
            int rst = 0;
            entityInstance.OD_CategoryGroupRelation.RemoveRange(entityInstance.OD_CategoryGroupRelation.Where(m => m.CategoryID.Equals(id)));
            rst = entityInstance.SaveChanges();
            return rst;
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
            var entity = entityInstance.OD_CategoryGroup.Where(m => !m.DelFlag);
            if (!string.IsNullOrEmpty(name))
            {
                entity = entity.Where(m => m.Name.Contains(name));
            }
            total = entity.Count();
            if (total > 0)
            {
                entity = entity.OrderByDescending(m => m.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return entity.ToList();
        }

        /// <summary>
        /// 添加类别与组关联
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCategoryGroupRelation(OD_CategoryGroupRelation model)
        {
            entityInstance.OD_CategoryGroupRelation.Add(model);
            entityInstance.SaveChanges();
            return model.ID;
        }

        /// <summary>
        /// 添加类别与多个组关联
        /// </summary>
        /// <param name="gids"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int AddMultipleCategoryGroupRelation(IList<int> gids, int cid)
        {
            entityInstance.Configuration.AutoDetectChangesEnabled = false;
            entityInstance.Configuration.ValidateOnSaveEnabled = false;
            OD_CategoryGroupRelation r;
            int rst = 0;
            rst += DeleteCategoryGroupByCategoryID(cid);
            foreach (int gid in gids)
            {
                r = new OD_CategoryGroupRelation();
                r.GroupID = gid;
                r.CategoryID = cid;
                entityInstance.OD_CategoryGroupRelation.Add(r);
            }
            rst = entityInstance.SaveChanges();
            entityInstance.Configuration.AutoDetectChangesEnabled = true;
            entityInstance.Configuration.ValidateOnSaveEnabled = true;
            return rst;
        }

    }
}
