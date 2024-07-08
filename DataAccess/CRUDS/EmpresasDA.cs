using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUDS {
    public class EmpresasDA : ConnectionToSql {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public DataTable Insertar(string nombre, Byte[] logo, string impuesto, decimal porcentajeImpuesto, string moneda, string usaImpuesto, string modoBusqueda,
                                string carpetaBackups, string correo, string ultimaFechaBackup, DateTime ultimaFechaBDate, int frecuenciaBackups, string estado, string tipoEmpresa,
                                string pais, string redondeo
            ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_EMPRESA";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@nombre", nombre );
                    command.Parameters.AddWithValue( "@logo", logo );
                    command.Parameters.AddWithValue( "@impuesto", impuesto );
                    command.Parameters.AddWithValue( "@porcentajeImpuesto", porcentajeImpuesto );
                    command.Parameters.AddWithValue( "@moneda", moneda );
                    command.Parameters.AddWithValue( "@usaImpuesto", usaImpuesto );
                    command.Parameters.AddWithValue( "@modoBusqueda", modoBusqueda );
                    command.Parameters.AddWithValue( "@carpetaBackups", carpetaBackups );
                    command.Parameters.AddWithValue( "@correo", correo );
                    command.Parameters.AddWithValue( "@ultimaFechaBackup", ultimaFechaBackup );
                    command.Parameters.AddWithValue( "@ultimaFechaBDate", ultimaFechaBDate );
                    command.Parameters.AddWithValue( "@frecuenciaBackups", frecuenciaBackups );
                    command.Parameters.AddWithValue( "@estado", estado );
                    command.Parameters.AddWithValue( "@tipoEmpresa", tipoEmpresa );
                    command.Parameters.AddWithValue( "@pais", pais );
                    command.Parameters.AddWithValue( "@redondeo", redondeo );
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
