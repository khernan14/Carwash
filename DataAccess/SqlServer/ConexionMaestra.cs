using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer {
    class ConexionMaestra {
        public static string conexion = @"Data Source=" + Convert.ToString( DesencryptedConnection.checkServer() );
        public static SqlConnection conectar = new SqlConnection( conexion );
        public static void abrir() {
            if ( conectar.State == ConnectionState.Closed ) {
                conectar.Open();
            }
        }
        public static void cerrar() {
            if ( conectar.State == ConnectionState.Open ) {
                conectar.Close();
            }
        }
    }
}
