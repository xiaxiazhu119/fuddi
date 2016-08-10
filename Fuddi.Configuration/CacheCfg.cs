using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Configuration
{
    public class CacheCfg : BaseConfig
    {

        static CacheCfg _instance;
        public static CacheCfg Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CacheCfg();
                return _instance;
            }
        }

        #region cookie

        public readonly string COOKIE_NAME = "fuddi.onedream";

        #endregion

        #region session

        public readonly string MEMBER_SESSION_KEY = "fuddi_onedream_session_member";
        public readonly string MANAGER_SESSION_KEY = "fuddi_onedream_session_manager";

        #endregion

        #region cache

        public readonly string CMS_SITEMAP_CACHE_KEY = "fuddi_onedream_cache_cms_sitemap";
        public readonly string CATEGORY_GROUP_CACHE_KEY = "fuddi_onedream_cache_category_group";
        public readonly string CATEGORY_TREE_CACHE_KEY = "fuddi_onedream_cache_category_tree";

        #endregion



    }
}
