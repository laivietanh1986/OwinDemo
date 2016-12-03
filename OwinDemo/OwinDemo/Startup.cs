using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace OwinDemo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Auth/Login"),

            });
            //app.Use<DebugMiddleware>();
            //app.Use<ShowRequestInforMiddleware>();
            //app.UseStopWatchMiddleware();
            // use for web api 
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

        }
    }
}