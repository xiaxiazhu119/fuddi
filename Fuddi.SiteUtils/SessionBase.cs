using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Configuration;

namespace Fuddi.SiteUtils
{
    public class SessionBase
    {
        protected internal CacheCfg cacheCfgInstance = CacheCfg.Instance;

        static SessionHelper _instance;

        public static SessionHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionHelper();
                return _instance;
            }
        }
    }
}
