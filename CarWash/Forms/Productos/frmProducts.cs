using Domain.CRUDS;
using Domain.SqlServer;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarWash.Custom_Controls;
using Common;
using Guna.UI2.WinForms;

namespace CarWash.Forms.Productos {
    public partial class frmProducts : Form {
        MetodosListados metodos = new MetodosListados();
        WinAutoCompleteMode autoCompleteMode = new WinAutoCompleteMode();
        ProductosD productos = new ProductosD();

        bool isEdit = false;
        string usaInventario;
        string stock;
        string stockMinimo;
        decimal cantidad;
        string fechaVencimiento;
        string motivo = "Registro Inicial del producto";
        string tipo = "ENTRADA";
        string estado = "CONFIRMADO";
        string tipoVenta;

        public frmProducts() {
            InitializeComponent();
        }

        private void frmProducts_Load( object sender, EventArgs e ) {
            //metodos.MostrarProductos( dgDatos );
            //metodos.MostrarAutocomplete( dgDescripcion );
            productos.MostrarProductos( pnlUsuarios, myEventLabel, txtBuscar.Text );
            UsaInventario();
            txtNombreProducto.AutoCompleteCustomSource = autoCompleteMode.LoadAutocomplete();
            txtNombreProducto.AutoCompleteMode = AutoCompleteMode.Append;
            txtNombreProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void GenerateBarCode() {
            Random rdn = new Random();
            string contraseniaAleatoria = string.Empty;
            string caracteres = "ABCDEFGHIJKLMNOPQRSTVWXYZ1234567890";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 4;

            for ( int i = 0; i < longitudContrasenia; i++ ) {
                letra = caracteres[ rdn.Next( longitud ) ];
                contraseniaAleatoria += letra.ToString();
            }

            string cadena = txtGrupo.Text;
            string[] palabra;
            String espacio = " ";
            palabra = cadena.Split( Convert.ToChar( espacio ) );
            try {
                txtBarcode.Text = palabra[ 0 ].Substring( 0, 2 ) + contraseniaAleatoria;
            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        private void myEventLabel( object sender, EventArgs e ) {
            // Verificar si el objeto que desencadenó el evento es un label
            if ( sender is Label ) {
                // Obtener el label que desencadenó el evento
                Label labelClicked = (Label)sender;

                // Obtener el panel que contiene el label clickeado
                Panel panel = (Panel)labelClicked.Parent;

                // Crear una lista para almacenar los textos de los labels dentro del panel
                List<string> labelTexts = new List<string>();

                // Recorrer los controles dentro del panel en el mismo orden en que fueron agregados
                for ( int i = panel.Controls.Count - 1; i >= 0; i-- ) {
                    Control control = panel.Controls[ i ];
                    if ( control is Label ) {
                        // Obtener el texto del label y agregarlo a la lista
                        labelTexts.Add( ((Label)control).Text );
                    } else if ( control is Guna2CirclePictureBox ) {
                        PictureBox pictureBox = (PictureBox)control;
                        // Obtener la imagen del PictureBox
                        //picPerfil.Image = pictureBox.Image;
                    }
                }

                isEdit = true;
                txtProductID.Text = labelTexts[ 0 ];
                txtBarcode.Text = labelTexts[ 1 ];
                txtGrupo.Text = labelTexts[ 2 ];
                txtNombreProducto.Text = labelTexts[ 3 ];
                txtPrecioCosto.Text = labelTexts[ 5 ];
                txtPrecioMayoreo.Text = labelTexts[ 6 ];
                txtStockMinima.Text = labelTexts[ 7 ];
                //dtpFechaVencimiento.Text = labelTexts[ 8 ];
                txtStock.Text = labelTexts[ 9 ];
                txtPrecioVenta.Text = labelTexts[ 10 ];
                txtGrupoID.Text = labelTexts[ 11 ];
                txtUnidadesMayoreo.Text = labelTexts[ 14 ];

                if ( labelTexts[ 13 ] == "Unidad" ) {
                    rbUnidad.Checked = true;
                } else if ( labelTexts[ 13 ] == "Granel" ) {
                    rbGranel.Checked = true;
                }

                if ( labelTexts[ 12 ] == "SI" ) {
                    swtUseInventory.Checked = true;
                } else {
                    swtUseInventory.Checked = false;
                }
                OcultarPaneles();
            }
        }

        private void UsaInventario() {
            if ( swtUseInventory.Checked ) {
                pnlDatosInventario.Visible = true;
            } else {
                pnlDatosInventario.Visible = false;
            }
        }

        private void Inventario() {
            if ( swtUseInventory.Checked ) {
                pnlDatosInventario.Visible = true;
                usaInventario = "SI";
                stock = txtStock.Text;
                if ( decimal.TryParse( txtStock.Text, out cantidad ) ) {
                    stockMinimo = txtStockMinima.Text;
                    cantidad = decimal.Parse( txtStock.Text );
                    if ( chkNoAplica.Checked ) {
                        fechaVencimiento = "No Aplica";
                    } else {
                        fechaVencimiento = dtpFechaVencimiento.Value.ToString();
                    }
                } else {
                    // El texto no es válido para convertir a decimal
                    // Aquí puedes manejar el caso según sea necesario, como mostrar un mensaje de error o establecer un valor predeterminado para cantidad
                    txtStock.Text = "0.00";
                }
            }
            if ( swtUseInventory.Checked == false ) {
                pnlDatosInventario.Visible = false;
                usaInventario = "NO";
                stock = "Ilimitado";
                cantidad = 0;
                stockMinimo = "0";
                fechaVencimiento = "Sin definir";
            }
        }

        private void AbrirForm() {
            Form formBG = new Form();
            using ( frmGrupos frm = new frmGrupos() ) {
                formBG.StartPosition = FormStartPosition.Manual;
                formBG.FormBorderStyle = FormBorderStyle.None;
                formBG.Opacity = .70d;
                formBG.BackColor = Color.Black;
                formBG.WindowState = FormWindowState.Maximized;
                formBG.TopMost = false;
                formBG.Location = this.Location;
                formBG.ShowInTaskbar = false;
                formBG.Show();

                frm.Owner = formBG;
                frm.txtBuscar.Text = txtGrupo.Text;
                frm.isActiveData = true;
                AddOwnedForm( frm );
                frm.ShowDialog();

                formBG.Dispose();
            }
        }

        private void Limpiar() {
            txtNombreProducto.Clear();
            txtProductID.Clear();
            txtGanancias.Clear();
            txtPrecioVenta.Clear();
            txtPrecioCosto.Clear();
            txtUnidadesMayoreo.Clear();
            txtGrupoID.Clear();
            txtGrupo.Clear();
            txtBarcode.Clear();
            txtStock.Clear();
            txtStockMinima.Clear();
            swtUseInventory.Checked = true;
        }

        private void MostrarPaneles() {
            pnlDataGrid.Visible = true;
            pnlDatos.Visible = false;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnEliminar.Visible = false;
            btnNuevo.Visible = true;
            txtBuscar.Visible = true;
        }

        private void OcultarPaneles() {
            pnlDataGrid.Visible = false;
            pnlDatos.Visible = true;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnEliminar.Visible = true;
            btnNuevo.Visible = false;
            txtBuscar.Visible = false;
        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message, this );
            alert.ShowDialog();
        }

        private void chkNoAplica_CheckedChanged( object sender, EventArgs e ) {
            if ( chkNoAplica.Checked == true ) {
                dtpFechaVencimiento.Enabled = false;
            } else {
                dtpFechaVencimiento.Enabled = true;
            }
        }

        private void rbUnidad_CheckedChanged( object sender, EventArgs e ) {
            if ( rbUnidad.Checked ) {
                tipoVenta = "Unidad";
                lblTipoVenta.Text = "Unidades";
            }
        }

        private void rbGranel_CheckedChanged( object sender, EventArgs e ) {
            if ( rbGranel.Checked ) {
                tipoVenta = "Granel";
                lblTipoVenta.Text = "Libras";
            }
        }

        private void btnNuevo_Click( object sender, EventArgs e ) {
            OcultarPaneles();
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            MostrarPaneles();
            Limpiar();
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( isEdit == false ) {
                try {
                    Inventario();
                    int categoriaID = int.Parse( txtGrupoID.Text );
                    decimal precio = decimal.Parse( txtPrecioCosto.Text );
                    decimal precioVenta = decimal.Parse( txtPrecioVenta.Text );
                    decimal aPartirDe = decimal.Parse( txtUnidadesMayoreo.Text );
                    //decimal cantidad = decimal.Parse( stock );
                    decimal precioMayoreo = decimal.Parse( txtPrecioMayoreo.Text );
                    int usuario = int.Parse( UserLoginCache.userID.ToString() );
                    int caja = int.Parse( UserLoginCache.cajaID.ToString() );

                    productos.Insertar( txtNombreProducto.Text, categoriaID, usaInventario, stock, precio, fechaVencimiento,
                        precioVenta, txtBarcode.Text, tipoVenta, stockMinimo, precioMayoreo, aPartirDe, DateTime.Today, motivo,
                        cantidad, usuario, tipo, estado, caja );
                    ShowToast( "SUCCESS", "Datos Guardados satisfactoriamente" );
                    MostrarPaneles();
                    Limpiar();
                    pnlUsuarios.Controls.Clear();
                    productos.MostrarProductos( pnlUsuarios, myEventLabel, txtBuscar.Text );
                } catch ( Exception ex ) {
                    ShowToast( "ERROR", ex.Message );
                }
            } else {
                try {
                    Inventario();
                    int productoID = int.Parse( txtProductID.Text );
                    int categoriaID = int.Parse( txtGrupoID.Text );
                    decimal precio = decimal.Parse( txtPrecioCosto.Text );
                    decimal precioVenta = decimal.Parse( txtPrecioVenta.Text );
                    decimal aPartirDe = decimal.Parse( txtUnidadesMayoreo.Text );
                    //decimal cantidad = decimal.Parse( stock );
                    decimal precioMayoreo = decimal.Parse( txtPrecioMayoreo.Text );
                    int usuario = int.Parse( UserLoginCache.userID.ToString() );
                    int caja = int.Parse( UserLoginCache.cajaID.ToString() );

                    productos.Actualizar( productoID, txtNombreProducto.Text, categoriaID, usaInventario, stock, precio, fechaVencimiento,
                        precioVenta, txtBarcode.Text, tipoVenta, stockMinimo, precioMayoreo, aPartirDe );
                    ShowToast( "SUCCESS", "Datos Guardados satisfactoriamente" );
                    MostrarPaneles();
                    Limpiar();
                    pnlUsuarios.Controls.Clear();
                    productos.MostrarProductos( pnlUsuarios, myEventLabel, txtBuscar.Text );
                    isEdit = false;
                } catch ( Exception ex ) {
                    ShowToast( "ERROR", ex.Message );
                }
            }
        }

        private void btnEliminar_Click( object sender, EventArgs e ) {
            var result = MessageDialog.Show( "¿Esta seguro de eliminar este producto?", "Mensaje de Advertencia", MessageDialogButtons.YesNo, MessageDialogIcon.Warning );

            if ( result == DialogResult.Yes ) {
                int productoID = int.Parse( txtProductID.Text );
                productos.Eliminar( productoID );
                ShowToast( "SUCCESS", "Datos Eliminados satisfactoriamente" );
                MostrarPaneles();
                Limpiar();
                pnlUsuarios.Controls.Clear();
                productos.MostrarProductos( pnlUsuarios, myEventLabel, txtBuscar.Text );
            }
        }

        private void txtGrupo_TextChanged( object sender, EventArgs e ) {
            metodos.BuscarGrupos( dgGrupos, txtGrupo.Text );
        }

        private void txtGrupo_IconRightClick( object sender, EventArgs e ) {
            AbrirForm();
        }

        private void txtGrupo_KeyUp( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Enter ) {
                if ( dgGrupos.Rows.Count > 0 ) {
                    var gruposID = dgGrupos.CurrentRow.Cells[ 0 ].Value.ToString();
                    var grupos = dgGrupos.CurrentRow.Cells[ 1 ].Value.ToString();
                    if ( grupos == txtGrupo.Text ) {
                        txtGrupo.Text = grupos;
                        txtGrupoID.Text = gruposID;
                        GenerateBarCode();
                    } else {
                        AbrirForm();
                    }
                } else {
                    AbrirForm();
                }
            }
        }

        private void txtNombreProducto_TextChanged( object sender, EventArgs e ) {

            if ( txtNombreProducto.TextLength >= 1 ) {
                metodos.Autocomplete( dgDescripcion, txtNombreProducto.Text );
            } else if ( txtNombreProducto.TextLength <= 0 ) {
                dgDescripcion.Height = 0;
            }
        }

        private void txtNombreProducto_KeyUp( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Enter ) {
                dgDescripcion.Height = 0;
            }
        }

        private void dgDescripcion_CellClick( object sender, DataGridViewCellEventArgs e ) {
            DataGridViewRow row = this.dgDescripcion.Rows[ e.RowIndex ];
            txtNombreProducto.Text = row.Cells[ "result" ].Value.ToString();
            dgDescripcion.Height = 0;
        }

        private void swtUseInventory_CheckedChanged( object sender, EventArgs e ) {
            UsaInventario();
        }

        private void btnGenerarBarcode_Click( object sender, EventArgs e ) {
            GenerateBarCode();
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            pnlUsuarios.Controls.Clear();
            productos.MostrarProductos( pnlUsuarios, myEventLabel, txtBuscar.Text );
        }

        private void txtBuscar_KeyUp( object sender, KeyEventArgs e ) {

        }
    }
}
