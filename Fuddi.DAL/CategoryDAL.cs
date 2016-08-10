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
        public IList<OD_Category> GetCategoryList(int pageIndex, int pageSize, out int total)
        {
            var list = entityInstance.OD_Category.ToList();
            total = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return list;
        }

        public IDictionary<int, IList<OD_Category>> GetCategoryGroup()
        {
            var total = entityInstance.OD_Category.Where(m => !m.DelFlag).OrderBy(m => m.Lv).ThenBy(m => m.ID).ToList();
            int maxLv = total.Select(m => m.Lv).Max();

            IDictionary<int, IList<OD_Category>> group = new Dictionary<int, IList<OD_Category>>();

            for (int i = 0; i <= maxLv; i++)
            {
                var g = total.Where(m => m.Lv.Equals(i)).ToList();
                group.Add(i, g);
            }

            return group;
        }
    }
}
