﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fuddi.Configuration;
using X.Common;

namespace Fuddi.SiteUtils
{
    public class SiteUtil
    {
        static SiteUtil _instance;

        public static SiteUtil Instace
        {
            get {
                if (_instance == null)
                    _instance = new SiteUtil();
                return _instance;
            }
        }

        SettingsCfg _setCfgInstance = (SettingsCfg)Config.GetInstace(Config.ConfigEnum.Settings);

        public string GetTimeStampRandom()
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string randomStamp = "";
            Random ran = new Random();
            int i = ran.Next(0, 9999);
            randomStamp = i.ToString().PadLeft(4, '0');
            return timeStamp + randomStamp;
        }

        public bool VerifyImgFileExt(string fileExt)
        {
            return VerifyFileExt(fileExt, _setCfgInstance.IMG_FILE_EXT_WITH_FIX);
        }

        public bool VerifyFileExt(string fileExt, string compareExt)
        {
            fileExt = _setCfgInstance.FILE_EXT_COMPARE_FIX + fileExt.ToLower() + _setCfgInstance.FILE_EXT_COMPARE_FIX;
            return compareExt.IndexOf(fileExt) != -1;
        }

        public void WriteCookie(string key, string value)
        {
            WriteCookie(key, value, _setCfgInstance.DEFAULT_EXPIRES_TIME);
        }

        public void WriteCookie(string key, string value, int expires)
        {
            Utils.WriteCookie(_setCfgInstance.COOKIE_NAME, key, value, expires);
        }

        public string GetCookie(string key)
        {
            return Utils.GetCookie(_setCfgInstance.COOKIE_NAME, key);
        }
    }
}
