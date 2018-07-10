using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patterns.Models.Authorization
{
    
    public class CheckAuthorization : AuthorizeAttribute, IResultFilter
    {        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //HttpContext.Current.Session["UserID"] == null || 
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 302; //Found Redirection to another page. Here- login page. Check Layout ajaxError() script.
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    filterContext.Result = new RedirectResult(System.Web.Security.FormsAuthentication.LoginUrl + "?ReturnUrl=" +
                         filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl));
                }
            } 
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //koji je tip korisnika i da li ima prava pristupa stranici 
            //TODO: provjeriti da li da li je korisnik enabled
            //TODO: provjeriti da li da li je prekoračio broj bodova
            //TODO: provjeriti da li da li je prekoračio broj dokumenata
            //TODO: provjeriti da li da li ima IP restrikciju i da li odgovara IP trenutnoj IP adresi korisnika
            //TODO: provjeriti da li paket od korisnika ima u paketu od dokumenta
            bool isPackage = false;
            IUser user = (IUser)HttpContext.Current.Session["User"];
            IDocument doc = (IDocument)HttpContext.Current.Session["Document"];
            foreach (var item in user.Packages)
            {
                //provjeriti da li paket od korisnika ima u paketu od dokumenta
                isPackage = true;
            }
            if (!isPackage)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 302; //Found Redirection to another page. Here- login page. Check Layout ajaxError() script.
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    filterContext.Result = new RedirectResult(System.Web.Security.FormsAuthentication.LoginUrl + "?ReturnUrl=" +
                         filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.RawUrl));
                }
            }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }
    }
}