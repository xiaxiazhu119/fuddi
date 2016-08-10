using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Fuddi.Models;

namespace Fuddi.SiteUtils
{
    public class SessionHelper : BaseSession
    {
        #region manager
        public OD_Manager SessionManager
        {
            get
            {
                string _key = cacheCfgInstance.MANAGER_SESSION_KEY;

                if (HttpContext.Current.Session != null && HttpContext.Current.Session[_key] != null)
                    return (OD_Manager)HttpContext.Current.Session[_key];
                return null;

            }
            private set
            {
                HttpContext.Current.Session[cacheCfgInstance.MANAGER_SESSION_KEY] = value;
            }
        }

        public void SetSessionManager(OD_Manager model)
        {
            SetSessionManager(model, false);
        }

        public void SetSessionManager(OD_Manager model, bool useCookie)
        {
            SessionManager = model;
            //if (useCookie)
            //{
            //    SiteUtil.WriteCookie(SiteConfiguration.Manager_ID_COOKIE_KEY_NAME, model.ID.ToString(), SiteConfiguration.DEFAULT_EXPIRES_TIME);
            //    SiteUtil.WriteCookie(SiteConfiguration.Manager_USERNAME_COOKIE_KEY_NAME, model.UserName, SiteConfiguration.DEFAULT_EXPIRES_TIME);
            //    if (model.ManagerInfo != null)
            //        SiteUtil.WriteCookie(SiteConfiguration.Manager_NAME_COOKIE_KEY_NAME, model.ManagerInfo.Name, SiteConfiguration.DEFAULT_EXPIRES_TIME);
            //}
            //else
            //{
            //    SiteUtil.WriteCookie(SiteConfiguration.Manager_ID_COOKIE_KEY_NAME, model.ID.ToString());
            //    SiteUtil.WriteCookie(SiteConfiguration.Manager_USERNAME_COOKIE_KEY_NAME, model.UserName);
            //    if (model.ManagerInfo != null)
            //        SiteUtil.WriteCookie(SiteConfiguration.Manager_NAME_COOKIE_KEY_NAME, model.ManagerInfo.Name);
            //}
        }

        public void ClearSessionManager()
        {
            SessionManager = null;
            //SiteUtil.WriteCookie(SiteConfiguration.Manager_ID_COOKIE_KEY_NAME, "");
            //SiteUtil.WriteCookie(SiteConfiguration.Manager_USERNAME_COOKIE_KEY_NAME, "");
            //SiteUtil.WriteCookie(SiteConfiguration.Manager_NAME_COOKIE_KEY_NAME, "");
        }

        public bool ManagerExist()
        {
            return SessionManager != null;
        }

        #endregion
    }
}
