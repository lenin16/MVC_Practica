using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica_MVC.Models.TableViewModels
{
    public class UsuarioTableViewModel
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }        
    }
}