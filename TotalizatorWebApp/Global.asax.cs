using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TotalizatorWebApp.DAL.Abstraction.UnitOfWork;
using TotalizatorWebApp.DAL.Concrete.UnitOfWork;

namespace TotalizatorWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [Inject]
        public IUnitOfWork unitOfWork { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ModelBinders.Binders.DefaultBinder = new JsonModelBinder();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = e;
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //UnitOfWork unitOfWork = new UnitOfWork();
                        string login = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;

                        string roles = unitOfWork.UserRepository.GetUserRole(login);

                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(login, "Forms"), roles.Split(';'));
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}
