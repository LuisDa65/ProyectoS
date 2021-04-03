using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL
{
    public class VentasHandler : DALBase
    {
        public VentasHandler(string connectionString) : base(connectionString)
        {
        }
        public bool VerificarPermiso(int IdRol, int IdO)
        {

            SqlConnection conn = null;
            SqlCommand comm = null;
            bool result = false;
            try
            {
                conn = new SqlConnection(connectionString);
                comm = new SqlCommand("SELECT dbo.udfVerificarPermiso(@IdRol,@IdOperacion)", conn);
                comm.CommandType = CommandType.Text;
                comm.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int) { Value = IdRol });
                comm.Parameters.Add(new SqlParameter("@IdOperacion", SqlDbType.Int) { Value = IdO });

                conn.Open();
                object objResult = comm.ExecuteScalar();
                conn.Close();

                result = bool.Parse(objResult.ToString());

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error inesperado", ex);
            }
            finally
            {
                try { if (comm != null) comm.Dispose(); }
                catch { }

                try { if (conn != null) conn.Dispose(); }
                catch { }
            }
        }
    }
}
