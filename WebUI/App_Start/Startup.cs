using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;


[assembly: OwinStartupAttribute(typeof(WebUI.App_Start.Startup))]
namespace WebUI.App_Start
{
    public class Startup
    {
        public Startup()
        {
        }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(5)
            });
            app.UseExternalSignInCookie("ExternalCookie");
        }
    }
}