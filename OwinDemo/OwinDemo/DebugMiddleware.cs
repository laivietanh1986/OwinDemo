using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace OwinDemo
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class DebugMiddleware
    {
        private AppFunc _next;
        public  DebugMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var owinContext =new  OwinContext(env);
            Debug.WriteLine($"incoming Request Path:{owinContext.Request.Path}");
            await _next.Invoke(env);
            Debug.WriteLine($"outgoing Respose path{owinContext.Request.Path}");
        }

    }
}