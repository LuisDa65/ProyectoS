using Sistema.TL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sistema.BL
{
    public class PermisosHandler : BLBase
    {

        public Permisos DamePermisos(int IdRol)
        {
            try
            {
                DAL.PermisosHandler permisosModulos = new DAL.PermisosHandler(connectionString);
                List<Modulo> modulos = permisosModulos.DameModulos(IdRol);

                Permisos permisos = new Permisos();
                permisos.Herramienta = 0;
                permisos.MateriaPrima = 0;
                permisos.Productos = 0;
                permisos.Clientes = 0;
                permisos.CotizacionVentas = 0;
                permisos.Istalacion = 0;
                permisos.Compras = 0;
                permisos.VentasRealizadas = 0;
                permisos.Reportes = 0;

                foreach (Modulo mod in modulos)
                {
                    if (mod.Nombre == "Herramienta") { permisos.Herramienta = 1; }
                    else if (mod.Nombre == "MateriaPrima") { permisos.MateriaPrima = 1; }
                    else if (mod.Nombre == "Productos") { permisos.Productos = 1; }
                    else if (mod.Nombre == "Clientes") { permisos.Clientes = 1; }
                    else if (mod.Nombre == "CotizacionVentas") { permisos.CotizacionVentas = 1; }
                    else if (mod.Nombre == "Instalacion") { permisos.Istalacion = 1; }
                    else if (mod.Nombre == "Compras") { permisos.Compras = 1; }
                    else if (mod.Nombre == "VentasRealizadas") { permisos.VentasRealizadas = 1; }
                    else if (mod.Nombre == "Compras") { permisos.Compras = 1; }
                }


                return permisos;
            }
            catch (Exception)
            {
                return null;
            }


        }
    }
}
