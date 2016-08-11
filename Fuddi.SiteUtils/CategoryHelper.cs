using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.BLL;
using Fuddi.Models;

namespace Fuddi.SiteUtils
{
    public class CategoryHelper
    {
        static CategoryHelper _instance;
        public static CategoryHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoryHelper();
                return _instance;
            }
        }

        public IList<OD_CategoryGroup> GetAllCategoryGroup()
        {
            return CacheHelper.Instance.CategoryGroup;
        }

        public IList<CategoryGroupRelationModel> GetCategoryByGroupID(int groupid)
        {
            var reation = CacheHelper.Instance.CategoryGroupRelation;
            var list = reation.Where(m => m.GroupID.Equals(groupid)).ToList();
            return list;
        }
    }
}
