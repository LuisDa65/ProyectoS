using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema.BL
{
    public class VentasHandler : BLBase
    {

        public bool VerficarPermiso(int IdRol, int IdO)
        {
            DAL.VentasHandler ventas = new DAL.VentasHandler(connectionString);

            return ventas.VerificarPermiso(IdRol, IdO);

        }
    }
}
