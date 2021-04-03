using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema.WebSite.Models
{
    public class Login
    {
        /// <summary>
        /// Dirección de correo electrónico.
        /// </summary>
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage = "El correo electrónico no tiene un formato válido")]
        public string Correo { get; set; }



    
        [Required(ErrorMessage = "La contraseña  es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}