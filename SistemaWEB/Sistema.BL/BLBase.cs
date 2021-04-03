using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.BL
{
    /// <summary>
    /// Clase base de las clases de la capa de regla de negocios.
    /// </summary>
    public abstract class BLBase
    {
        /// <summary>
        /// Cadena de conexión que apunta hacia la instancia y base de datos que recibirá las peticiones.
        /// </summary>

        protected private readonly string connectionString;

        /// <summary>
        /// Constructor donde se asigna el valor para connectionString
        /// </summary>
        public BLBase()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["CONNECTION_STRING_NAME"]].ConnectionString;
        }

    }
}
