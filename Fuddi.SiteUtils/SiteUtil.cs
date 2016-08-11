using System;
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

        public static SiteUtil Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SiteUtil();
                return _instance;
            }
        }

        SettingsCfg _setCfgInstance = SettingsCfg.Instance;
        CacheCfg _cacheCfgInstance = CacheCfg.Instance;

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

        #region cookies

        public void WriteCookie(string key, string value)
        {
            WriteCookie(key, value, _setCfgInstance.DEFAULT_EXPIRES_TIME);
        }

        public void WriteCookie(string key, string value, int expires)
        {
            Utils.WriteCookie(_cacheCfgInstance.COOKIE_NAME, key, value, expires);
        }

        public string GetCookie(string key)
        {
            return Utils.GetCookie(_cacheCfgInstance.COOKIE_NAME, key);
        }

        #endregion

        public bool CheckAuthorization()
        {
            string currentPath = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            /*
            bool needAuthorization = true;
            foreach (var path in _setCfgInstance.NEEDLESS_AUTHORIZATION_PATH)
            {
                if (currentPath.IndexOf(path) != -1)
                {
                    needAuthorization = false;
                    break;
                }
            }
             * */
            bool needAuthorization = _setCfgInstance.NEEDLESS_AUTHORIZATION_PATH.Count(path => currentPath.IndexOf(path) != -1) == 0;
            return needAuthorization;
        }

        public CMSSiteMapModel GetCMSPageModuleInfo()
        {
            return GetCMSPageModuleInfo(System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToLower());
        }

        public CMSSiteMapModel GetCMSPageModuleInfo(string url)
        {

            var sm = CacheHelper.Instance.CMSSiteMapList.FirstOrDefault(m => url.IndexOf(m.Action) != -1);
            if (sm == null || url.IndexOf("/_cms/api/") != -1)
                sm = new CMSSiteMapModel();

            if (sm.Views != null && sm.Views.Count > 0)
            {
                var currentView = sm.Views.FirstOrDefault(m => url.IndexOf(m.Action) != -1);
                sm.CurrentView = currentView;
            }
            return sm;
        }

        public string GetCurrentQueryAndPath()
        {
            return System.Web.HttpContext.Current.Request.Url.PathAndQuery.ToLower();
        }

        public string GetUrlEncodeCurrentQueryAndPath()
        {
            return System.Web.HttpUtility.UrlEncode(GetCurrentQueryAndPath());
        }
    }
}
