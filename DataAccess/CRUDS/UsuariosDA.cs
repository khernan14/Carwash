using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;
using Domain.Metodos;

namespace DataAccess.CRUDS {
    public class UsuariosDA : ConnectionToSql {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public DataTable Mostrar() {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_USUARIOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@codigo", 0 );
                    command.Parameters.AddWithValue( "@nombres", "" );
                    command.Parameters.AddWithValue( "@usuario", "" );
                    command.Parameters.AddWithValue( "@password", "" );
                    command.Parameters.AddWithValue( "@icono", null );
                    command.Parameters.AddWithValue( "@nombreIcono", "" );
                    command.Parameters.AddWithValue( "@correo", "" );
                    command.Parameters.AddWithValue( "@rol", "" );
                    command.Parameters.AddWithValue( "@accion", "Mostrar" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Buscar(string buscar) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_USUARIOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@buscar", buscar );
                    command.Parameters.AddWithValue( "@accion", "Buscar" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Insertar( string nombres, string usuario, string password, byte[] icono, string nombreIcono, string correo, string rol ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_USUARIOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@nombres", nombres );
                    command.Parameters.AddWithValue( "@usuario", usuario );
                    command.Parameters.AddWithValue( "@password", EncryptData.Encriptar(password) );
                    command.Parameters.AddWithValue( "@icono", icono );
                    command.Parameters.AddWithValue( "@nombreIcono", nombreIcono );
                    command.Parameters.AddWithValue( "@correo", correo );
                    command.Parameters.AddWithValue( "@rol", rol );
                    command.Parameters.AddWithValue( "@accion", "Insertar" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Actualizar( int codigo, string nombres, string usuario, string password, byte[] icono, string nombreIcono, string correo, string rol ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_USUARIOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@codigo", codigo );
                    command.Parameters.AddWithValue( "@nombres", nombres );
                    command.Parameters.AddWithValue( "@usuario", usuario );
                    command.Parameters.AddWithValue( "@password", EncryptData.Encriptar(password) );
                    command.Parameters.AddWithValue( "@icono", icono );
                    command.Parameters.AddWithValue( "@nombreIcono", nombreIcono );
                    command.Parameters.AddWithValue( "@correo", correo );
                    command.Parameters.AddWithValue( "@rol", rol );
                    command.Parameters.AddWithValue( "@accion", "Actualizar" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Eliminar( int codigo ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_USUARIOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@codigo", codigo );
                    command.Parameters.AddWithValue( "@accion", "Eliminar" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }
        

        public bool MostrarUsuarios( FlowLayoutPanel flPanel, EventHandler myEventLabel, string buscar, string usuario ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "SELECT usuarioID, nombres AS [Nombre Completo], usuario AS Usuario, password AS Contraseña, icono, nombreIcono, correo AS Correo, rol\r\n\t\tFROM usuarios\r\n\t\tWHERE nombres LIKE '%' + '"+ buscar +"' + '%' OR usuario LIKE '%' + '" + usuario + "' + '%' AND estado = 'Activo'";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label ID = new Label();
                            LinkLabel lblNombre = new LinkLabel();
                            LinkLabel lblUsuario = new LinkLabel();
                            Label lblPass = new Label();
                            Label lblIcono = new Label();
                            Label lblCorreo = new Label();
                            Label lblRol = new Label();
                            Guna2CheckBox chk = new Guna2CheckBox();
                            Guna2Panel panel = new Guna2Panel();
                            Guna2CirclePictureBox perfil = new Guna2CirclePictureBox();

                            //PictureBox image = new PictureBox();

                            ID.Text = reader[ "usuarioID" ].ToString();
                            ID.Name = reader[ "usuarioID" ].ToString();

                            lblNombre.Text = reader[ "Nombre Completo" ].ToString();
                            lblNombre.Name = reader[ "Nombre Completo" ].ToString();

                            lblUsuario.Text = reader[ "Usuario" ].ToString();
                            lblUsuario.Name = reader[ "usuario" ].ToString();

                            lblPass.Text = reader[ "Contraseña" ].ToString();
                            lblPass.Name = reader[ "Contraseña" ].ToString();

                            byte[] img = (byte[])reader[ "icono" ];
                            MemoryStream ms = new MemoryStream( img );

                            perfil.Text = reader[ "icono" ].ToString();
                            perfil.Name = reader[ "icono" ].ToString();
                            perfil.Image = Image.FromStream( ms );

                            lblIcono.Text = reader[ "nombreIcono" ].ToString();
                            lblIcono.Name = reader[ "nombreIcono" ].ToString();

                            lblCorreo.Text = reader[ "Correo" ].ToString();
                            lblCorreo.Name = reader[ "Correo" ].ToString();

                            lblRol.Text = reader[ "rol" ].ToString();
                            lblRol.Name = reader[ "rol" ].ToString();

                            chk.Animated = true;
                            chk.BackColor = Color.Transparent;
                            chk.Dock = DockStyle.Left;
                            chk.Size = new Size( 30, 72 );
                            chk.Padding = new Padding( 20, 0, 0, 0 );
                            chk.FlatStyle = FlatStyle.Flat;


                            ID.Size = new Size( 62, 72 );
                            ID.Font = new Font( "Poppins", 12 );
                            ID.FlatStyle = FlatStyle.Flat;
                            ID.BackColor = Color.Transparent;
                            ID.ForeColor = Color.Silver;
                            ID.Dock = DockStyle.Left;
                            ID.TextAlign = ContentAlignment.MiddleCenter;
                            ID.Cursor = Cursors.Hand;

                            lblNombre.Size = new Size( 275, 72 );
                            lblNombre.Font = new Font( "Poppins", 12 );
                            lblNombre.FlatStyle = FlatStyle.Flat;
                            lblNombre.BackColor = Color.Transparent;
                            lblNombre.ForeColor = Color.Silver;
                            lblNombre.Dock = DockStyle.Left;
                            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
                            lblNombre.Cursor = Cursors.Hand;
                            lblNombre.LinkColor = Color.Silver;
                            lblNombre.DisabledLinkColor = Color.Silver;
                            lblNombre.LinkBehavior = LinkBehavior.HoverUnderline;
                            lblNombre.ActiveLinkColor = Color.FromArgb( 32, 33, 36 );
                            lblNombre.VisitedLinkColor = Color.Silver;

                            lblUsuario.Size = new Size( 222, 72 );
                            lblUsuario.Font = new Font( "Poppins", 12 );
                            lblUsuario.FlatStyle = FlatStyle.Flat;
                            lblUsuario.BackColor = Color.Transparent;
                            lblUsuario.ForeColor = Color.Silver;
                            lblUsuario.Dock = DockStyle.Left;
                            lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
                            lblUsuario.Cursor = Cursors.Hand;
                            lblUsuario.LinkColor = Color.Silver;
                            lblUsuario.DisabledLinkColor = Color.Silver;
                            lblUsuario.LinkBehavior = LinkBehavior.HoverUnderline;
                            lblUsuario.ActiveLinkColor = Color.FromArgb( 32, 33, 36 );
                            lblUsuario.VisitedLinkColor = Color.Silver;

                            lblPass.Size = new Size( 235, 72 );
                            lblPass.Font = new Font( "Poppins", 12 );
                            lblPass.FlatStyle = FlatStyle.Flat;
                            lblPass.BackColor = Color.Transparent;
                            lblPass.ForeColor = Color.Silver;
                            lblPass.Dock = DockStyle.Left;
                            lblPass.TextAlign = ContentAlignment.MiddleCenter;
                            lblPass.Cursor = Cursors.Hand;

                            lblIcono.Size = new Size( 100, 72 );
                            lblIcono.Font = new Font( "Poppins", 12 );
                            lblIcono.FlatStyle = FlatStyle.Flat;
                            lblIcono.BackColor = Color.Transparent;
                            lblIcono.ForeColor = Color.Silver;
                            lblIcono.Dock = DockStyle.Left;
                            lblIcono.TextAlign = ContentAlignment.MiddleCenter;
                            lblIcono.Cursor = Cursors.Hand;
                            lblIcono.Visible = false;

                            lblCorreo.Size = new Size( 100, 72 );
                            lblCorreo.Font = new Font( "Poppins", 12 );
                            lblCorreo.FlatStyle = FlatStyle.Flat;
                            lblCorreo.BackColor = Color.Transparent;
                            lblCorreo.ForeColor = Color.Silver;
                            lblCorreo.Dock = DockStyle.Left;
                            lblCorreo.TextAlign = ContentAlignment.MiddleCenter;
                            lblCorreo.Cursor = Cursors.Hand;
                            lblCorreo.Visible = false;

                            lblRol.Size = new Size( 100, 72 );
                            lblRol.Font = new Font( "Poppins", 12 );
                            lblRol.FlatStyle = FlatStyle.Flat;
                            lblRol.BackColor = Color.Transparent;
                            lblRol.ForeColor = Color.Silver;
                            lblRol.Dock = DockStyle.Left;
                            lblRol.TextAlign = ContentAlignment.MiddleCenter;
                            lblRol.Cursor = Cursors.Hand;
                            lblRol.Visible = false;

                            perfil.Dock = DockStyle.Left;
                            perfil.Size = new Size( 72, 72 );
                            perfil.SizeMode = PictureBoxSizeMode.StretchImage;
                            perfil.BackColor = Color.Transparent;
                            //perfil.Visible = false;

                            panel.Size = new Size( 866, 72 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );
                            lblNombre.Click += myEventLabel;
                            lblUsuario.Click += myEventLabel;

                            panel.Controls.Add( lblRol );
                            panel.Controls.Add( lblCorreo );
                            panel.Controls.Add( lblIcono );
                            panel.Controls.Add( lblPass );
                            panel.Controls.Add( lblUsuario );
                            panel.Controls.Add( lblNombre );
                            panel.Controls.Add( perfil );
                            panel.Controls.Add( ID );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }
    }
}
