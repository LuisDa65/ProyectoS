using Sistema.TL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL
{
    public class PermisosHandler : DALBase
    {
        public PermisosHandler(string connectionString) : base(connectionString)
        {
        }
        public List<Modulo> DameModulos(int IdRol)
        {
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand comm = null;

            List<Modulo> modulos = null;

            try
            {
                conn = new SqlConnection(this.connectionString);
                comm = new SqlCommand("SELECT Nombre FROM udfDameModulos(@IdRol)", conn);
                comm.CommandType = CommandType.Text;
                comm.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int) { Value = IdRol });

                conn.Open();
                dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    modulos = new List<Modulo>();
                    while (dr.Read())
                    {
                        modulos.Add(new Modulo()
                        {

                            Nombre = dr["Nombre"].ToString()

                        });
                    }
                }

                dr.Close();
                conn.Close();

                return modulos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"No se pudo obtener los modulos", ex);
            }
            finally
            {
                try { if (comm != null) comm.Dispose(); }
                catch { }
                try { if (dr != null) comm.Dispose(); }
                catch { }
                try { if (conn != null) comm.Dispose(); }
                catch { }
            }
        }
    }
}
