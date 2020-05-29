using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_MVC.Controllers
{
    public class CerrarController : Controller
    {

        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Inicio","Aceso");
        }
    }
}