using BL.Data;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private ASIRGroupDBEntities databaseManager = new ASIRGroupDBEntities();

        public AccountController()
        {
        }

        [AllowAnonymous]
        [OutputCache(NoStore=true, Duration=0, VaryByParam="None")]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if (base.Request.IsAuthenticated)
                {
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception exception)
            {
                Console.Write(exception);
            }
            return base.View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ActionResult local;
            try
            {
                var list = new List<WebKullanicilari>();
                if (base.ModelState.IsValid)
                {
                    DbSet<WebKullanicilari> webKullanicilaris = this.databaseManager.WebKullanicilari;
                    list = webKullanicilaris.Where(w => w.WebKullaniciNo == model.UserName).ToList();
                };
                //var list = webKullanicilaris1.Select(Expression.Lambda(Expression.New(methodFromHandle, (IEnumerable<Expression>)expressionArray, memberInfoArray), new ParameterExpression[] { parameterExpression })).ToList();
                if (list == null || list.Count() <= 0)
                {
                    base.ModelState.AddModelError(string.Empty, "Invalid User Name or Password.");
                }
                else
                {
                    var kullanici = list.First();
                    int kullaniciID = kullanici.id;
                    string webKullaniciNo = kullanici.WebKullaniciNo;
                    string webKullaniciRoles = kullanici.WebKullaniciRoles;
                    base.Session["userID"] = kullaniciID;
                    base.Session["WebKullaniciNo"] = webKullaniciNo;
                    base.Session["WebKullaniciRoles"] = webKullaniciRoles;
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    string str = kullanici.WebKullaniciNo;
                    DateTime now = DateTime.Now;
                    DateTime dateTime = DateTime.Now;
                    string str1 = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, str, now, dateTime.AddMinutes(30), false, kullanici.WebKullaniciRoles));
                    HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, str1);
                    base.HttpContext.Response.Cookies.Add(httpCookie);
                    this.SignInUser(kullanici.WebKullaniciNo, false);
                    ASIRGroupDBEntities aSIRGroupDBEntity = new ASIRGroupDBEntities();
                    try
                    {
                        try
                        {
                            aSIRGroupDBEntity.Database.Connection.Open();
                            using (aSIRGroupDBEntity.Database.Connection)
                            {
                                SqlDataReader sqlDataReader = (new SqlCommand()
                                {
                                    Connection = (SqlConnection)aSIRGroupDBEntity.Database.Connection,
                                    CommandText = "Set nocount on Set Dateformat dmy Update Sabitler set Genelid = Genelid + 1 OUTPUT inserted.Genelid  "
                                }).ExecuteReader(CommandBehavior.CloseConnection);
                                if (sqlDataReader != null)
                                {
                                    while (sqlDataReader.Read())
                                    {
                                        int item = (int)sqlDataReader["Genelid"];
                                        base.Session["genelID"] = item;
                                    }
                                    sqlDataReader.Close();
                                }
                                else
                                {
                                    local = null;
                                    return local;
                                }
                            }
                        }
                        catch (SqlException sqlException)
                        {
                            throw;
                        }
                    }
                    finally
                    {
                        aSIRGroupDBEntity.Database.Connection.Close();
                    }
                    local = this.RedirectToLocal(returnUrl);
                    return local;
                }
            }
            
            catch (Exception exception1)
            {
                Exception exception = exception1;
                Console.Write(exception);
                ((dynamic)base.ViewBag).hata = exception.InnerException.Message;
                local = base.View();
                return local;
            }
            return base.View(model);
        }

        public ActionResult LogOff()
        {
            try
            {
                base.Request.GetOwinContext().Authentication.SignOut(new string[0]);
                base.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                base.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                base.HttpContext.Response.Cache.SetNoStore();
                base.Session.Clear();
                base.Session.Abandon();
                base.Session.RemoveAll();
                FormsAuthentication.SignOut();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return base.RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            ActionResult actionResult;
            try
            {
                if (!base.Url.IsLocalUrl(returnUrl))
                {
                    return base.RedirectToAction("Index", "Home");
                }
                else
                {
                    actionResult = this.Redirect(returnUrl);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return actionResult;
        }

        public ActionResult Register()
        {
            return base.View();
        }

        private void SignInUser(string username, bool isPersistent)
        {
            List<Claim> claims = new List<Claim>();
            try
            {
                claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");
                base.Request.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = isPersistent
                }, new ClaimsIdentity[] { claimsIdentity });
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}