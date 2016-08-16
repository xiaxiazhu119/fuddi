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

    }
}
