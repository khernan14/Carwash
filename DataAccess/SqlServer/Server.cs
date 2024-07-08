using Domain.Metodos;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using Telerik.Reporting.Charting;
using Timer = System.Windows.Forms.Timer;

namespace DataAccess.SqlServer {
    public class Server {

        private AES aes = new AES();
        ConnectionDAO connectionDAO = new ConnectionDAO();

        public void DeleteDataBase() {
            string connectionString = $"Data Source={ServerInstaller.servidor};Initial Catalog=master;Integrated Security=True";
            string deleteCommand = ServerInstaller.DeleteDataBase;

            using ( SqlConnection myConn = new SqlConnection( connectionString ) ) {
                SqlCommand comman = new SqlCommand( deleteCommand, myConn );

                try {
                    myConn.Open();
                    Console.WriteLine( "Executing SQL: " + deleteCommand ); // Verifica la cadena SQL
                    comman.ExecuteNonQuery();
                    Console.WriteLine( "Database deleted successfully." );
                } catch ( Exception ex ) {
                    Console.WriteLine( "Error: " + ex.Message );
                } finally {
                    if ( myConn.State == ConnectionState.Open ) {
                        myConn.Close();
                    }
                }
            }
        }

        public bool CreateDataBase() {
            string connectionString = $"Data Source={ServerInstaller.servidor};Initial Catalog=master;Integrated Security=True";
            string checkDbCommand = $"IF DB_ID(N'{ServerInstaller.DataBaseName}') IS NOT NULL SELECT 1 ELSE SELECT 0";
            string createDbCommand = $"CREATE DATABASE [{ServerInstaller.DataBaseName}]";

            using ( SqlConnection myConn = new SqlConnection( connectionString ) ) {
                SqlCommand checkCommand = new SqlCommand( checkDbCommand, myConn );
                SqlCommand createCommand = new SqlCommand( createDbCommand, myConn );

                try {
                    myConn.Open();

                    // Comprobar si la base de datos ya existe
                    int dbExists = (int)checkCommand.ExecuteScalar();
                    if ( dbExists == 1 ) {
                        Console.WriteLine( $"La base de datos {ServerInstaller.DataBaseName} ya existe." );
                        return false; // Indica que no se creó porque ya existía
                    }

                    // Crear la base de datos si no existe
                    Console.WriteLine( "Ejecutando SQL: " + createDbCommand ); // Verifica la cadena SQL
                    createCommand.ExecuteNonQuery();

                    connectionDAO.SavetoXML(
                        aes.Encrypt(
                            $"Data Source={ServerInstaller.servidor}; Initial Catalog={ServerInstaller.DataBaseName}; Integrated Security=True",
                            DesencryptedConnection.appPwdUnique,
                            int.Parse( "256" )
                        )
                    );
                    CreateProcedures();
                    //CreateUsuarios();
                    Console.WriteLine( "Base de datos creada exitosamente." );
                    return true;
                } catch ( Exception ex ) {
                    Console.WriteLine( "Error: " + ex.Message );
                    return false;
                } finally {
                    if ( myConn.State == ConnectionState.Open ) {
                        myConn.Close();
                    }
                }
            }
        }


        public void CreateProcedures() {
            string ruta = Path.Combine( Directory.GetCurrentDirectory(), ServerInstaller.Script );

            try {
                // Escribir el script en un archivo
                using ( StreamWriter sw = new StreamWriter( ruta, false ) ) {
                    sw.WriteLine( ServerInstaller.CreateDataBase );
                }

                // Ejecutar el script usando sqlcmd
                Process process = new Process();
                process.StartInfo.FileName = "sqlcmd";
                process.StartInfo.Arguments = $"-S {ServerInstaller.servidor} -i \"{ruta}\"";
                process.Start();
                process.WaitForExit();
                if ( process.ExitCode == 0 ) {
                    Console.WriteLine( "Procedures created successfully." );
                } else {
                    Console.WriteLine( "Error occurred while creating procedures." );
                }
            } catch ( Exception ex ) {
                Console.WriteLine( "Error: " + ex.Message );
            }
        }

        public void CreateUsuarios() {
            string ruta = Path.Combine( Directory.GetCurrentDirectory(), "Usuarios.txt" );

            try {
                // Escribir el script en un archivo
                using ( StreamWriter sw = new StreamWriter( ruta, false ) ) {
                    sw.WriteLine( ServerInstaller.CreateUsuario );
                }

                // Ejecutar el script usando sqlcmd
                Process process = new Process();
                process.StartInfo.FileName = "sqlcmd";
                process.StartInfo.Arguments = $"-S {ServerInstaller.servidor} -i \"{ruta}\"";
                process.Start();
                process.WaitForExit();
                if ( process.ExitCode == 0 ) {
                    Console.WriteLine( "Procedures CRUD_USUARIOS created successfully." );
                } else {
                    Console.WriteLine( "Error occurred while creating procedures CRUD_Usuarios." );
                }
            } catch ( Exception ex ) {
                Console.WriteLine( "Error: " + ex.Message );
            }
        }

        public void ExecuteSQLServer() {
            try {
                Process process = new Process();
                process.StartInfo.FileName = "SQL2022-SSEI-Expr.exe";
                process.StartInfo.Arguments = "/ConfigurationFile=ConfigurationFile.ini /ACTION=Install /IACCEPTSQLSERVERLICENSETERMS /SECURITYMODE=SQL /SAPWD=" + ServerInstaller.Password + " /SQLSYSADMINACOUNTS=" + ServerInstaller.UserLaptopName;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            } catch ( Exception ex ) {
                Console.WriteLine( "Error the Server: " + ex );
            }
        }

        public void CreateConfigurationFile(Timer timerCreateIni ) {
            string ruta;
            StreamWriter sw;
            ruta = Path.Combine( Directory.GetCurrentDirectory(), "ConfigurationFile.ini" );
            ruta = ruta.Replace( "ConfigurationFile.ini", @"SQL2022-SSEI-Expr\ConfigurationFile.ini" );

            if ( File.Exists( ruta ) == true ) {
                timerCreateIni.Stop();
            }

            try {
                sw = File.CreateText( ruta );
                sw.WriteLine(ServerInstaller.Configuration);
                sw.Flush();
                sw.Close();
                timerCreateIni.Stop();
            } catch ( Exception ex ) {
                Console.WriteLine( "Error in the Server: " + ex );
            }
        }
    }
}

