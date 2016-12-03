using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace OwinDemo
{
    public class StopWatchMiddleware:OwinMiddleware
    {
        private StopWatMiddlewareParam _option;
        public StopWatchMiddleware(OwinMiddleware next,StopWatMiddlewareParam option) : base(next)
        {
            _option = option;
            if (_option.InCommingAction == null)
            {
                _option.InCommingAction = context =>
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    Debug.WriteLine("start");
                    context.Environment["stopWatch"] = stopWatch;
                };
            }
            if (_option.OutGoingAction == null)
            {
                _option.OutGoingAction = context =>
                {
                    var stopWatch = (Stopwatch) context.Environment["stopWatch"];
                    stopWatch.Stop();
                    Debug.WriteLine($"Stop watch time :{stopWatch.ElapsedMilliseconds}");
                    
                };
            }
        }

        public override Task Invoke(IOwinContext context)
        {
            return Task.Run(() =>
            {
                _option.InCommingAction(context);
                Next.Invoke(context);
                _option.OutGoingAction(context);
            });
        }
    }

    public class StopWatMiddlewareParam
    {
        public Action<IOwinContext> InCommingAction{ get; set; }
        public Action<IOwinContext> OutGoingAction { get; set; }

    }
}