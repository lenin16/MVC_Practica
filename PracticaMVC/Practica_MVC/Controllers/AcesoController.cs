using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica_MVC.Models;

namespace Practica_MVC.Controllers
{
    public class AcesoController : Controller
    {
        // GET: Aceso
        public ActionResult Inicio()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Entrar(string usuario, string password)
        {

            try
            {
                using (BD_PracticaEntities db = new BD_PracticaEntities())
                {
                    var lst = (from d in db.Usuario
                               where d.Email == usuario && d.Password == password && d.IdEstado==1
                               select d);

                    if (lst.Count() > 0)
                    {
                        Usuario oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("usuario incorrecto");
                    }
                }

                    
            }
            catch (Exception ep)
            {

                return Content("ocurrio un error " +ep.Message);
            }
        }
    }
}