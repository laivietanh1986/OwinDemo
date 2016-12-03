using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using Owin;

namespace OwinDemo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            
            app.Use<DebugMiddleware>();
           app.Use<ShowRequestInforMiddleware>();
            app.UseStopWatchMiddleware();
            // use for web api 
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}