using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

using Fuddi.Configuration;

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
                string key = CacheCfg.Instance.CACHE_CMS_SITEMAP_KEY;
                RemoveCacheValue(key);
                object cacheValue = GetCacheValue(key);
                if (cacheValue != null)
                    return (IList<CMSSiteMapModel>)cacheValue;

                IList<CMSSiteMapModel> sm = CMSSiteMapCfg.Instance.GetCMSSiteMap();
                SetCacheValue(key, sm);
                return sm;
            }
        }
    }
}
