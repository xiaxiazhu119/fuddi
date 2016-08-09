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
        public readonly string[] NEED_AUTHORIZATION_PATH = new string[]{
            _cms_default
        };
        public readonly string RESPONSE_TEMPDATA_KEY = "rsp";
        public readonly string CMS_SITEMAP_CONFIG_FILE_PATH = "/sitemap/cms-sitemap.config";
        public readonly string PAGE_TITLE_VIEWDATA_KEY = "vd_page_title";


    }
}
