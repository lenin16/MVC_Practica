using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica_MVC.Models;
using Practica_MVC.Controllers;

namespace Practica_MVC.Filters
{
    public class VerifySession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var oUser = (Usuario)HttpContext.Current.Session["User"];
            if (oUser == null)
            {
                if (filterContext.Controller is AcesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Aceso/Inicio");
                }
            }
            else
            {
                if (filterContext.Controller is AcesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}