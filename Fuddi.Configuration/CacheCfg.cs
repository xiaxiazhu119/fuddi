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

        public readonly string SESSION_MEMBER_KEY = "fuddi_onedream_session_member";
        public readonly string SESSION_MANAGER_KEY = "fuddi_onedream_session_manager";

        #endregion
    }
}
