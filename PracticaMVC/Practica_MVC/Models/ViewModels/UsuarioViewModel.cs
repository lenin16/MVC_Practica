using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica_MVC.Models.ViewModels
{
    public class UsuarioViewModel
    {

       [Required]
       [EmailAddress]
       [StringLength(80,ErrorMessage ="El correo no debe tener mas 80 caracteres",MinimumLength =1)]
       [Display(Name ="Correo Electronico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Las contraseñas no son iguales")]
        public string ConfirmarPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }

    public class EditUsuarioViewModel
    {

        public int IdUsuario { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(80, ErrorMessage = "El correo no debe tener mas 80 caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmarPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}