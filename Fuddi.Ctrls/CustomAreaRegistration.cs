using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Fuddi.Ctrls
{
    public class CustomAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Fuddi"; }
        }

        private static string BASE_NAMESPACE
        {
            get
            {
                return "Fuddi.Ctrls";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            string[] mallCtrlNamespaces = new string[] { BASE_NAMESPACE, BASE_NAMESPACE + ".Mall" };
            string[] cmsCtrlNamespaces = new string[] { BASE_NAMESPACE, BASE_NAMESPACE + ".CMS" };
            string[] transportCtrlNamespaces = new string[] { BASE_NAMESPACE, BASE_NAMESPACE + ".Transport" };
            string[] apiCtrlNamespaces = new string[] { BASE_NAMESPACE, BASE_NAMESPACE + ".Api" };

            #region cms router

            context.MapRoute(
                "cms-pager",
                "_cms/{controller}/{action}/p_{pageIndex}/{*prms}",
                null,
                cmsCtrlNamespaces
            );

            context.MapRoute(
                "cms-default",
                "_cms/{controller}/{action}/{*prms}",
                new { controller = "home", action = "signin", prms = UrlParameter.Optional },
                null,
                cmsCtrlNamespaces
                );


            #endregion

            #region mall router

            context.MapRoute(
                "mall-pager",
                "{controller}/{action}/p_{pageIndex}/{*parms}",
                null,
                mallCtrlNamespaces
            );

            context.MapRoute(
                "mall-default",
                "{controller}/{action}/{*prms}",
                new { controller = "home", action = "index", prms = UrlParameter.Optional },
                null,
                mallCtrlNamespaces
                );

            #endregion

            #region api router

            /*
            context.MapRoute(
                "api-default",
                "Api/{controller}/{action}/{*prms}",
                new { controller = "Demo", action = "Index", prms = UrlParameter.Optional },
                null,
                apiCtrlNamespaces
                );
             * */

            #endregion

            #region transport router

            /*
            context.MapRoute(
                "transport-default",
                "{controller}/{action}/{*prms}",
                new { controller = "Home", action = "Index", prms = UrlParameter.Optional },
                null,
                transportCtrlNamespaces
                );
             * */

            #endregion
        }
    }
}
