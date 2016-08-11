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
        public IList<OD_CategoryGroup> GetAllCategoryGroup()
        {
            var list = entityInstance.OD_CategoryGroup.Where(m => !m.DelFlag).ToList();
            return list;
        }

        //public IList<OD_CategoryGroupRelation> GetAllCategoryGroupRelation()
        //{
        //    var list = entityInstance.OD_CategoryGroupRelation.ToList();
        //    return list;
        //}

        public IList<OD_Category> GetAllCategory()
        {
            var list = entityInstance.OD_Category.Where(m => !m.DelFlag).OrderByDescending(m => m.ID).ToList();
            return list;
        }

        public IList<OD_Category> GetCategoryByGroupID(int groupid)
        {
            var list = from a in entityInstance.OD_CategoryGroupRelation
                       join b in entityInstance.OD_Category on a.CategoryID equals b.ID
                       where a.GroupID.Equals(groupid) && !b.DelFlag
                       select b;
            return list.ToList();
        }

        public IList<CategoryGroupRelationModel> GetAllCategoryGroupRelationView()
        {
            var list = entityInstance.v_category_group_relation.Select(m => new CategoryGroupRelationModel() { GroupID = m.GroupID, GroupName = m.GroupName, CategoryID = (int)m.CategoryID, CategoryName = m.CategoryName }).ToList();
            return list;
        }
    }
}
