using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ekomsys.Web.Models
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authorized => no need to go any further
                return false;
            }

            // We have an authenticated user, let's get his username
            string authenticatedUser = httpContext.User.Identity.Name;

            // and check if he has completed his profile


            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Items.Contains("redirectToCompleteProfile"))
            {
                var routeValues = new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index",
                });
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

        private bool IsProfileCompleted(string user)
        {
            // You know what to do here => go hit your database to verify if the
            // current user has already completed his profile by checking
            // the corresponding field
            throw new NotImplementedException();
        }
    }
}