using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
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

            app.Use(async (context, func) =>
            {
                await context.Response.WriteAsync("<html>" +
                                                   "<head></heade>" +
                                                  "<body><h2>Hello World</h2></body>" +
                                                  "</html>");
            });
        }
    }
}