using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication1.Filters
{
    /// <summary>
    /// Action filter for handling modelstates.
    /// Response will be BadRequest with Modelstate information in case of invalid modelstate
    /// </summary>
    public class ValidateModelFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Returns BadRequest with Modelstate information in case of invalid modelstate
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if (!modelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, modelState);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}