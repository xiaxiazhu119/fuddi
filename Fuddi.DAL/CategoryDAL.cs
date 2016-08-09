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
    }
}
