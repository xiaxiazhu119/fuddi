using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Fuddi.Configuration
{
    public class CMSSiteMapCfg : BaseSiteMapCfg
    {
        SettingsCfg _setCfgInstance = SettingsCfg.Instance;

        static CMSSiteMapCfg _instance;
        public static CMSSiteMapCfg Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CMSSiteMapCfg();
                return _instance;
            }
        }

        public CMSSiteMapCfg()
        {
            GetSiteMapConfig();
        }

        private void GetSiteMapConfig()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(System.Web.HttpContext.Current.Server.MapPath(_setCfgInstance.CMS_SITEMAP_CONFIG_FILE_PATH));
        }
    }

}
