using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HayvanDostu.UI.MVC.CustomFilters
{
    public class BireyselLoginFilter: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //kullanıcı girişi varken
            if (System.Web.HttpContext.Current.Session["bireyselKullanici"] != null)
            {
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //kullanıcı girişi yok
            filterContext.Result = new RedirectResult("/Account/Login");
        }
    }
}