using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Configuration
{
    public class SettingsCfg : BaseConfig
    {

        static SettingsCfg _instance;
        public static SettingsCfg Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingsCfg();
                return _instance;
            }
        }

        private const string _cms_signin = "/_cms/home/signin";
        private const string _cms_default = "/_cms/home/default";

        public readonly int DEFAULT_EXPIRES_TIME = 43200;
        public readonly string FILE_EXT_COMPARE_FIX = ",";
        public readonly string IMG_FILE_EXT_WITH_FIX = ",.gif,.jpg,.jpeg,.png,.bmp,";
        public readonly string CMS_SIGNIN = _cms_signin;
        public readonly string CMS_DEFAULT = _cms_default;
        public readonly string[] NEEDLESS_AUTHORIZATION_PATH = new string[]{
            _cms_signin
        };

        public readonly int DEFAULT_PAGE_INDEX = 1;
        public readonly int DEFAULT_PAGE_SIZE = 10;

        public readonly string RESPONSE_TEMPDATA_KEY = "td_rsp";
        public readonly string REDIRECT_TEMPDATA_KEY = "td_redirect";
        public readonly string CMS_SITEMAP_CONFIG_FILE_PATH = "/sitemap/cms-sitemap.config";
        public readonly string CURRENT_PAGE_MODULE_VIEWDATA_KEY = "vd_current_page_module";
        public readonly string CURRENT_QUERY_AND_PATH_VIEWDATA_KEY = "vd_current_query_and_path";
        public readonly string URL_ENCODE_CURRENT_QUERY_AND_PATH_VIEWDATA_KEY = "vd_url_encode_current_query_and_path";
        public readonly string PAGE_INDEX_VIEWDATA_KEY = "vd_page_index";
        public readonly string DATA_LIST_VIEWDATA_KEY = "vd_data_list";
        public readonly string PAGED_LIST_VIEWDATA_KEY = "vd_paged_list";
        public readonly string TOTAL_ITEM_VIEWDATA_KEY = "vd_total_item";

    }
}
