using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using System.Drawing;
using BorderStyle = System.Windows.Forms.BorderStyle;
using System.IO;
using Image = System.Drawing.Image;
using DataAccess.MailServices;
using Guna.UI2.WinForms;
using Common;
using Domain.Metodos;

namespace DataAccess.SqlServer {
    public class UserDao : ConnectionToSql {
        private DataTable table = new DataTable();
        private SqlDataReader leer;
        private AES aes = new AES();

        string Indicador;

        public bool DatabaseExists() {
            try {
                using ( SqlConnection connection = new SqlConnection( GetConnection().ConnectionString ) ) {
                    connection.Open();
                    using ( SqlCommand command = new SqlCommand( "SELECT database_id FROM sys.databases WHERE Name = @databaseName", connection ) ) {
                        command.Parameters.AddWithValue( "@databaseName", ServerInstaller.DataBaseName ); // Cambia "YourDatabaseName" por el nombre de tu base de datos
                        object result = command.ExecuteScalar();
                        return result != null;
                    }
                }
            } catch ( Exception ex ) {
                // Log or handle the exception as needed
                Console.WriteLine( "Error in DatabaseExists: " + ex.Message );
                return false;
            }
        }

        //// Método para verificar si la tabla de usuarios tiene registros
        public bool DatabaseHasUsers() {
            try {
                using ( var connection = new SqlConnection( GetConnection().ConnectionString ) ) {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM usuarios"; // Reemplaza 'Usuarios' con el nombre real de tu tabla de usuarios
                    using ( var command = new SqlCommand( query, connection ) ) {
                        int userCount = (int)command.ExecuteScalar();
                        return userCount > 0;
                    }
                }
            } catch ( SqlException ) {
                return false;
            }
        }

        public bool MostrarUsuarios() {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "IniciarSesion";
                    command.Parameters.AddWithValue( "@usuario", "Mostrar" );
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            UserLoginCache.userID = reader.GetInt32( 0 );
                            UserLoginCache.cargo = reader.GetString( 3 );
                        }
                        return true;
                    } else return false;
                }
            }
        }
        public bool Login( string usuario, string pass ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "IniciarSesion";
                    command.Parameters.AddWithValue( "@usuario", usuario );
                    command.Parameters.AddWithValue( "@pass", pass );
                    command.Parameters.AddWithValue( "@accion", "Login" );
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            UserLoginCache.userID = reader.GetInt32( 0 );
                            UserLoginCache.cargo = reader.GetString( 3 );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public DataTable LoginsControl(string serialPCID) {
            using (var connection = GetConnection()) {
                connection.Open();
                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandText = "IniciarSesion";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("serialPCID", serialPCID);
                    command.Parameters.AddWithValue("accion", "Logins");
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            } return table;
        }

        public bool CargarCajas( string serial ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "PROCESOS_CAJAS";
                    command.Parameters.AddWithValue( "@fechaInicio", null );
                    command.Parameters.AddWithValue( "@fechaFin", null );
                    command.Parameters.AddWithValue( "@fechaCierre", null );
                    command.Parameters.AddWithValue( "@ingresos", 0 );
                    command.Parameters.AddWithValue( "@egresos", 0 );
                    command.Parameters.AddWithValue( "@saldoRestante", 0 );
                    command.Parameters.AddWithValue( "@usuarioID", 0 );
                    command.Parameters.AddWithValue( "@totalCalculado", 0 );
                    command.Parameters.AddWithValue( "@totalReal", 0 );
                    command.Parameters.AddWithValue( "@estado", "" );
                    command.Parameters.AddWithValue( "@diferencia", 0 );
                    command.Parameters.AddWithValue( "@cajaID", 0 );
                    command.Parameters.AddWithValue( "@serial", serial );
                    command.Parameters.AddWithValue( "@accion", "MostrarCajaSerial" );
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            UserLoginCache.cajaID = reader.GetInt32( 0 );
                            UserLoginCache.descripcionCaja = reader.GetString( 1 );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool isOpenedBox( string serial, int usuarioID ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "PROCESOS_CAJAS";
                    command.Parameters.AddWithValue( "@fechaInicio", null );
                    command.Parameters.AddWithValue( "@fechaFin", null );
                    command.Parameters.AddWithValue( "@fechaCierre", null );
                    command.Parameters.AddWithValue( "@ingresos", 0 );
                    command.Parameters.AddWithValue( "@egresos", 0 );
                    command.Parameters.AddWithValue( "@saldoRestante", 0 );
                    command.Parameters.AddWithValue( "@usuarioID", usuarioID );
                    command.Parameters.AddWithValue( "@totalCalculado", 0 );
                    command.Parameters.AddWithValue( "@totalReal", 0 );
                    command.Parameters.AddWithValue( "@estado", "" );
                    command.Parameters.AddWithValue( "@diferencia", 0 );
                    command.Parameters.AddWithValue( "@cajaID", 0 );
                    command.Parameters.AddWithValue( "@serial", serial );
                    command.Parameters.AddWithValue( "@accion", "MovimientosCajasSerial" );
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {

                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool CargarUsuarios( FlowLayoutPanel flPanel, EventHandler myEventLabel, EventHandler myEventImage ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM usuarios WHERE estado = 'Activo'";
                    //command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label b = new Label();
                            Guna2Panel panel = new Guna2Panel();
                            PictureBox image = new PictureBox();

                            b.Text = reader[ "usuario" ].ToString();
                            b.Name = reader[ "usuarioID" ].ToString();
                            b.Size = new Size( 180, 73 );
                            b.Font = new Font( "Poppins", 14 );
                            b.FlatStyle = FlatStyle.Flat;
                            b.BackColor = Color.FromArgb( 32, 33, 36 );
                            b.ForeColor = Color.Silver;
                            b.Dock = DockStyle.Bottom;
                            b.TextAlign = ContentAlignment.MiddleCenter;
                            b.Cursor = Cursors.Hand;

                            panel.Size = new Size( 180, 242 );
                            panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.BackColor = Color.FromArgb( 32, 33, 36 );

                            image.Size = new Size( 180, 169 );
                            image.Dock = DockStyle.Top;
                            image.BackgroundImage = null;
                            byte[] bi = (byte[])reader[ "icono" ];
                            MemoryStream ms = new MemoryStream( bi );
                            image.Image = Image.FromStream( ms );
                            image.SizeMode = PictureBoxSizeMode.StretchImage;
                            image.Tag = reader[ "usuario" ].ToString();
                            image.Cursor = Cursors.Hand;

                            panel.Controls.Add( b );
                            panel.Controls.Add( image );
                            flPanel.Controls.Add( panel );

                            b.Click += new EventHandler( myEventLabel );
                            image.Click += new EventHandler( myEventImage );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public string recoverPassword( string userRequesting ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "EnvioDeCorreos";
                    command.Parameters.AddWithValue( "@correo", userRequesting );
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.Read() == true ) {
                        string userName = reader.GetString( 0 );
                        string userMail = reader.GetString( 3 );
                        string password = reader.GetString( 2 );
                        var mailServices = new MailServices.SystemSupportMail();
                        mailServices.sendMail(
                          subject: "Solicitud de recuperacion de contraseña",
                          body: "<!DOCTYPE html>\r\n<html lang=\"es\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width, " +
                          "initial-scale=1.0\">\r\n  <title>Recuperación de Contraseña</title>\r\n  <style>\r\n    /* Estilos generales */\r\n    body {\r\n      font-family: Arial, sans-serif;\r\n      " +
                          "color: white;\r\n      margin: 0;\r\n      padding: 0;\r\n      background-color: #f3f3f3;\r\n    }\r\n    .container {\r\n      max-width: 600px;\r\n      margin: 20px auto;\r\n      " +
                          "padding: 20px;\r\n      background-color: #297bbc;\r\n      border-radius: 10px;\r\n      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n    }/* Estilos para el encabezado */\r\n    .header {\r\n      " +
                          "text-align: center;\r\n      padding-bottom: 20px;\r\n    }\r\n    .header img {\r\n      max-width: 200px;\r\n      margin-top: 20px;\r\n    }\r\n    " +
                          "/* Estilos para el cuerpo del correo */\r\n    .content {\r\n      padding: 20px 0;\r\n    }\r\n    .content p {\r\n      margin: 10px 0;\r\n    }\r\n    " +
                          "/* Estilos para el pie de página */\r\n    .footer {\r\n      text-align: center;\r\n      padding-top: 20px;\r\n    }\r\n  </style>\r\n</head>\r\n<body>\r\n  " +
                          "<div class=\"container\">\r\n    <div class=\"header\">\r\n      <img src=\"../../Resources/LogoCarwash.png\" alt=\"Icono de Cerradura\">\r\n    </div>\r\n    " +
                          "<div class=\"content\">\r\n      <p>Hola estimado '" + userName + "',</p>\r\n      <p>Recibimos una solicitud para restablecer la contraseña de tu cuenta. Si no hiciste esta solicitud, por favor ignora este correo electrónico.</p>\r\n      " +
                          "<p>Su contraseña es: <b>'" + password + "'</b></p>\r\n\r\n      <p>Gracias,</p>\r\n      <p>El equipo de Carwash El Puente</p>\r\n    </div>\r\n    <div class=\"footer\">\r\n      " +
                          "<p>Si necesitas ayuda, por favor contáctanos en khernandez@gmail.com o visita nuestra página de <a href=\"[URL de Soporte]\">Soporte</a>.</p>\r\n    </div>\r\n  </div>\r\n</body>\r\n</html>\r\n",
                          recipientMail: new List<string> { userMail }
                          );
                        return "Hola " + userName + "\nsolicitaste recuperar tu contraseña.\n" +
                                "Por favor, revise su correo electrónico" +
                                "\nAdvertencia, por favor cambie su contraseña una ves ingrese al sistema.";
                    } else
                        return "Lo sentimos, no tiene una cuenta con ese correo electronico";
                }
            }
        }
    }
}
