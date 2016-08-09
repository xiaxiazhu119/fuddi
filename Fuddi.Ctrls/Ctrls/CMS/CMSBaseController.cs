using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Fuddi.Models;
using Fuddi.SiteUtils;
using Fuddi.Configuration;

namespace Fuddi.Ctrls.CMS
{
    public class CMSBaseController : BaseController
    {
        public IList<CMSSiteMapModel> siteMap = CacheHelper.Instance.CMSSiteMapList;
        protected internal CMSSiteMapModel currentModule = new CMSSiteMapModel();
        
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            bool needAuthorization = SiteUtil.Instance.CheckAuthorization();
            if (needAuthorization)
            {
                OD_Manager m = sessionHelperInstance.SessionManager;
                if (m == null)
                {
                    //requestContext.HttpContext.Response.Redirect(setCfgInstance.CMS_SIGNIN);
                    //return;
                }
                currentModule = SiteUtil.Instance.GetCMSPageModuleInfo();
            }
            base.Initialize(requestContext);
        }

        protected override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            /*
            bool needAuthorization = SiteUtil.Instance.CheckAuthorization();
            if (needAuthorization) {
                OD_Manager m = sessionHelperInstance.SessionManager;
                if (m == null) {
                    //filterContext.Result = new RedirectResult(setCfgInstance.CMS_SIGNIN);
                    //return;
                }
                currentModule = SiteUtil.Instance.GetCMSPageModuleInfo();
            }
             * */
            ViewData[setCfgInstance.CURRENT_PAGE_MODULE_VIEWDATA_KEY] = currentModule;
            ViewData[setCfgInstance.URL_ENCODE_CURRENT_QUERY_AND_PATH_VIEWDATA_KEY] = SiteUtil.Instance.GetUrlEncodeCurrentQueryAndPath();
            base.OnActionExecuted(filterContext);
        }
    }
}
