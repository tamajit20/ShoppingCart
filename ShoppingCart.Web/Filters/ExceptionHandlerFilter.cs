using ShoppingCart.Logic.Common;
using System.Web.Http.Filters;

namespace ShoppingCart.Web.Filters
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Utility.WriteLog(context.Exception);
        }
    }
}