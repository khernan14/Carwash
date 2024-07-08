using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using System.Web.UI;

namespace DataAccess.CRUDS {
    public class LicenciasDA : ConnectionToSql {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public DataTable InsertarLicenciaPrueba(string s, string f, string e, string fa) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                        command.Connection = connection;
                        command.CommandText = "LicenciasSistema";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue( "@s", s );
                        command.Parameters.AddWithValue( "@f", f );
                        command.Parameters.AddWithValue( "@e", e );
                        command.Parameters.AddWithValue( "@fa", fa );
                        command.Parameters.AddWithValue( "@accion", "LicenciaPrueba" );
                        leer = command.ExecuteReader();
                        table.Load( leer );
                        connection.Close();
                }
            }
            return table;
        }

    }
}
