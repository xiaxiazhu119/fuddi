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

        public IList<OD_CategoryGroup> GetAllCategoryGroup()
        {
            return dal.GetAllCategoryGroup();
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

    }
}
