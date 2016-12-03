using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using OwinDemo;

namespace Owin
{
    public static class StopWatchMiddlewareExtension
    {
        public static void UseStopWatchMiddleware(this IAppBuilder appBuilder,StopWatMiddlewareParam param = null)
        {
            if (param == null)
            {
                param = new StopWatMiddlewareParam();
            }
            appBuilder.Use<StopWatchMiddleware>(param);
        }
    }
}