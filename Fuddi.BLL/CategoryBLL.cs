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

        public IList<OD_Category> GetAllCategory()
        {
            return dal.GetAllCategory();
        }

        public IList<OD_Category> GetCategoryByGroupID(int groupid)
        {
            return dal.GetCategoryByGroupID(groupid);
        }

        public IList<CategoryGroupRelationModel> GetAllCategoryGroupRelationView()
        {
            return dal.GetAllCategoryGroupRelationView();
        }

        public OD_Category GetCategoryByID(int id)
        {
            return dal.GetCategoryByID(id);
        }

        public int AddCategory(OD_Category model)
        {
            return dal.AddCategory(model);
        }

        public int UpdateCategory(OD_Category model)
        {
            return dal.UpdateCategory(model);
        }

        public int DeleteCategory(int id)
        {
            return dal.DeleteCategory(id);
        }
        public IList<OD_Category> GetCategoryListByCondition(string name, int pageIndex, int pageSize, out int total)
        {
            return dal.GetCategoryListByCondition(name, pageIndex, pageSize, out total);
        }

        public IList<OD_CategoryGroup> GetCategoryGroupByCategoryID(int id)
        {
            return dal.GetCategoryGroupByCategoryID(id);
        }

        public IList<OD_CategoryGroup> GetAllCategoryGroup()
        {
            return dal.GetAllCategoryGroup();
        }

        public int AddCategoryGroup(OD_CategoryGroup model)
        {
            return dal.AddCategoryGroup(model);
        }

        public int UpdateCategoryGroup(OD_CategoryGroup model)
        {
            return dal.UpdateCategoryGroup(model);
        }

        public int DeleteCategoryGroup(int gid)
        {
            return dal.DeleteCategoryGroup(gid);
        }

        public int DeleteCategoryGroupByCategoryID(int id)
        {
            return dal.DeleteCategoryGroupByCategoryID(id);
        }

        public int AddCategoryGroupRelation(OD_CategoryGroupRelation model)
        {
            return dal.AddCategoryGroupRelation(model);
        }

        public int AddMultipleCategoryGroupRelation(IList<int> gids, int cid)
        {
            return dal.AddMultipleCategoryGroupRelation(gids, cid);
        }

    }
}
