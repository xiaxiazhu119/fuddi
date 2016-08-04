using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Configuration
{
    public class SettingsCfg : Config
    {
        public readonly int DEFAULT_EXPIRES_TIME = 43200;
        public readonly string COOKIE_NAME = "fuddi.onedream";
        public readonly string FILE_EXT_COMPARE_FIX = ",";
        public readonly string IMG_FILE_EXT_WITH_FIX = ",.gif,.jpg,.jpeg,.png,.bmp,";

    }
}
