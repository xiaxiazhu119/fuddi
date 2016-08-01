﻿using System;
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

        public override void RegisterArea(AreaRegistrationContext context)
        {
            string[] mallCtrlNamespaces = new string[] { "Fuddi.Ctrls", "Fuddi.Ctrls.Mall" };
            string[] transportCtrlNamespaces = new string[] { "Fuddi.Ctrls", "Fuddi.Ctrls.Transport" };

            #region mall router

            context.MapRoute(
                "mall-default",
                "{controller}/{action}/{*prms}",
                new { controller = "Home", action = "Index", prms = UrlParameter.Optional },
                null,
                mallCtrlNamespaces
                );

            #endregion

            #region transport router

            context.MapRoute(
                "transport-default",
                "{controller}/{action}/{*prms}",
                new { controller = "Home", action = "Index", prms = UrlParameter.Optional },
                null,
                transportCtrlNamespaces
                );

            #endregion
        }
    }
}