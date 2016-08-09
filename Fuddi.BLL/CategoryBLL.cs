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

        public IList<OD_Category> GetCategoryList(int pageIndex, int pageSize, out int total)
        {
            return dal.GetCategoryList(pageIndex, pageSize, out total);
        }
    }
}
