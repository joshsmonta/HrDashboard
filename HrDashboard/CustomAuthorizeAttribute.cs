using System;
using System.Web.Mvc;

namespace HrDashboard
{
    [AttributeUsage(AttributeTargets.All)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string ViewName { get; set; }

        public CustomAuthorizeAttribute()
        {
            ViewName = "Error";
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        void IsUserAuthorized(AuthorizationContext filterContext)
        {
            if (filterContext.Result == null)
            {
                return;
            }
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewDataDictionary dic = new ViewDataDictionary();
                dic.Add("Message",
                    "Your account cannot access this page, please Log -in an Administrator Account. " +
                    "For more information, contact Sonic IT Support: ");
                var results = new ViewResult() { ViewName = this.ViewName, ViewData = dic };
                filterContext.Result = results;
            }
        }
    }
}