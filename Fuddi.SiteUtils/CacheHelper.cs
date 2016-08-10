using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

using Fuddi.Configuration;
using Fuddi.Models;
using Fuddi.BLL;

namespace Fuddi.SiteUtils
{
    public class CacheHelper : BaseCache
    {
        static CacheHelper _instance;

        public static CacheHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CacheHelper();
                return _instance;
            }
        }

        public IList<CMSSiteMapModel> CMSSiteMapList
        {
            get
            {
                string key = CacheCfg.Instance.CMS_SITEMAP_CACHE_KEY;
                RemoveCacheValue(key);
                object cacheValue = GetCacheValue(key);
                if (cacheValue != null)
                    return (IList<CMSSiteMapModel>)cacheValue;

                IList<CMSSiteMapModel> sm = CMSSiteMapCfg.Instance.GetCMSSiteMap();
                SetCacheValue(key, sm);
                return sm;
            }
        }

        public IDictionary<int, IList<OD_Category>> CategoryGroup
        {
            get
            {
                string key = CacheCfg.Instance.CATEGORY_GROUP_CACHE_KEY;
                RemoveCacheValue(key);
                object cacheValue = GetCacheValue(key);
                if (cacheValue != null)
                    return (IDictionary<int, IList<OD_Category>>)cacheValue;

                IDictionary<int, IList<OD_Category>> tree = (new CategoryBLL()).GetCategoryGroup();
                SetCacheValue(key, tree);
                return tree;
            }
        }

        public IList<CategoryModel> CategoryTree
        {
            get
            {

                string key = CacheCfg.Instance.CATEGORY_TREE_CACHE_KEY;
                RemoveCacheValue(key);
                object cacheValue = GetCacheValue(key);
                if (cacheValue != null)
                    return (IList<CategoryModel>)cacheValue;


                var group = CategoryGroup;
                var minLv = group.Keys.Min();
                var maxLv = group.Keys.Max();
                var first = group[minLv];
                IList<CategoryModel> tree = new List<CategoryModel>();
                foreach (var a in first)
                {
                    CategoryModel b = new CategoryModel();
                    b.ID = a.ID;
                    b.ParentID = a.ParentID;
                    b.Name = a.Name;
                    b.Lv = a.Lv;
                    b.DelFlag = a.DelFlag;
                    b.AddTime = a.AddTime;
                    b.CategoryList = GetChildCategoryList(group, a, minLv, maxLv);
                    tree.Add(b);
                }

                SetCacheValue(key, tree);
                return tree;
            }
        }

        private IList<CategoryModel> GetChildCategoryList(IDictionary<int, IList<OD_Category>> group, OD_Category model, int minLv, int maxLv)
        {
            IList<CategoryModel> list = new List<CategoryModel>();
            if (model.Lv < maxLv)
            {
                list = (IList<CategoryModel>)group[model.Lv + 1].Where(m => m.ParentID.Equals(model.ID)).Select(m => new CategoryModel() { ID = m.ID, ParentID = m.ParentID, Name = m.Name, Lv = m.Lv, DelFlag = m.DelFlag, AddTime = m.AddTime }).OrderBy(m => m.ID).ToList();
                foreach (var c in list)
                {
                    c.CategoryList = GetChildCategoryList(group, c, minLv, maxLv);
                }
            }
            return list;
        }
    }
}
