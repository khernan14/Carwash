using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS {
    public class TicketsDA : ConnectionToSql {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public DataTable Tickets( string identificadorFiscal, string direccion, string provincia, string nombreMoneda, string agradecimiento, string paginaWeb, string anuncio, 
                                    string datosFiscales, string forDefault) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "Design_Tickets";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@identificadorFiscal", identificadorFiscal );
                    command.Parameters.AddWithValue( "@direccion", direccion );
                    command.Parameters.AddWithValue( "@provincia", provincia );
                    command.Parameters.AddWithValue( "@nombreMoneda", nombreMoneda );
                    command.Parameters.AddWithValue( "@agradecimiento", agradecimiento );
                    command.Parameters.AddWithValue( "@paginaWeb", paginaWeb );
                    command.Parameters.AddWithValue( "@anuncio", anuncio );
                    command.Parameters.AddWithValue( "@datosFiscales", datosFiscales );
                    command.Parameters.AddWithValue( "@forDefault", forDefault );
                    command.Parameters.AddWithValue( "@accion", "Tickets" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }
    }
}
