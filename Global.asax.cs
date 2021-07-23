using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Webtonic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }

       
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            HttpRequest request = HttpContext.Current.Request;
            var values = new System.Web.Routing.RouteValueDictionary();

            string StakeTrace = exception.StackTrace;
            string massage = exception.Message;
            var exceptionName = exception.GetType().Name;
            string urlPath = request.Url.AbsolutePath;
            string urlPath1 = request.AppRelativeCurrentExecutionFilePath;

            Response.Redirect("~/Errors/ErrorExeptionsMessage/?ErrorInfo=" + massage);
        }
    }
}
