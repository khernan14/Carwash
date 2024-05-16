using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Guna.UI2.WinForms.Suite;
using System.Collections;
using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using static Guna.UI2.WinForms.Suite.Descriptions;
using Label = System.Windows.Forms.Label;

namespace DataAccess.CRUDS {
    public class ProductosDA : ConnectionToSql {
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public DataTable Autocomplete( DataGridView dgDatos, string buscar ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_PRODUCTOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@descripcion", buscar );
                    command.Parameters.AddWithValue( "@accion", "Autocomplete" );
                    SqlDataAdapter da = new SqlDataAdapter( command );
                    da.Fill( table );
                    if ( table != null && table.Rows.Count > 0 ) {
                        dgDatos.DataSource = table;
                        dgDatos.Height = dgDatos.Rows.Count * 40;
                    } else {
                        dgDatos.Height = 0;
                    }
                    command.Dispose();
                    da.Dispose();
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable BuscarMovimientos( DataGridView dgDatos, string buscar ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_PRODUCTOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@buscar", buscar );
                    command.Parameters.AddWithValue( "@accion", "AutocompleteKardex" );
                    SqlDataAdapter da = new SqlDataAdapter( command );
                    da.Fill( table );
                    if ( table != null && table.Rows.Count > 0 ) {
                        dgDatos.DataSource = table;
                        dgDatos.Height = dgDatos.Rows.Count * 40;
                    } else {
                        dgDatos.Height = 0;
                    }
                    command.Dispose();
                    da.Dispose();
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Mostrar() {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_PRODUCTOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@descripcion", "" );
                    command.Parameters.AddWithValue( "@precioCompra", 0 );
                    command.Parameters.AddWithValue( "@precioVenta", 0 );
                    command.Parameters.AddWithValue( "@barcode", "" );
                    command.Parameters.AddWithValue( "@aPartirDe", 0 );
                    command.Parameters.AddWithValue( "@impuesto", "" );
                    command.Parameters.AddWithValue( "@tipoVenta", "" );
                    command.Parameters.AddWithValue( "@categoriaID", 0 );
                    command.Parameters.AddWithValue( "@usaInventario", "" );
                    command.Parameters.AddWithValue( "@stock", 0 );
                    command.Parameters.AddWithValue( "@stockMinimo", 0 );
                    command.Parameters.AddWithValue( "@fechaVencimiento", "" );
                    command.Parameters.AddWithValue( "@PrecioMayoreo", 0 );
                    command.Parameters.AddWithValue( "@fecha", null );
                    command.Parameters.AddWithValue( "@Motivo", "" );
                    command.Parameters.AddWithValue( "@cantidad", 0 );
                    command.Parameters.AddWithValue( "@UsuarioID", 0 );
                    command.Parameters.AddWithValue( "@tipo", "" );
                    command.Parameters.AddWithValue( "@estado", "" );
                    command.Parameters.AddWithValue( "@cajaID", 0 );
                    command.Parameters.AddWithValue( "@accion", "Mostrar" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public bool MostrarProductos( FlowLayoutPanel flPanel, EventHandler myEventLabel, string buscar ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_PRODUCTOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@buscar", buscar );
                    command.Parameters.AddWithValue( "@accion", "Mostrar" );
                    SqlDataReader reader = command.ExecuteReader();
                    if ( reader.HasRows ) {
                        while ( reader.Read() ) {
                            LinkLabel lblProductID = new LinkLabel();
                            Label lblCategoriaID = new Label();
                            LinkLabel lblCodigo = new LinkLabel();
                            LinkLabel lblGrupo = new LinkLabel();
                            LinkLabel lblDescripcion = new LinkLabel();
                            Label lblImpuesto = new Label();
                            Label lblPrecioCompra = new Label();
                            Label lblPrecioMayoreo = new Label();
                            Label lblStockMinimo = new Label();
                            Label lblFechaVencimiento = new Label();
                            Label lblStock = new Label();
                            Label lblPrecioVenta = new Label();
                            Label lblUsaInventario = new Label();
                            Label lblTipoVenta = new Label();
                            Label lblApartirDe = new Label();

                            Guna2Panel panel = new Guna2Panel();
                            //PictureBox image = new PictureBox();

                            lblProductID.Text = reader[ "ID" ].ToString();
                            lblProductID.Name = reader[ "ID" ].ToString();

                            lblCategoriaID.Text = reader[ "categoriaID" ].ToString();
                            lblCategoriaID.Name = reader[ "categoriaID" ].ToString();

                            lblCodigo.Text = reader[ "Codigo" ].ToString();
                            lblCodigo.Name = reader[ "Codigo" ].ToString();

                            lblGrupo.Text = reader[ "Grupo" ].ToString();
                            lblGrupo.Name = reader[ "Grupo" ].ToString();

                            lblDescripcion.Text = reader[ "Descripcion" ].ToString();
                            lblDescripcion.Name = reader[ "Descripcion" ].ToString();

                            lblImpuesto.Text = reader[ "Impuesto" ].ToString();
                            lblImpuesto.Name = reader[ "Impuesto" ].ToString();

                            lblPrecioCompra.Text = reader[ "Precio Compra" ].ToString();
                            lblPrecioCompra.Name = reader[ "Precio Compra" ].ToString();

                            lblPrecioMayoreo.Text = reader[ "Precio Mayoreo" ].ToString();
                            lblPrecioMayoreo.Name = reader[ "Precio Mayoreo" ].ToString();

                            lblStockMinimo.Text = reader[ "Stock Minimo" ].ToString();
                            lblStockMinimo.Name = reader[ "Stock Minimo" ].ToString();

                            lblFechaVencimiento.Text = reader[ "Fecha Vencimiento" ].ToString();
                            lblFechaVencimiento.Name = reader[ "Fecha Vencimiento" ].ToString();

                            lblStock.Text = reader[ "Stock" ].ToString();
                            lblStock.Name = reader[ "Stock" ].ToString();

                            lblPrecioVenta.Text = reader[ "Precio Venta" ].ToString();
                            lblPrecioVenta.Name = reader[ "Precio Venta" ].ToString();

                            lblUsaInventario.Text = reader[ "usaInventario" ].ToString();
                            lblUsaInventario.Name = reader[ "usaInventario" ].ToString();

                            lblTipoVenta.Text = reader[ "tipoVenta" ].ToString();
                            lblTipoVenta.Name = reader[ "tipoVenta" ].ToString();

                            lblApartirDe.Text = reader[ "aPartirDe" ].ToString();
                            lblApartirDe.Name = reader[ "aPartirDe" ].ToString();

                            lblProductID.Size = new Size( 69, 70 );
                            lblProductID.Font = new Font( "Poppins", 12 );
                            lblProductID.FlatStyle = FlatStyle.Flat;
                            lblProductID.BackColor = Color.Transparent;
                            lblProductID.ForeColor = Color.Silver;
                            lblProductID.Dock = DockStyle.Left;
                            lblProductID.TextAlign = ContentAlignment.MiddleCenter;
                            lblProductID.Cursor = Cursors.Hand;
                            lblProductID.LinkColor = Color.Silver;
                            lblProductID.DisabledLinkColor = Color.Silver;
                            lblProductID.LinkBehavior = LinkBehavior.HoverUnderline;
                            lblProductID.ActiveLinkColor = Color.FromArgb( 32, 33, 36 );
                            lblProductID.VisitedLinkColor = Color.Silver;

                            lblCategoriaID.Size = new Size( 69, 72 );
                            lblCategoriaID.Font = new Font( "Poppins", 12 );
                            lblCategoriaID.FlatStyle = FlatStyle.Flat;
                            lblCategoriaID.BackColor = Color.Transparent;
                            lblCategoriaID.ForeColor = Color.Silver;
                            lblCategoriaID.Dock = DockStyle.Left;
                            lblCategoriaID.TextAlign = ContentAlignment.MiddleCenter;
                            lblCategoriaID.Cursor = Cursors.IBeam;
                            lblCategoriaID.Visible = false;

                            lblUsaInventario.Size = new Size( 69, 72 );
                            lblUsaInventario.Font = new Font( "Poppins", 12 );
                            lblUsaInventario.FlatStyle = FlatStyle.Flat;
                            lblUsaInventario.BackColor = Color.Transparent;
                            lblUsaInventario.ForeColor = Color.Silver;
                            lblUsaInventario.Dock = DockStyle.Left;
                            lblUsaInventario.TextAlign = ContentAlignment.MiddleCenter;
                            lblUsaInventario.Cursor = Cursors.IBeam;
                            lblUsaInventario.Visible = false;

                            lblTipoVenta.Size = new Size( 69, 72 );
                            lblTipoVenta.Font = new Font( "Poppins", 12 );
                            lblTipoVenta.FlatStyle = FlatStyle.Flat;
                            lblTipoVenta.BackColor = Color.Transparent;
                            lblTipoVenta.ForeColor = Color.Silver;
                            lblTipoVenta.Dock = DockStyle.Left;
                            lblTipoVenta.TextAlign = ContentAlignment.MiddleCenter;
                            lblTipoVenta.Cursor = Cursors.IBeam;
                            lblTipoVenta.Visible = false;

                            lblCodigo.Size = new Size( 109, 70 );
                            lblCodigo.Font = new Font( "Poppins", 12 );
                            lblCodigo.FlatStyle = FlatStyle.Flat;
                            lblCodigo.BackColor = Color.Transparent;
                            lblCodigo.ForeColor = Color.Silver;
                            lblCodigo.Dock = DockStyle.Left;
                            lblCodigo.TextAlign = ContentAlignment.MiddleCenter;
                            lblCodigo.Cursor = Cursors.Hand;
                            lblCodigo.LinkColor = Color.Silver;
                            lblCodigo.DisabledLinkColor = Color.Silver;
                            lblCodigo.LinkBehavior = LinkBehavior.HoverUnderline;
                            lblCodigo.ActiveLinkColor = Color.FromArgb( 32, 33, 36 );
                            lblCodigo.VisitedLinkColor = Color.Silver;

                            lblGrupo.Size = new Size( 226, 70 );
                            lblGrupo.Font = new Font( "Poppins", 12 );
                            lblGrupo.FlatStyle = FlatStyle.Flat;
                            lblGrupo.BackColor = Color.Transparent;
                            lblGrupo.ForeColor = Color.Silver;
                            lblGrupo.Dock = DockStyle.Left;
                            lblGrupo.TextAlign = ContentAlignment.MiddleCenter;
                            lblGrupo.Cursor = Cursors.Hand;
                            lblGrupo.LinkColor = Color.Silver;
                            lblGrupo.DisabledLinkColor = Color.Silver;
                            lblGrupo.LinkBehavior = LinkBehavior.HoverUnderline;
                            lblGrupo.ActiveLinkColor = Color.FromArgb( 32, 33, 36 );
                            lblGrupo.VisitedLinkColor = Color.Silver;

                            lblDescripcion.Size = new Size( 283, 72 );
                            lblDescripcion.Font = new Font( "Poppins", 12 );
                            lblDescripcion.FlatStyle = FlatStyle.Flat;
                            lblDescripcion.BackColor = Color.Transparent;
                            lblDescripcion.ForeColor = Color.Silver;
                            lblDescripcion.Dock = DockStyle.Left;
                            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
                            lblDescripcion.Cursor = Cursors.Hand;
                            lblDescripcion.LinkColor = Color.Silver;
                            lblDescripcion.DisabledLinkColor = Color.Silver;
                            lblDescripcion.LinkBehavior = LinkBehavior.HoverUnderline;
                            lblDescripcion.ActiveLinkColor = Color.FromArgb( 32, 33, 36 );
                            lblDescripcion.VisitedLinkColor = Color.Silver;

                            lblImpuesto.Size = new Size( 146, 70 );
                            lblImpuesto.Font = new Font( "Poppins", 12 );
                            lblImpuesto.FlatStyle = FlatStyle.Flat;
                            lblImpuesto.BackColor = Color.Transparent;
                            lblImpuesto.ForeColor = Color.Silver;
                            lblImpuesto.Dock = DockStyle.Left;
                            lblImpuesto.TextAlign = ContentAlignment.MiddleCenter;
                            lblImpuesto.Cursor = Cursors.IBeam;

                            lblPrecioCompra.Size = new Size( 146, 70 );
                            lblPrecioCompra.Font = new Font( "Poppins", 12 );
                            lblPrecioCompra.FlatStyle = FlatStyle.Flat;
                            lblPrecioCompra.BackColor = Color.Transparent;
                            lblPrecioCompra.ForeColor = Color.Silver;
                            lblPrecioCompra.Dock = DockStyle.Left;
                            lblPrecioCompra.TextAlign = ContentAlignment.MiddleCenter;
                            lblPrecioCompra.Cursor = Cursors.IBeam;

                            lblPrecioMayoreo.Size = new Size( 146, 70 );
                            lblPrecioMayoreo.Font = new Font( "Poppins", 12 );
                            lblPrecioMayoreo.FlatStyle = FlatStyle.Flat;
                            lblPrecioMayoreo.BackColor = Color.Transparent;
                            lblPrecioMayoreo.ForeColor = Color.Silver;
                            lblPrecioMayoreo.Dock = DockStyle.Left;
                            lblPrecioMayoreo.TextAlign = ContentAlignment.MiddleCenter;
                            lblPrecioMayoreo.Cursor = Cursors.IBeam;

                            lblStockMinimo.Size = new Size( 146, 70 );
                            lblStockMinimo.Font = new Font( "Poppins", 12 );
                            lblStockMinimo.FlatStyle = FlatStyle.Flat;
                            lblStockMinimo.BackColor = Color.Transparent;
                            lblStockMinimo.ForeColor = Color.Silver;
                            lblStockMinimo.Dock = DockStyle.Left;
                            lblStockMinimo.TextAlign = ContentAlignment.MiddleCenter;
                            lblStockMinimo.Cursor = Cursors.IBeam;

                            lblFechaVencimiento.Size = new Size( 327, 70 );
                            lblFechaVencimiento.Font = new Font( "Poppins", 12 );
                            lblFechaVencimiento.FlatStyle = FlatStyle.Flat;
                            lblFechaVencimiento.BackColor = Color.Transparent;
                            lblFechaVencimiento.ForeColor = Color.Silver;
                            lblFechaVencimiento.Dock = DockStyle.Left;
                            lblFechaVencimiento.TextAlign = ContentAlignment.MiddleCenter;
                            lblFechaVencimiento.Cursor = Cursors.IBeam;

                            lblStock.Size = new Size( 130, 70 );
                            lblStock.Font = new Font( "Poppins", 12 );
                            lblStock.FlatStyle = FlatStyle.Flat;
                            lblStock.BackColor = Color.Transparent;
                            lblStock.ForeColor = Color.Silver;
                            lblStock.Dock = DockStyle.Left;
                            lblStock.TextAlign = ContentAlignment.MiddleCenter;
                            lblStock.Cursor = Cursors.IBeam;

                            lblPrecioVenta.Size = new Size( 123, 70 );
                            lblPrecioVenta.Font = new Font( "Poppins", 12 );
                            lblPrecioVenta.FlatStyle = FlatStyle.Flat;
                            lblPrecioVenta.BackColor = Color.Transparent;
                            lblPrecioVenta.ForeColor = Color.Silver;
                            lblPrecioVenta.Dock = DockStyle.Left;
                            lblPrecioVenta.TextAlign = ContentAlignment.MiddleCenter;
                            lblPrecioVenta.Cursor = Cursors.IBeam;

                            lblApartirDe.Size = new Size( 123, 70 );
                            lblApartirDe.Font = new Font( "Poppins", 12 );
                            lblApartirDe.FlatStyle = FlatStyle.Flat;
                            lblApartirDe.BackColor = Color.Transparent;
                            lblApartirDe.ForeColor = Color.Silver;
                            lblApartirDe.Dock = DockStyle.Left;
                            lblApartirDe.TextAlign = ContentAlignment.MiddleCenter;
                            lblApartirDe.Cursor = Cursors.IBeam;

                            panel.Size = new Size( 1854, 70 );
                            panel.Dock = DockStyle.Top;
                            panel.BorderRadius = 15;
                            panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                            //panel.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
                            panel.FillColor = Color.FromArgb( 45, 45, 45 );

                            //ID.Click += new EventHandler( myEventLabel );
                            lblProductID.Click += myEventLabel;
                            lblCodigo.Click += myEventLabel;
                            lblGrupo.Click += myEventLabel;
                            lblDescripcion.Click += myEventLabel;

                            panel.Controls.Add( lblApartirDe );
                            panel.Controls.Add( lblTipoVenta );
                            panel.Controls.Add( lblUsaInventario );
                            panel.Controls.Add( lblCategoriaID );
                            panel.Controls.Add( lblPrecioVenta );
                            panel.Controls.Add( lblStock );
                            panel.Controls.Add( lblFechaVencimiento );
                            panel.Controls.Add( lblStockMinimo );
                            panel.Controls.Add( lblPrecioMayoreo );
                            panel.Controls.Add( lblPrecioCompra );
                            panel.Controls.Add( lblImpuesto );
                            panel.Controls.Add( lblDescripcion );
                            panel.Controls.Add( lblGrupo );
                            panel.Controls.Add( lblCodigo );
                            panel.Controls.Add( lblProductID );
                            flPanel.Controls.Add( panel );
                        }
                        return true;
                    } else return false;
                }
            }
        }

        public DataTable Insertar( string descripcion, int categoriID, string usaInventario, string stock, decimal precioCompra,
                string fechaVencimiento, decimal precioVenta, string barcode, string tipoVenta, string stockMinimo,
                decimal precioMayoreo, decimal aPartirDe, DateTime fecha, string motivo, decimal cantidad, int usuarioID, string tipo, string estado,
                int cajaId
            ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_PRODUCTOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@descripcion", descripcion );
                    command.Parameters.AddWithValue( "@precioCompra", precioCompra );
                    command.Parameters.AddWithValue( "@precioVenta", precioVenta );
                    command.Parameters.AddWithValue( "@barcode", barcode );
                    command.Parameters.AddWithValue( "@aPartirDe", aPartirDe );
                    command.Parameters.AddWithValue( "@impuesto", 0 );
                    command.Parameters.AddWithValue( "@PrecioMayoreo", precioMayoreo );
                    command.Parameters.AddWithValue( "@tipoVenta", tipoVenta );
                    command.Parameters.AddWithValue( "@categoriaID", categoriID );
                    command.Parameters.AddWithValue( "@usaInventario", usaInventario );
                    command.Parameters.AddWithValue( "@stock", stock );
                    command.Parameters.AddWithValue( "@stockMinimo", stockMinimo );
                    command.Parameters.AddWithValue( "@fechaVencimiento", fechaVencimiento );
                    command.Parameters.AddWithValue( "@fecha", fecha );
                    command.Parameters.AddWithValue( "@Motivo", motivo );
                    command.Parameters.AddWithValue( "@cantidad", cantidad );
                    command.Parameters.AddWithValue( "@UsuarioID", usuarioID );
                    command.Parameters.AddWithValue( "@tipo", tipo );
                    command.Parameters.AddWithValue( "@estado", estado );
                    command.Parameters.AddWithValue( "@cajaID", cajaId );
                    command.Parameters.AddWithValue( "@accion", "InsertarProductos" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Actualizar( int productoID, string descripcion, int categoriID, string usaInventario, string stock, decimal precioCompra,
                string fechaVencimiento, decimal precioVenta, string barcode, string tipoVenta, string stockMinimo,
                decimal precioMayoreo, decimal aPartirDe
            ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_PRODUCTOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@productID", productoID );
                    command.Parameters.AddWithValue( "@descripcion", descripcion );
                    command.Parameters.AddWithValue( "@categoriaID", categoriID );
                    command.Parameters.AddWithValue( "@usaInventario", usaInventario );
                    command.Parameters.AddWithValue( "@stock", stock );
                    command.Parameters.AddWithValue( "@precioCompra", precioCompra );
                    command.Parameters.AddWithValue( "@fechaVencimiento", fechaVencimiento );
                    command.Parameters.AddWithValue( "@precioVenta", precioVenta );
                    command.Parameters.AddWithValue( "@barcode", barcode );
                    command.Parameters.AddWithValue( "@tipoVenta", tipoVenta );
                    command.Parameters.AddWithValue( "@impuesto", 0 );
                    command.Parameters.AddWithValue( "@stockMinimo", stockMinimo );
                    command.Parameters.AddWithValue( "@PrecioMayoreo", precioMayoreo );
                    command.Parameters.AddWithValue( "@aPartirDe", aPartirDe );
                    command.Parameters.AddWithValue( "@accion", "ActualizarProductos" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }

        public DataTable Eliminar( int productoID ) {
            using ( var connection = GetConnection() ) {
                connection.Open();
                using ( var command = new SqlCommand() ) {
                    command.Connection = connection;
                    command.CommandText = "CRUD_PRODUCTOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue( "@productID", productoID );
                    command.Parameters.AddWithValue( "@accion", "EliminarProductos" );
                    leer = command.ExecuteReader();
                    table.Load( leer );
                    connection.Close();
                }
            }
            return table;
        }
    }
}
