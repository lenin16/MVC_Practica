using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica_MVC.Models;
using Practica_MVC.Models.TableViewModels;
using Practica_MVC.Models.ViewModels;

namespace Practica_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Inicio()
        {
            List<UsuarioTableViewModel> lst = null;
            using (BD_PracticaEntities db = new BD_PracticaEntities())
            {
                lst = (from d in db.Usuario
                       where d.IdEstado == 1
                       orderby d.Email
                       select new UsuarioTableViewModel
                       {
                           Email=d.Email,
                           IdUsuario=d.IdUsuario,
                           Edad=d.Edad
                       }).ToList();
            }
                return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new BD_PracticaEntities())
            {
                Usuario oUser = new Usuario();
                oUser.IdEstado = 1;
                oUser.Email = model.Email;
                oUser.Edad = model.Edad;
                oUser.Password = model.Password;

                db.Usuario.Add(oUser);

                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Usuario/Inicio"));
        }

        public ActionResult Edit(int id)
        {
            EditUsuarioViewModel model = new EditUsuarioViewModel();
            using (var db = new BD_PracticaEntities())
            {
                var oUser = db.Usuario.Find(id);
                model.Edad =(int) oUser.Edad;
                model.Email = oUser.Email;
                model.IdUsuario = oUser.IdUsuario;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(EditUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new BD_PracticaEntities())
            {
                var oUser = db.Usuario.Find(model.IdUsuario);
                oUser.Email = model.Email;
                oUser.Edad = model.Edad;

                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.Password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
                return Redirect(Url.Content("~/Usuario/Inicio"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
           
            using (var db = new BD_PracticaEntities())
            {
                var oUser = db.Usuario.Find(id);
                oUser.IdEstado = 3;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Content("1");
        }

    }
}