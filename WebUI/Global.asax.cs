using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(object sender_, CommandEventArgs e_)
        {
            if (base.Server.GetLastError() is CryptographicException)
            {
                FormsAuthentication.SignOut();
            }
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie item = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (item != null)
            {
                FormsAuthenticationTicket formsAuthenticationTicket = FormsAuthentication.Decrypt(item.Value);
                if (formsAuthenticationTicket != null && !formsAuthenticationTicket.Expired)
                {
                    string[] strArrays = formsAuthenticationTicket.UserData.Split(new char[] { ',' });
                    HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(formsAuthenticationTicket), strArrays);
                }
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        }
    }
}
