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
        /// <summary>
        /// Obtiene lista de permisos del usuario logueado
        /// </summary>
        /// <param name="IdRol"></param>
        /// <returns></returns>
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
                throw new ApplicationException("No se pudo obtener los modulos", ex);
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

        /// <summary>
        /// Validar credenciales del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Usuario IniSesion(Usuario usuario)
        {
            SqlConnection conn = null;
            SqlDataReader dr = null;
            SqlCommand comm = null;
            Usuario result = null;
            try
            {
                conn = new SqlConnection(this.connectionString);
                comm = new SqlCommand("SELECT Id,Nombre, Correo, Contraseña,IdRol FROM udfIniciarSesion(@Correo,@Contraseña)", conn);
                comm.CommandType = CommandType.Text;
                comm.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 50) { Value = usuario.Correo });
                comm.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.VarChar, 100) { Value = usuario.Contraseña });


                conn.Open();
                dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    result = new Usuario()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Nombre = dr["Nombre"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Contraseña = dr["Contraseña"].ToString(),
                        IdRol = int.Parse(dr["IdRol"].ToString())

                    };
                }

                dr.Close();
                conn.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"No se pudo iniciar sesión", ex);
            }
            finally
            {
                try { if (comm != null) comm.Dispose(); }
                catch { }
                try { if (dr != null) dr.Dispose(); }
                catch { }
                try { if (conn != null) conn.Dispose(); }
                catch { }

            }
        }
    }
}
