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

        public int AddCategory(OD_Category model)
        {
            entityInstance.OD_Category.Add(model);
            entityInstance.SaveChanges();
            return model.ID;
        }

        public int UpdateCategory(OD_Category model)
        {
            var a = entityInstance.OD_Category.First(m => m.ID.Equals(model.ID));
            a.Name = model.Name;
            int rst = entityInstance.SaveChanges();
            return rst;
        }

        public int DeleteCategory(int id)
        {
            var a = entityInstance.OD_Category.First(m => m.ID.Equals(id));
            a.DelFlag = true;
            int rst = entityInstance.SaveChanges();
            if (rst > 0)
            {
                entityInstance.OD_CategoryGroupRelation.RemoveRange(entityInstance.OD_CategoryGroupRelation.Where(m => m.CategoryID.Equals(id)));
                rst += entityInstance.SaveChanges();
            }
            return rst;
        }

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

        public int AddCategoryGroup(OD_CategoryGroup model)
        {
            entityInstance.OD_CategoryGroup.Add(model);
            entityInstance.SaveChanges();
            return model.ID;
        }

        public int UpdateCategoryGroup(OD_CategoryGroup model)
        {
            var a = entityInstance.OD_CategoryGroup.First(m => m.ID.Equals(model.ID));
            a.Name = model.Name;
            int rst = entityInstance.SaveChanges();
            return rst;
        }

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

        public int AddCategoryGroupRelation(OD_CategoryGroupRelation model)
        {
            entityInstance.OD_CategoryGroupRelation.Add(model);
            entityInstance.SaveChanges();
            return model.ID;
        }
    }
}
