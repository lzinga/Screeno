﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Screeno;

namespace ScreenoExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
#if DEBUG
            Screeno.Screeno screen = new Screeno.Screeno(@"C:\Temp\ScreenoImages");
#endif
        }
    }
}
