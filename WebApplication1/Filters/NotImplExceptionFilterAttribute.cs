using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApplication1.Filters
{
    /// <summary>
    /// Exception Filter for handling NotImplemented Exceptions
    /// <para>Use <see cref="NotImplExceptionFilterOptOutAttribute"/> to opt out of this behavior</para>
    /// </summary>
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Convert NotImplementedException into HTTP Status Code 501
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            // try to get the method specific attributes
            var attributes = context.ActionContext.ActionDescriptor.GetCustomAttributes<NotImplExceptionFilterOptOutAttribute>(true);

            // in case the attribute was not found on the method, try to find it on the controller
            if(attributes.Count == 0)
                attributes = context.ActionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<NotImplExceptionFilterOptOutAttribute>(true);

            if (attributes.Count == 0 && context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
}