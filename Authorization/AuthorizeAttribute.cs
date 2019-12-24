using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static WebApplication1.Helpers.Enums;

namespace WebApplication1.UI.Authorization
{
    public class AuthorizeUserAttribute : Attribute, IAuthorizationFilter, IDisposable
    {
        private object RedirectObj;
        private UserRole? RequiredRole { get; set; }

        public AuthorizeUserAttribute()
        {
        }
        public AuthorizeUserAttribute(UserRole requiredRole)
        {
            RequiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserID");
            int? userRole = context.HttpContext.Session.GetInt32("UserRole");
            if (userId == null || (RequiredRole != null && RequiredRole != (UserRole?)userRole))
            {
                RedirectLoginRoute(context);
                return;
            }
        }

        private bool SkipAuthorization(AuthorizationFilterContext filterContext)
        {
            bool isAnonymous = filterContext.ActionDescriptor.FilterDescriptors.Where(n => n.Filter.GetType() == typeof(AllowAnonymousFilter)).Any();
            return isAnonymous;
        }

        private void RedirectLoginRoute(AuthorizationFilterContext context)
        {
            RedirectObj = new
            {
                controller = "Login",
                action = "Index",
                returnurl = "/"
            };

            HandleUnauthorizedRequest(context);
        }
        private void RedirectUnAuthorizateRoute(AuthorizationFilterContext context)
        {
            RedirectObj = new
            {
                controller = "Error",
                action = "AuthorizationFailed",
                returnurl = "/"
            };

            HandleUnauthorizedRequest(context);

        }
        protected void HandleUnauthorizedRequest(AuthorizationFilterContext filterContext)
        {
            Dispose();
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(RedirectObj));
        }

        public void Dispose()
        {

        }
    }
}