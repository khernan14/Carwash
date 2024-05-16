using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace DataAccess.CRUDS {
    public class KardexDA : ConnectionToSql {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public bool MostrarMovimientos( FlowLayoutPanel flPanel, int productoID ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@productoID", productoID );
                    command.Parameters.AddWithValue( "@accion", "BuscarMovimientos" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblFecha = new Label();
                            Label lblDescripcion = new Label();
                            Label lblMovimiento = new Label();
                            Label lblCantidadAnterior = new Label();
                            Label lblTipo = new Label();
                            Label lblCantidad = new Label();
                            Label lblCantidadActual = new Label();
                            Label lblCajero = new Label();
                            Label lblCategoria = new Label();
                            Label lblnombre = new Label();
                            //Label Logo = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();

                            lblFecha.Text = reader[ "fecha" ].ToString();
                            lblFecha.Name = reader[ "fecha" ].ToString();

                            lblDescripcion.Text = reader[ "descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "descripcion" ].ToString();

                            lblMovimiento.Text = reader[ "movimiento" ].ToString();
                            lblMovimiento.Name = reader[ "movimiento" ].ToString();

                            lblCantidadAnterior.Text = reader[ "cantidadAnterior" ].ToString();
                            lblCantidadAnterior.Name = reader[ "cantidadAnterior" ].ToString();

                            lblTipo.Text = reader[ "tipo" ].ToString();
                            lblTipo.Name = reader[ "tipo" ].ToString();


                            lblCantidad.Text = reader[ "Cantidad" ].ToString();
                            lblCantidad.Name = reader[ "Cantidad" ].ToString();

                            lblCantidadActual.Text = reader[ "cantidadActual" ].ToString();
                            lblCantidadActual.Name = reader[ "cantidadActual" ].ToString();

                            lblCajero.Text = reader[ "Cajero" ].ToString();
                            lblCajero.Name = reader[ "Cajero" ].ToString();

                            lblCategoria.Text = reader[ "categoria" ].ToString();
                            lblCategoria.Name = reader[ "categoria" ].ToString();

                            lblnombre.Text = reader[ "nombre" ].ToString();
                            lblnombre.Name = reader[ "nombre" ].ToString();

                            //Logo.Text = reader[ "Stock" ].ToString();

                            lblFecha.Size = new Size( 135, 70 );
                            lblFecha.Font = new Font( "Poppins", 12 );
                            lblFecha.FlatStyle = FlatStyle.Flat;
                            lblFecha.BackColor = Color.Transparent;
                            lblFecha.ForeColor = Color.Silver;
                            lblFecha.Dock = DockStyle.Left;
                            lblFecha.TextAlign = ContentAlignment.MiddleCenter;
                            lblFecha.Cursor = Cursors.Hand;

                            lblDescripcion.Size = new Size( 283, 70 );
                            lblDescripcion.Font = new Font( "Poppins", 12 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.IBeam;

                            lblMovimiento.Size = new Size( 226, 70 );
                            lblMovimiento.Font = new Font( "Poppins", 12 );
                            lblMovimiento.FlatStyle = FlatStyle.Flat;
                            lblMovimiento.BackColor = Color.Transparent;
                            lblMovimiento.ForeColor = Color.Silver;
                            lblMovimiento.Dock = DockStyle.Left;
                            lblMovimiento.TextAlign = ContentAlignment.MiddleCenter;
                            lblMovimiento.Cursor = Cursors.IBeam;

                            lblCantidadAnterior.Size = new Size( 95, 70 );
                            lblCantidadAnterior.Font = new Font( "Poppins", 12 );
                            lblCantidadAnterior.FlatStyle = FlatStyle.Flat;
                            lblCantidadAnterior.BackColor = Color.Transparent;
                            lblCantidadAnterior.ForeColor = Color.Silver;
                            lblCantidadAnterior.Dock = DockStyle.Left;
                            lblCantidadAnterior.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidadAnterior.Cursor = Cursors.IBeam;

                            lblTipo.Size = new Size( 146, 70 );
                            lblTipo.Font = new Font( "Poppins", 12 );
                            lblTipo.FlatStyle = FlatStyle.Flat;
                            lblTipo.BackColor = Color.Transparent;
                            lblTipo.ForeColor = Color.Silver;
                            lblTipo.Dock = DockStyle.Left;
                            lblTipo.TextAlign = ContentAlignment.MiddleCenter;
                            lblTipo.Cursor = Cursors.IBeam;

                            lblCantidad.Size = new Size( 115, 70 );
                            lblCantidad.Font = new Font( "Poppins", 12 );
                            lblCantidad.FlatStyle = FlatStyle.Flat;
                            lblCantidad.BackColor = Color.Transparent;
                            lblCantidad.ForeColor = Color.Silver;
                            lblCantidad.Dock = DockStyle.Left;
                            lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidad.Cursor = Cursors.IBeam;

                            lblCantidadActual.Size = new Size( 95, 70 );
                            lblCantidadActual.Font = new Font( "Poppins", 12 );
                            lblCantidadActual.FlatStyle = FlatStyle.Flat;
                            lblCantidadActual.BackColor = Color.Transparent;
                            lblCantidadActual.ForeColor = Color.Silver;
                            lblCantidadActual.Dock = DockStyle.Left;
                            lblCantidadActual.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidadActual.Cursor = Cursors.IBeam;

                            lblCajero.Size = new Size( 119, 70 );
                            lblCajero.Font = new Font( "Poppins", 12 );
                            lblCajero.FlatStyle = FlatStyle.Flat;
                            lblCajero.BackColor = Color.Transparent;
                            lblCajero.ForeColor = Color.Silver;
                            lblCajero.Dock = DockStyle.Left;
                            lblCajero.TextAlign = ContentAlignment.MiddleCenter;
                            lblCajero.Cursor = Cursors.IBeam;

                            lblCategoria.Size = new Size( 136, 70 );
                            lblCategoria.Font = new Font( "Poppins", 12 );
                            lblCategoria.FlatStyle = FlatStyle.Flat;
                            lblCategoria.BackColor = Color.Transparent;
                            lblCategoria.ForeColor = Color.Silver;
                            lblCategoria.Dock = DockStyle.Left;
                            lblCategoria.TextAlign = ContentAlignment.MiddleCenter;
                            lblCategoria.Cursor = Cursors.IBeam;

                            lblnombre.Size = new Size( 146, 70 );
                            lblnombre.Font = new Font( "Poppins", 12 );
                            lblnombre.FlatStyle = FlatStyle.Flat;
                            lblnombre.BackColor = Color.Transparent;
                            lblnombre.ForeColor = Color.Silver;
                            lblnombre.Dock = DockStyle.Left;
                            lblnombre.TextAlign = ContentAlignment.MiddleCenter;
                            lblnombre.Cursor = Cursors.IBeam;

                            panel.Size = new Size( 1350, 70 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );

                            panel.Controls.Add( lblnombre );
                            panel.Controls.Add( lblCategoria );
                            panel.Controls.Add( lblCajero );
                            panel.Controls.Add( lblCantidadActual );
                            panel.Controls.Add( lblCantidad );
                            panel.Controls.Add( lblTipo );
                            panel.Controls.Add( lblCantidadAnterior );
                            panel.Controls.Add( lblMovimiento );
                            panel.Controls.Add( lblDescripcion );
                            panel.Controls.Add( lblFecha );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool Cantidades( Guna2HtmlLabel txtCantidad, Guna2HtmlLabel txtCosto ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@accion", "Cantidades" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblCantidadP = new Label();
                            Label lblTotalCosto = new Label();


                            lblCantidadP.Text = reader[ "totalProductos" ].ToString();
                            lblCantidadP.Name = reader[ "totalProductos" ].ToString();

                            lblTotalCosto.Text = reader[ "Costo" ].ToString();
                            lblTotalCosto.Name = reader[ "Costo" ].ToString();

                            lblCantidadP.Size = new Size( 135, 70 );
                            lblCantidadP.Font = new Font( "Poppins", 12 );
                            lblCantidadP.FlatStyle = FlatStyle.Flat;
                            lblCantidadP.BackColor = Color.Transparent;
                            lblCantidadP.ForeColor = Color.Silver;
                            lblCantidadP.Dock = DockStyle.Left;
                            lblCantidadP.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidadP.Cursor = Cursors.Hand;

                            lblTotalCosto.Size = new Size( 283, 70 );
                            lblTotalCosto.Font = new Font( "Poppins", 12 );
                            lblTotalCosto.FlatStyle = FlatStyle.Flat;
                            lblTotalCosto.BackColor = Color.Transparent;
                            lblTotalCosto.ForeColor = Color.Silver;
                            lblTotalCosto.Dock = DockStyle.Left;
                            lblTotalCosto.TextAlign = ContentAlignment.MiddleCenter;
                            lblTotalCosto.Cursor = Cursors.IBeam;

                            txtCantidad.Text = lblCantidadP.Text;
                            txtCosto.Text = lblTotalCosto.Text;
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool StockMinimo( FlowLayoutPanel flPanel ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@accion", "StockMinimo" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblBarcode = new Label();
                            Label lblDescripcion = new Label();
                            Label lblPrecioCompra = new Label();
                            Label lblCategoria = new Label();
                            Label lblStock = new Label();
                            Label lblStockMinimo = new Label();
                            Label lblNombreEmpresa = new Label();
                            //Label Logo = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();

                            lblBarcode.Text = reader[ "barcode" ].ToString();
                            lblBarcode.Name = reader[ "barcode" ].ToString();

                            lblDescripcion.Text = reader[ "descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "descripcion" ].ToString();

                            lblPrecioCompra.Text = reader[ "precioCompra" ].ToString();
                            lblPrecioCompra.Name = reader[ "precioCompra" ].ToString();

                            lblCategoria.Text = reader[ "Categoria" ].ToString();
                            lblCategoria.Name = reader[ "Categoria" ].ToString();

                            lblStock.Text = reader[ "stock" ].ToString();
                            lblStock.Name = reader[ "stock" ].ToString();


                            lblStockMinimo.Text = reader[ "stockMinimo" ].ToString();
                            lblStockMinimo.Name = reader[ "stockMinimo" ].ToString();

                            lblNombreEmpresa.Text = reader[ "nombre" ].ToString();
                            lblNombreEmpresa.Name = reader[ "nombre" ].ToString();

                            //Logo.Text = reader[ "Stock" ].ToString();

                            lblBarcode.Size = new Size( 155, 70 );
                            lblBarcode.Font = new Font( "Poppins", 12 );
                            lblBarcode.FlatStyle = FlatStyle.Flat;
                            lblBarcode.BackColor = Color.Transparent;
                            lblBarcode.ForeColor = Color.Silver;
                            lblBarcode.Dock = DockStyle.Left;
                            lblBarcode.TextAlign = ContentAlignment.MiddleCenter;
                            lblBarcode.Cursor = Cursors.Hand;

                            lblDescripcion.Size = new Size( 300, 70 );
                            lblDescripcion.Font = new Font( "Poppins", 12 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.IBeam;

                            lblPrecioCompra.Size = new Size( 170, 70 );
                            lblPrecioCompra.Font = new Font( "Poppins", 12 );
                            lblPrecioCompra.FlatStyle = FlatStyle.Flat;
                            lblPrecioCompra.BackColor = Color.Transparent;
                            lblPrecioCompra.ForeColor = Color.Silver;
                            lblPrecioCompra.Dock = DockStyle.Left;
                            lblPrecioCompra.TextAlign = ContentAlignment.MiddleCenter;
                            lblPrecioCompra.Cursor = Cursors.IBeam;

                            lblCategoria.Size = new Size( 180, 70 );
                            lblCategoria.Font = new Font( "Poppins", 12 );
                            lblCategoria.FlatStyle = FlatStyle.Flat;
                            lblCategoria.BackColor = Color.Transparent;
                            lblCategoria.ForeColor = Color.Silver;
                            lblCategoria.Dock = DockStyle.Left;
                            lblCategoria.TextAlign = ContentAlignment.MiddleCenter;
                            lblCategoria.Cursor = Cursors.IBeam;

                            lblStock.Size = new Size( 170, 70 );
                            lblStock.Font = new Font( "Poppins", 12 );
                            lblStock.FlatStyle = FlatStyle.Flat;
                            lblStock.BackColor = Color.Transparent;
                            lblStock.ForeColor = Color.Silver;
                            lblStock.Dock = DockStyle.Left;
                            lblStock.TextAlign = ContentAlignment.MiddleCenter;
                            lblStock.Cursor = Cursors.IBeam;

                            lblStockMinimo.Size = new Size( 170, 70 );
                            lblStockMinimo.Font = new Font( "Poppins", 12 );
                            lblStockMinimo.FlatStyle = FlatStyle.Flat;
                            lblStockMinimo.BackColor = Color.Transparent;
                            lblStockMinimo.ForeColor = Color.Silver;
                            lblStockMinimo.Dock = DockStyle.Left;
                            lblStockMinimo.TextAlign = ContentAlignment.MiddleCenter;
                            lblStockMinimo.Cursor = Cursors.IBeam;

                            lblNombreEmpresa.Size = new Size( 95, 70 );
                            lblNombreEmpresa.Font = new Font( "Poppins", 12 );
                            lblNombreEmpresa.FlatStyle = FlatStyle.Flat;
                            lblNombreEmpresa.BackColor = Color.Transparent;
                            lblNombreEmpresa.ForeColor = Color.Silver;
                            lblNombreEmpresa.Dock = DockStyle.Left;
                            lblNombreEmpresa.TextAlign = ContentAlignment.MiddleCenter;
                            lblNombreEmpresa.Cursor = Cursors.IBeam;
                            lblNombreEmpresa.Visible = false;

                            panel.Size = new Size( 1135, 70 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );

                            panel.Controls.Add( lblNombreEmpresa );
                            panel.Controls.Add( lblStockMinimo );
                            panel.Controls.Add( lblStock );
                            panel.Controls.Add( lblCategoria );
                            panel.Controls.Add( lblPrecioCompra );
                            panel.Controls.Add( lblDescripcion );
                            panel.Controls.Add( lblBarcode );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool FiltrarKardex( FlowLayoutPanel flPanel, DateTime fecha, string tipo, int usuarioID ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@fecha", fecha );
                    command.Parameters.AddWithValue( "@tipo", tipo );
                    command.Parameters.AddWithValue( "@usuarioID", usuarioID );
                    command.Parameters.AddWithValue( "@accion", "FiltrarKardex" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblFecha = new Label();
                            Label lblDescripcion = new Label();
                            Label lblMovimiento = new Label();
                            Label lblCantidadAnterior = new Label();
                            Label lblTipo = new Label();
                            Label lblCantidad = new Label();
                            Label lblCantidadActual = new Label();
                            Label lblCajero = new Label();
                            Label lblCategoria = new Label();
                            Label lblnombre = new Label();
                            //Label Logo = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();

                            lblFecha.Text = reader[ "fecha" ].ToString();
                            lblFecha.Name = reader[ "fecha" ].ToString();

                            lblDescripcion.Text = reader[ "descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "descripcion" ].ToString();

                            lblMovimiento.Text = reader[ "movimiento" ].ToString();
                            lblMovimiento.Name = reader[ "movimiento" ].ToString();

                            lblCantidadAnterior.Text = reader[ "cantidadAnterior" ].ToString();
                            lblCantidadAnterior.Name = reader[ "cantidadAnterior" ].ToString();

                            lblTipo.Text = reader[ "tipo" ].ToString();
                            lblTipo.Name = reader[ "tipo" ].ToString();


                            lblCantidad.Text = reader[ "Cantidad" ].ToString();
                            lblCantidad.Name = reader[ "Cantidad" ].ToString();

                            lblCantidadActual.Text = reader[ "cantidadActual" ].ToString();
                            lblCantidadActual.Name = reader[ "cantidadActual" ].ToString();

                            lblCajero.Text = reader[ "Cajero" ].ToString();
                            lblCajero.Name = reader[ "Cajero" ].ToString();

                            lblCategoria.Text = reader[ "categoria" ].ToString();
                            lblCategoria.Name = reader[ "categoria" ].ToString();

                            lblnombre.Text = reader[ "nombre" ].ToString();
                            lblnombre.Name = reader[ "nombre" ].ToString();

                            //Logo.Text = reader[ "Stock" ].ToString();

                            lblFecha.Size = new Size( 135, 70 );
                            lblFecha.Font = new Font( "Poppins", 12 );
                            lblFecha.FlatStyle = FlatStyle.Flat;
                            lblFecha.BackColor = Color.Transparent;
                            lblFecha.ForeColor = Color.Silver;
                            lblFecha.Dock = DockStyle.Left;
                            lblFecha.TextAlign = ContentAlignment.MiddleCenter;
                            lblFecha.Cursor = Cursors.Hand;

                            lblDescripcion.Size = new Size( 283, 70 );
                            lblDescripcion.Font = new Font( "Poppins", 12 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.IBeam;

                            lblMovimiento.Size = new Size( 226, 70 );
                            lblMovimiento.Font = new Font( "Poppins", 12 );
                            lblMovimiento.FlatStyle = FlatStyle.Flat;
                            lblMovimiento.BackColor = Color.Transparent;
                            lblMovimiento.ForeColor = Color.Silver;
                            lblMovimiento.Dock = DockStyle.Left;
                            lblMovimiento.TextAlign = ContentAlignment.MiddleCenter;
                            lblMovimiento.Cursor = Cursors.IBeam;

                            lblCantidadAnterior.Size = new Size( 95, 70 );
                            lblCantidadAnterior.Font = new Font( "Poppins", 12 );
                            lblCantidadAnterior.FlatStyle = FlatStyle.Flat;
                            lblCantidadAnterior.BackColor = Color.Transparent;
                            lblCantidadAnterior.ForeColor = Color.Silver;
                            lblCantidadAnterior.Dock = DockStyle.Left;
                            lblCantidadAnterior.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidadAnterior.Cursor = Cursors.IBeam;

                            lblTipo.Size = new Size( 146, 70 );
                            lblTipo.Font = new Font( "Poppins", 12 );
                            lblTipo.FlatStyle = FlatStyle.Flat;
                            lblTipo.BackColor = Color.Transparent;
                            lblTipo.ForeColor = Color.Silver;
                            lblTipo.Dock = DockStyle.Left;
                            lblTipo.TextAlign = ContentAlignment.MiddleCenter;
                            lblTipo.Cursor = Cursors.IBeam;

                            lblCantidad.Size = new Size( 115, 70 );
                            lblCantidad.Font = new Font( "Poppins", 12 );
                            lblCantidad.FlatStyle = FlatStyle.Flat;
                            lblCantidad.BackColor = Color.Transparent;
                            lblCantidad.ForeColor = Color.Silver;
                            lblCantidad.Dock = DockStyle.Left;
                            lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidad.Cursor = Cursors.IBeam;

                            lblCantidadActual.Size = new Size( 95, 70 );
                            lblCantidadActual.Font = new Font( "Poppins", 12 );
                            lblCantidadActual.FlatStyle = FlatStyle.Flat;
                            lblCantidadActual.BackColor = Color.Transparent;
                            lblCantidadActual.ForeColor = Color.Silver;
                            lblCantidadActual.Dock = DockStyle.Left;
                            lblCantidadActual.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidadActual.Cursor = Cursors.IBeam;

                            lblCajero.Size = new Size( 119, 70 );
                            lblCajero.Font = new Font( "Poppins", 12 );
                            lblCajero.FlatStyle = FlatStyle.Flat;
                            lblCajero.BackColor = Color.Transparent;
                            lblCajero.ForeColor = Color.Silver;
                            lblCajero.Dock = DockStyle.Left;
                            lblCajero.TextAlign = ContentAlignment.MiddleCenter;
                            lblCajero.Cursor = Cursors.IBeam;

                            lblCategoria.Size = new Size( 136, 70 );
                            lblCategoria.Font = new Font( "Poppins", 12 );
                            lblCategoria.FlatStyle = FlatStyle.Flat;
                            lblCategoria.BackColor = Color.Transparent;
                            lblCategoria.ForeColor = Color.Silver;
                            lblCategoria.Dock = DockStyle.Left;
                            lblCategoria.TextAlign = ContentAlignment.MiddleCenter;
                            lblCategoria.Cursor = Cursors.IBeam;

                            lblnombre.Size = new Size( 146, 70 );
                            lblnombre.Font = new Font( "Poppins", 12 );
                            lblnombre.FlatStyle = FlatStyle.Flat;
                            lblnombre.BackColor = Color.Transparent;
                            lblnombre.ForeColor = Color.Silver;
                            lblnombre.Dock = DockStyle.Left;
                            lblnombre.TextAlign = ContentAlignment.MiddleCenter;
                            lblnombre.Cursor = Cursors.IBeam;

                            panel.Size = new Size( 1350, 70 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );

                            panel.Controls.Add( lblnombre );
                            panel.Controls.Add( lblCategoria );
                            panel.Controls.Add( lblCajero );
                            panel.Controls.Add( lblCantidadActual );
                            panel.Controls.Add( lblCantidad );
                            panel.Controls.Add( lblTipo );
                            panel.Controls.Add( lblCantidadAnterior );
                            panel.Controls.Add( lblMovimiento );
                            panel.Controls.Add( lblDescripcion );
                            panel.Controls.Add( lblFecha );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool FiltrarKardexAcumulados( FlowLayoutPanel flPanel, DateTime fecha, string tipo, int usuarioID ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@fecha", fecha );
                    command.Parameters.AddWithValue( "@tipo", tipo );
                    command.Parameters.AddWithValue( "@usuarioID", usuarioID );
                    command.Parameters.AddWithValue( "@accion", "FiltrarKardexAcumulados" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblDescripcion = new Label();
                            Label lblTipo = new Label();
                            Label lblCantidad = new Label();
                            Label lblCajero = new Label();
                            //Label Logo = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();


                            lblDescripcion.Text = reader[ "descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "descripcion" ].ToString();

                            lblTipo.Text = reader[ "tipo" ].ToString();
                            lblTipo.Name = reader[ "tipo" ].ToString();


                            lblCantidad.Text = reader[ "Cantidad Total" ].ToString();
                            lblCantidad.Name = reader[ "Cantidad Total" ].ToString();

                            lblCajero.Text = reader[ "Cajero" ].ToString();
                            lblCajero.Name = reader[ "Cajero" ].ToString();

                            lblDescripcion.Size = new Size( 213, 50 );
                            lblDescripcion.Font = new Font( "Poppins", 9 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.IBeam;

                            lblTipo.Size = new Size( 107, 50 );
                            lblTipo.Font = new Font( "Poppins", 9 );
                            lblTipo.FlatStyle = FlatStyle.Flat;
                            lblTipo.BackColor = Color.Transparent;
                            lblTipo.ForeColor = Color.Silver;
                            lblTipo.Dock = DockStyle.Left;
                            lblTipo.TextAlign = ContentAlignment.MiddleCenter;
                            lblTipo.Cursor = Cursors.IBeam;

                            lblCantidad.Size = new Size( 115, 70 );
                            lblCantidad.Font = new Font( "Poppins", 9 );
                            lblCantidad.FlatStyle = FlatStyle.Flat;
                            lblCantidad.BackColor = Color.Transparent;
                            lblCantidad.ForeColor = Color.Silver;
                            lblCantidad.Dock = DockStyle.Left;
                            lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
                            lblCantidad.Cursor = Cursors.IBeam;

                            lblCajero.Size = new Size( 152, 50 );
                            lblCajero.Font = new Font( "Poppins", 9 );
                            lblCajero.FlatStyle = FlatStyle.Flat;
                            lblCajero.BackColor = Color.Transparent;
                            lblCajero.ForeColor = Color.Silver;
                            lblCajero.Dock = DockStyle.Left;
                            lblCajero.TextAlign = ContentAlignment.MiddleCenter;
                            lblCajero.Cursor = Cursors.IBeam;
                            lblCajero.Visible = false;

                            panel.Size = new Size( 473, 50 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );

                            panel.Controls.Add( lblCajero );
                            panel.Controls.Add( lblCantidad );
                            panel.Controls.Add( lblTipo );
                            panel.Controls.Add( lblDescripcion );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool MostrarInventarios( FlowLayoutPanel flPanel, string buscar ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@buscar", buscar );
                    command.Parameters.AddWithValue( "@accion", "MostrarInventarios" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblBarcode = new Label();
                            Label lblDescripcion = new Label();
                            Label lblCosto = new Label();
                            Label lblPrecioVenta = new Label();
                            Label lblStock = new Label();
                            Label lblStockMinimo = new Label();
                            Label lblCategoria = new Label();
                            Label lblImporte = new Label();
                            Label lblNombreEmpresa = new Label();
                            //Label Logo = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();

                            lblBarcode.Text = reader[ "barcode" ].ToString();
                            lblBarcode.Name = reader[ "barcode" ].ToString();

                            lblDescripcion.Text = reader[ "descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "descripcion" ].ToString();

                            lblCosto.Text = reader[ "Costo" ].ToString();
                            lblCosto.Name = reader[ "Costo" ].ToString();

                            lblPrecioVenta.Text = reader[ "precioVenta" ].ToString();
                            lblPrecioVenta.Name = reader[ "precioVenta" ].ToString();

                            lblCategoria.Text = reader[ "Categoria" ].ToString();
                            lblCategoria.Name = reader[ "Categoria" ].ToString();

                            lblStock.Text = reader[ "stock" ].ToString();
                            lblStock.Name = reader[ "stock" ].ToString();

                            lblImporte.Text = reader[ "Importe" ].ToString();
                            lblImporte.Name = reader[ "Importe" ].ToString();

                            lblStockMinimo.Text = reader[ "stockMinimo" ].ToString();
                            lblStockMinimo.Name = reader[ "stockMinimo" ].ToString();

                            lblNombreEmpresa.Text = reader[ "nombre" ].ToString();
                            lblNombreEmpresa.Name = reader[ "nombre" ].ToString();

                            //Logo.Text = reader[ "Stock" ].ToString();

                            lblBarcode.Size = new Size( 145, 70 );
                            lblBarcode.Font = new Font( "Poppins", 12 );
                            lblBarcode.FlatStyle = FlatStyle.Flat;
                            lblBarcode.BackColor = Color.Transparent;
                            lblBarcode.ForeColor = Color.Silver;
                            lblBarcode.Dock = DockStyle.Left;
                            lblBarcode.TextAlign = ContentAlignment.MiddleCenter;
                            lblBarcode.Cursor = Cursors.Hand;

                            lblDescripcion.Size = new Size( 300, 70 );
                            lblDescripcion.Font = new Font( "Poppins", 12 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.IBeam;

                            lblCosto.Size = new Size( 170, 70 );
                            lblCosto.Font = new Font( "Poppins", 12 );
                            lblCosto.FlatStyle = FlatStyle.Flat;
                            lblCosto.BackColor = Color.Transparent;
                            lblCosto.ForeColor = Color.Silver;
                            lblCosto.Dock = DockStyle.Left;
                            lblCosto.TextAlign = ContentAlignment.MiddleCenter;
                            lblCosto.Cursor = Cursors.IBeam;

                            lblPrecioVenta.Size = new Size( 180, 70 );
                            lblPrecioVenta.Font = new Font( "Poppins", 12 );
                            lblPrecioVenta.FlatStyle = FlatStyle.Flat;
                            lblPrecioVenta.BackColor = Color.Transparent;
                            lblPrecioVenta.ForeColor = Color.Silver;
                            lblPrecioVenta.Dock = DockStyle.Left;
                            lblPrecioVenta.TextAlign = ContentAlignment.MiddleCenter;
                            lblPrecioVenta.Cursor = Cursors.IBeam;

                            lblCategoria.Size = new Size( 180, 70 );
                            lblCategoria.Font = new Font( "Poppins", 12 );
                            lblCategoria.FlatStyle = FlatStyle.Flat;
                            lblCategoria.BackColor = Color.Transparent;
                            lblCategoria.ForeColor = Color.Silver;
                            lblCategoria.Dock = DockStyle.Left;
                            lblCategoria.TextAlign = ContentAlignment.MiddleCenter;
                            lblCategoria.Cursor = Cursors.IBeam;

                            lblStock.Size = new Size( 170, 70 );
                            lblStock.Font = new Font( "Poppins", 12 );
                            lblStock.FlatStyle = FlatStyle.Flat;
                            lblStock.BackColor = Color.Transparent;
                            lblStock.ForeColor = Color.Silver;
                            lblStock.Dock = DockStyle.Left;
                            lblStock.TextAlign = ContentAlignment.MiddleCenter;
                            lblStock.Cursor = Cursors.IBeam;

                            lblStockMinimo.Size = new Size( 170, 70 );
                            lblStockMinimo.Font = new Font( "Poppins", 12 );
                            lblStockMinimo.FlatStyle = FlatStyle.Flat;
                            lblStockMinimo.BackColor = Color.Transparent;
                            lblStockMinimo.ForeColor = Color.Silver;
                            lblStockMinimo.Dock = DockStyle.Left;
                            lblStockMinimo.TextAlign = ContentAlignment.MiddleCenter;
                            lblStockMinimo.Cursor = Cursors.IBeam;

                            lblImporte.Size = new Size( 170, 70 );
                            lblImporte.Font = new Font( "Poppins", 12 );
                            lblImporte.FlatStyle = FlatStyle.Flat;
                            lblImporte.BackColor = Color.Transparent;
                            lblImporte.ForeColor = Color.Silver;
                            lblImporte.Dock = DockStyle.Left;
                            lblImporte.TextAlign = ContentAlignment.MiddleCenter;
                            lblImporte.Cursor = Cursors.IBeam;

                            lblNombreEmpresa.Size = new Size( 95, 70 );
                            lblNombreEmpresa.Font = new Font( "Poppins", 12 );
                            lblNombreEmpresa.FlatStyle = FlatStyle.Flat;
                            lblNombreEmpresa.BackColor = Color.Transparent;
                            lblNombreEmpresa.ForeColor = Color.Silver;
                            lblNombreEmpresa.Dock = DockStyle.Left;
                            lblNombreEmpresa.TextAlign = ContentAlignment.MiddleCenter;
                            lblNombreEmpresa.Cursor = Cursors.IBeam;
                            lblNombreEmpresa.Visible = false;

                            panel.Size = new Size( 1485, 70 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );

                            panel.Controls.Add( lblNombreEmpresa );
                            panel.Controls.Add( lblImporte );
                            panel.Controls.Add( lblCategoria );
                            panel.Controls.Add( lblStockMinimo );
                            panel.Controls.Add( lblStock );
                            panel.Controls.Add( lblPrecioVenta );
                            panel.Controls.Add( lblCosto );
                            panel.Controls.Add( lblDescripcion );
                            panel.Controls.Add( lblBarcode );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool ProductosVencidos( FlowLayoutPanel flPanel, string buscar ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@buscar", buscar );
                    command.Parameters.AddWithValue( "@accion", "ProductosVencidos" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblBarcode = new Label();
                            Label lblDescripcion = new Label();
                            Label lblFechaVencimiento = new Label();
                            Label lblStock = new Label();
                            Label lblDiasVencidos = new Label();
                            Label lblNombreEmpresa = new Label();
                            //Label Logo = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();

                            lblBarcode.Text = reader[ "barcode" ].ToString();
                            lblBarcode.Name = reader[ "barcode" ].ToString();

                            lblDescripcion.Text = reader[ "descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "descripcion" ].ToString();

                            lblFechaVencimiento.Text = reader[ "fechaVencimiento" ].ToString();
                            lblFechaVencimiento.Name = reader[ "fechaVencimiento" ].ToString();

                            lblStock.Text = reader[ "stock" ].ToString();
                            lblStock.Name = reader[ "stock" ].ToString();

                            lblDiasVencidos.Text = reader[ "Dias Vencidos" ].ToString();
                            lblDiasVencidos.Name = reader[ "Dias Vencidos" ].ToString();

                            lblNombreEmpresa.Text = reader[ "nombre" ].ToString();
                            lblNombreEmpresa.Name = reader[ "nombre" ].ToString();

                            //Logo.Text = reader[ "Stock" ].ToString();

                            lblBarcode.Size = new Size( 148, 70 );
                            lblBarcode.Font = new Font( "Poppins", 12 );
                            lblBarcode.FlatStyle = FlatStyle.Flat;
                            lblBarcode.BackColor = Color.Transparent;
                            lblBarcode.ForeColor = Color.Silver;
                            lblBarcode.Dock = DockStyle.Left;
                            lblBarcode.TextAlign = ContentAlignment.MiddleCenter;
                            lblBarcode.Cursor = Cursors.Hand;

                            lblDescripcion.Size = new Size( 300, 70 );
                            lblDescripcion.Font = new Font( "Poppins", 12 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.IBeam;

                            lblFechaVencimiento.Size = new Size( 265, 70 );
                            lblFechaVencimiento.Font = new Font( "Poppins", 12 );
                            lblFechaVencimiento.FlatStyle = FlatStyle.Flat;
                            lblFechaVencimiento.BackColor = Color.Transparent;
                            lblFechaVencimiento.ForeColor = Color.Silver;
                            lblFechaVencimiento.Dock = DockStyle.Left;
                            lblFechaVencimiento.TextAlign = ContentAlignment.MiddleCenter;
                            lblFechaVencimiento.Cursor = Cursors.IBeam;

                            lblStock.Size = new Size( 176, 70 );
                            lblStock.Font = new Font( "Poppins", 12 );
                            lblStock.FlatStyle = FlatStyle.Flat;
                            lblStock.BackColor = Color.Transparent;
                            lblStock.ForeColor = Color.Silver;
                            lblStock.Dock = DockStyle.Left;
                            lblStock.TextAlign = ContentAlignment.MiddleCenter;
                            lblStock.Cursor = Cursors.IBeam;

                            lblDiasVencidos.Size = new Size( 280, 70 );
                            lblDiasVencidos.Font = new Font( "Poppins", 12 );
                            lblDiasVencidos.FlatStyle = FlatStyle.Flat;
                            lblDiasVencidos.BackColor = Color.Transparent;
                            lblDiasVencidos.ForeColor = Color.Silver;
                            lblDiasVencidos.Dock = DockStyle.Left;
                            lblDiasVencidos.TextAlign = ContentAlignment.MiddleCenter;
                            lblDiasVencidos.Cursor = Cursors.IBeam;

                            lblNombreEmpresa.Size = new Size( 95, 70 );
                            lblNombreEmpresa.Font = new Font( "Poppins", 12 );
                            lblNombreEmpresa.FlatStyle = FlatStyle.Flat;
                            lblNombreEmpresa.BackColor = Color.Transparent;
                            lblNombreEmpresa.ForeColor = Color.Silver;
                            lblNombreEmpresa.Dock = DockStyle.Left;
                            lblNombreEmpresa.TextAlign = ContentAlignment.MiddleCenter;
                            lblNombreEmpresa.Cursor = Cursors.IBeam;
                            lblNombreEmpresa.Visible = false;

                            panel.Size = new Size( 1168, 70 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );

                            panel.Controls.Add( lblNombreEmpresa );
                            panel.Controls.Add( lblDiasVencidos );
                            panel.Controls.Add( lblStock );
                            panel.Controls.Add( lblFechaVencimiento );
                            panel.Controls.Add( lblDescripcion );
                            panel.Controls.Add( lblBarcode );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public bool ProductosVencidosMenor30( FlowLayoutPanel flPanel ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@accion", "ProductosVencidosMenor30" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            Label lblBarcode = new Label();
                            Label lblDescripcion = new Label();
                            Label lblFechaVencimiento = new Label();
                            Label lblStock = new Label();
                            Label lblDiasVencidos = new Label();
                            Label lblNombreEmpresa = new Label();
                            //Label Logo = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();

                            lblBarcode.Text = reader[ "barcode" ].ToString();
                            lblBarcode.Name = reader[ "barcode" ].ToString();

                            lblDescripcion.Text = reader[ "descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "descripcion" ].ToString();

                            lblFechaVencimiento.Text = reader[ "fechaVencimiento" ].ToString();
                            lblFechaVencimiento.Name = reader[ "fechaVencimiento" ].ToString();

                            lblStock.Text = reader[ "stock" ].ToString();
                            lblStock.Name = reader[ "stock" ].ToString();

                            lblDiasVencidos.Text = reader[ "Dias a Vencer" ].ToString();
                            lblDiasVencidos.Name = reader[ "Dias a Vencer" ].ToString();

                            lblNombreEmpresa.Text = reader[ "nombre" ].ToString();
                            lblNombreEmpresa.Name = reader[ "nombre" ].ToString();

                            //Logo.Text = reader[ "Stock" ].ToString();

                            lblBarcode.Size = new Size( 148, 70 );
                            lblBarcode.Font = new Font( "Poppins", 12 );
                            lblBarcode.FlatStyle = FlatStyle.Flat;
                            lblBarcode.BackColor = Color.Transparent;
                            lblBarcode.ForeColor = Color.Silver;
                            lblBarcode.Dock = DockStyle.Left;
                            lblBarcode.TextAlign = ContentAlignment.MiddleCenter;
                            lblBarcode.Cursor = Cursors.Hand;

                            lblDescripcion.Size = new Size( 300, 70 );
                            lblDescripcion.Font = new Font( "Poppins", 12 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.IBeam;

                            lblFechaVencimiento.Size = new Size( 265, 70 );
                            lblFechaVencimiento.Font = new Font( "Poppins", 12 );
                            lblFechaVencimiento.FlatStyle = FlatStyle.Flat;
                            lblFechaVencimiento.BackColor = Color.Transparent;
                            lblFechaVencimiento.ForeColor = Color.Silver;
                            lblFechaVencimiento.Dock = DockStyle.Left;
                            lblFechaVencimiento.TextAlign = ContentAlignment.MiddleCenter;
                            lblFechaVencimiento.Cursor = Cursors.IBeam;

                            lblStock.Size = new Size( 176, 70 );
                            lblStock.Font = new Font( "Poppins", 12 );
                            lblStock.FlatStyle = FlatStyle.Flat;
                            lblStock.BackColor = Color.Transparent;
                            lblStock.ForeColor = Color.Silver;
                            lblStock.Dock = DockStyle.Left;
                            lblStock.TextAlign = ContentAlignment.MiddleCenter;
                            lblStock.Cursor = Cursors.IBeam;

                            lblDiasVencidos.Size = new Size( 280, 70 );
                            lblDiasVencidos.Font = new Font( "Poppins", 12 );
                            lblDiasVencidos.FlatStyle = FlatStyle.Flat;
                            lblDiasVencidos.BackColor = Color.Transparent;
                            lblDiasVencidos.ForeColor = Color.Silver;
                            lblDiasVencidos.Dock = DockStyle.Left;
                            lblDiasVencidos.TextAlign = ContentAlignment.MiddleCenter;
                            lblDiasVencidos.Cursor = Cursors.IBeam;

                            lblNombreEmpresa.Size = new Size( 95, 70 );
                            lblNombreEmpresa.Font = new Font( "Poppins", 12 );
                            lblNombreEmpresa.FlatStyle = FlatStyle.Flat;
                            lblNombreEmpresa.BackColor = Color.Transparent;
                            lblNombreEmpresa.ForeColor = Color.Silver;
                            lblNombreEmpresa.Dock = DockStyle.Left;
                            lblNombreEmpresa.TextAlign = ContentAlignment.MiddleCenter;
                            lblNombreEmpresa.Cursor = Cursors.IBeam;
                            lblNombreEmpresa.Visible = false;

                            panel.Size = new Size( 1168, 70 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );

                            panel.Controls.Add( lblNombreEmpresa );
                            panel.Controls.Add( lblDiasVencidos );
                            panel.Controls.Add( lblStock );
                            panel.Controls.Add( lblFechaVencimiento );
                            panel.Controls.Add( lblDescripcion );
                            panel.Controls.Add( lblBarcode );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public DataTable ReporteInventario() {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_KARDEX";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@accion", "rpInventario" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable ReporteInventarioPrueba() {
            //DataTable table = new DataTable();
            try {
                using ( var connection = GetConnection() ) {
                    connection.Open();
                    using ( var cmd = new SqlCommand( "CRUD_KARDEX", connection ) ) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        // Agrega los parámetros requeridos
                        cmd.Parameters.AddWithValue( "@accion", "rpInventario" );
                        // Agrega más parámetros si es necesario
                        var da = new SqlDataAdapter( cmd );
                        
                        da.Fill( table );
                    }
                }
            } catch ( Exception ex ) {
                // Registra el error para diagnóstico
                Console.WriteLine( "Error en ReporteInventarioPrueba(): " + ex.Message );
            }

            // Verifica si el DataTable está vacío y registra un mensaje si lo está
            if ( table.Rows.Count == 0 ) {
                Console.WriteLine( "El DataTable está vacío en ReporteInventarioPrueba()" );
            }
            Console.WriteLine( table );
            return table;
        }



        //public DataTable ReporteInventarioPrueba() {
        //    try {
        //        SqlDataAdapter da;
        //        using ( var connection = GetConnection() ) {
        //            connection.Open();
        //            using ( da = new SqlDataAdapter("CRUD_KARDEX", connection) ) {
        //                da.Fill(table);
        //            }
        //        }
        //        return table;
        //    } catch ( Exception ex) {
        //        return table;
        //    }
        //}
    }
}
