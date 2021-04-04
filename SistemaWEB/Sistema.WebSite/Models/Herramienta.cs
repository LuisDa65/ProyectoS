using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema.WebSite.Models
{
    public class Herramienta
    {
        public string Clave { get; set; }

        [Display(Name ="Ingese codigo de barra")]
        public string CodigoBarra { get; set; }
        [Display(Name = "Ingese nombre de herramienta")]
        public string Nombre { get; set; }
        [Display(Name = "Ingese color de herramienta")]
        public string Color { get; set; }
        [Display(Name = "Ingese largo de herramienta")]
        public decimal Largo { get; set; }
        [Display(Name = "Ingese ancho de herramienta")]
        public decimal Ancho { get; set; }
        [Display(Name = "Ingese precio de herramienta")]
        public decimal Precio { get; set; }
        [Display(Name = "Ingese cantidad de herramienta")]
        public int Cantidad { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Seleccione la casilla para activar o desactivar la herramienta")]
        public bool Activo { get; set; }
        [Display(Name = "Ingese nombre del proveedor de la herramienta")]
        public string Proveedor { get; set; }
        public string Imagen { get; set; }

    }
}