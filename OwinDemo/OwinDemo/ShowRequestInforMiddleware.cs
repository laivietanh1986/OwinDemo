using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace OwinDemo
{
    public class ShowRequestInforMiddleware:OwinMiddleware
    {
        public ShowRequestInforMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
           return Task.Run(()=>
           {
               Debug.WriteLine(
                   $"incomming request{context.Request.Path},{context.Request.Accept},{context.Request.Body}");
               Next.Invoke(context);
           });
            
        }
    }
}