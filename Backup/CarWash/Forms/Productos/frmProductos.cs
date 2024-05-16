using CarWash.Custom_Controls;
using Common;
using Domain;
using Domain.CRUDS;
using Domain.SqlServer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace CarWash.Forms.Productos {
    public partial class frmProductos : Form {
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

        public frmProductos() {
            InitializeComponent();
        }

        private void frmProductos_Load( object sender, EventArgs e ) {
            metodos.MostrarProductos( dgDatos );
            //metodos.MostrarAutocomplete( dgDescripcion );
            UsaInventario();
            txtNombreProducto.AutoCompleteCustomSource = autoCompleteMode.LoadAutocomplete();
            txtNombreProducto.AutoCompleteMode = AutoCompleteMode.Append;
            txtNombreProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void UsaInventario() {
            if ( swtUseInventory.Checked ) {
                pnlDatosInventario.Visible = true;
            } else {
                pnlDatosInventario.Visible = false;
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
                AddOwnedForm( frm );
                frm.ShowDialog();

                formBG.Dispose();
            }
        }

        private void MostrarPaneles() {
            dgDatos.Visible = true;
            pnlDatos.Visible = false;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnNuevo.Visible = true;
            btnEliminar.Visible = true;
            txtBuscar.Visible = true;
        }

        private void OcultarPaneles() {
            dgDatos.Visible = false;
            pnlDatos.Visible = true;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnNuevo.Visible = false;
            btnEliminar.Visible = false;
            txtBuscar.Visible = false;
        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message );
            alert.ShowDialog();
        }

        private void btnNuevo_Click( object sender, EventArgs e ) {
            OcultarPaneles();
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
                    } else {
                        AbrirForm();
                    }
                } else {
                    AbrirForm();
                }
            }
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            MostrarPaneles();
        }

        private void txtNombreProducto_TextChanged( object sender, EventArgs e ) {
            
            if ( txtNombreProducto.TextLength >= 1 ) {
                metodos.Autocomplete( dgDescripcion, txtNombreProducto.Text );
            } else if ( txtNombreProducto.TextLength <= 0 ) {
                dgDescripcion.Height = 0;
            }
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( isEdit == false ) {
                try {
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
                    metodos.MostrarProductos( dgDatos );
                } catch ( Exception ex ) {
                    MessageDialog.Show( ex.Message, "Mensaje de Advertencia", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                }
            }
            //else {
            //    try {
            //        users.Actualizar( int.Parse( lblCodigo.Text ), txtNombres.Text, txtUsuario.Text, txtPassword.Text, ConvertirImg(), lblName.Text, txtCorreo.Text, cmbRol.Text );
            //        //MessageDialog.Show( "Datos Guardados satisfactoriamente", "Succesfully", MessageDialogButtons.OK, MessageDialogIcon.Information );
            //        ShowToast( "SUCCESS", "Datos guardados con éxito" );
            //        metodos.MostrarUsuarios( dgDatos );
            //        MostrarPaneles();
            //        Limpiar();
            //        isEdit = false;
            //    } catch ( Exception ex ) {
            //        MessageDialog.Show( ex.Message, "Mensaje de Advertencia", MessageDialogButtons.OK, MessageDialogIcon.Warning );
            //        ShowToast( "ERROR", ex.Message );
            //    }
            //}
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
            }
        }

        private void rbGranel_CheckedChanged( object sender, EventArgs e ) {
            if ( rbGranel.Checked ) {
                tipoVenta = "Granel";
            }
        }

        private void swtUseInventory_CheckedChanged( object sender, EventArgs e ) {
            if ( swtUseInventory.Checked ) {
                pnlDatosInventario.Visible = true;
                usaInventario = "SI";
                stock = txtStock.Text;
                cantidad = decimal.Parse( txtStock.Text );
                stockMinimo = txtStockMinima.Text;
                if ( chkNoAplica.Checked ) {
                    fechaVencimiento = "No Aplica";
                } else {
                    fechaVencimiento = dtpFechaVencimiento.Text;
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

        private void btnGenerarBarcode_Click( object sender, EventArgs e ) {
            
        }

        private void dgDescripcion_CellClick( object sender, DataGridViewCellEventArgs e ) {
            DataGridViewRow row = this.dgDescripcion.Rows[e.RowIndex];
            txtNombreProducto.Text = row.Cells["result"].Value.ToString();
            dgDescripcion.Height = 0;
        }

        private void txtNombreProducto_KeyUp( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Enter ) {
                dgDescripcion.Height = 0;
            }
        }
    }
}
