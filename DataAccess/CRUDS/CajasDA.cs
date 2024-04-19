using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS {
    public class CajasDA : ConnectionToSql{
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public DataTable Insertar( int usuarioID, int cajaID ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "PROCESOS_CAJAS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@fechaInicio", DateTime.Today );
                    command.Parameters.AddWithValue( "@fechaFin", DateTime.Today );
                    command.Parameters.AddWithValue( "@fechaCierre", DateTime.Today );
                    command.Parameters.AddWithValue( "@ingresos", 0.00 );
                    command.Parameters.AddWithValue( "@egresos", 0.00 );
                    command.Parameters.AddWithValue( "@saldoRestante", 0.00 );
                    command.Parameters.AddWithValue( "@usuarioID", usuarioID );
                    command.Parameters.AddWithValue( "@totalCalculado", 0.00 );
                    command.Parameters.AddWithValue( "@totalReal", 0.00 );
                    command.Parameters.AddWithValue( "@estado", "CAJA APERTURADA" );
                    command.Parameters.AddWithValue( "@diferencia", 0.00 );
                    command.Parameters.AddWithValue( "@cajaID", cajaID );
                    command.Parameters.AddWithValue( "@accion", "InsertarCierreCaja" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable EditarSaldoInicial( int cajaID, decimal saldoRestante ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "PROCESOS_CAJAS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@saldoRestante", saldoRestante );
                    command.Parameters.AddWithValue( "@cajaID", cajaID );
                    command.Parameters.AddWithValue( "@accion", "EditarSaldoInicial" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable CerrarCaja( int cajaID, DateTime fechaFin, DateTime fechaCierre ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "PROCESOS_CAJAS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@cajaID", cajaID );
                    command.Parameters.AddWithValue( "@fechaInicio", null );
                    command.Parameters.AddWithValue( "@fechaFin", fechaFin );
                    command.Parameters.AddWithValue( "@fechaCierre", fechaCierre );
                    command.Parameters.AddWithValue( "@ingresos", 0 );
                    command.Parameters.AddWithValue( "@egresos", 0 );
                    command.Parameters.AddWithValue( "@saldoRestante", 0);
                    command.Parameters.AddWithValue( "@usuarioID", 0 );
                    command.Parameters.AddWithValue( "@totalCalculado", 0 );
                    command.Parameters.AddWithValue( "@totalReal", 0 );
                    command.Parameters.AddWithValue( "@estado", "" );
                    command.Parameters.AddWithValue( "@diferencia", 0 );
                    command.Parameters.AddWithValue( "@accion", "CerrarCaja" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }
    }
}
