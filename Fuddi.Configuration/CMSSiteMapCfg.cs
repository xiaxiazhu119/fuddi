using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

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
            //GetCMSSiteMapConfig();
        }

        public IList<CMSSiteMapModel> GetCMSSiteMap()
        {
            IList<CMSSiteMapModel> sm = new List<CMSSiteMapModel>();
            string cfgFilePath = System.Web.HttpContext.Current.Server.MapPath(_setCfgInstance.CMS_SITEMAP_CONFIG_FILE_PATH);
            try
            {
                using (StreamReader sr = new StreamReader(cfgFilePath, Encoding.UTF8))
                {
                    string content = sr.ReadToEnd().Replace("\r\n", "");
                    //sr.Close();
                    //sr.Dispose();
                    using (JsonReader jr = new JsonTextReader(new StringReader(content)))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        sm = (IList<CMSSiteMapModel>)serializer.Deserialize(jr, typeof(IList<CMSSiteMapModel>));
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return sm;
        }
    }

}
