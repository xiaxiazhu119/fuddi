using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuddi.Configuration
{
    public class Config
    {
        static Config _instance;

        public static Config GetInstace(ConfigEnum ce) {
            switch (ce)
            {
                case ConfigEnum.Description:
                    return new DescriptionCfg();
                default:
                    return new DescriptionCfg();
            }
        }

        public enum ConfigEnum
        { 
            Description
        }
    }
}
