using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS {
    public class ConsumidoresDA : ConnectionToSql {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public DataTable InsertarConsumidor(string nombre, string direccionFacturacion, string ruc, string telefono, string tipoConsumidor, string estado, string saldo) {
            using(var connection = GetConnection()) {
                connection.Open();
                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_CONSUMIDORES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@nombre", nombre );
                    command.Parameters.AddWithValue( "@direccionFacturacion", direccionFacturacion );
                    command.Parameters.AddWithValue( "@ruc", ruc );
                    command.Parameters.AddWithValue( "@telefono", telefono );
                    command.Parameters.AddWithValue( "@tipoConsumidor", tipoConsumidor );
                    command.Parameters.AddWithValue( "@estado", estado );
                    command.Parameters.AddWithValue( "@saldo", saldo );
                    command.Parameters.AddWithValue( "@accion", "Insertar" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }
    }
}
