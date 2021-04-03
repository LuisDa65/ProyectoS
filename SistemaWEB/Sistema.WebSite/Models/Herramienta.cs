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
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public string Proveedor { get; set; }
        public string Imagen { get; set; }

    }
}