using CarWash.Reportes.Kardex.ReportInventarios;
using Domain;
using Domain.CRUDS;
using Domain.SqlServer;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash.Forms.Inventario {
    public partial class frmKardex : Form {
        MetodosListados metodos = new MetodosListados();
        WinAutoCompleteMode autoCompleteMode = new WinAutoCompleteMode();
        KardexD kardex = new KardexD();

        public frmKardex() {
            InitializeComponent();
        }

        private void frmKardex_Load( object sender, EventArgs e ) {
            txtBuscar.AutoCompleteCustomSource = autoCompleteMode.LoadAutocomplete();
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Append;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            metodos.ListarUsuarios( cmbUsuarios );
            kardex.StockMinimo( pnlStockMinimo );
            kardex.Cantidades(lblCantidadProductos, lblCostoInventario);
        }

        private void Filtrar() {
            pnlDatos.Controls.Clear();
            pnlAcumulados.Controls.Clear();
            kardex.FiltrarKardex( pnlDatos, dtpFecha.Value, cmbTipo.Text, int.Parse( cmbUsuarios.SelectedValue.ToString() ) );
            kardex.FiltrarKardexAcumulados( pnlAcumulados, dtpFecha.Value, cmbTipo.Text, int.Parse( cmbUsuarios.SelectedValue.ToString() ) );
        }

        private void BuscarMovimientos() {
            txtBuscar.Text = dgDescripcion.CurrentRow.Cells[ 1 ].Value.ToString();
            txtID.Text = dgDescripcion.CurrentRow.Cells[ 0 ].Value.ToString();
            pnlDatos.Controls.Clear();
            kardex.MostrarMovimientos( pnlDatos, int.Parse( txtID.Text ) );
            dgDescripcion.Height = 0;
            txtBuscar.Clear();
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            if ( txtBuscar.TextLength >= 1 ) {
                metodos.BuscarMovimientos( dgDescripcion, txtBuscar.Text );
            } else if ( txtBuscar.TextLength <= 0 ) {
                dgDescripcion.Height = 0;
            }
        }

        private void btnFiltrar_Click_1( object sender, EventArgs e ) {
            if ( btnFiltrar.Checked ) {
                pnlFiltros.Visible = true;
                pnlAcumulado.Visible = true;
                pnlDatos.Controls.Clear();
                pnlAcumulados.Controls.Clear();
            }
            if ( btnFiltrar.Checked == false ) {
                pnlFiltros.Visible = false;
                pnlAcumulado.Visible = false;
                pnlDatos.Controls.Clear();
                pnlAcumulados.Controls.Clear();
            }
        }

        private void dgDescripcion_CellClick( object sender, DataGridViewCellEventArgs e ) {
            BuscarMovimientos();
        }

        private void txtBuscar_KeyUp( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Enter ) {
                BuscarMovimientos();
            }
        }

        private void cmbTipo_SelectedIndexChanged( object sender, EventArgs e ) {
            if ( pnlFiltros.Visible == true ) {
                Filtrar();
            }
        }

        private void cmbUsuarios_SelectedIndexChanged( object sender, EventArgs e ) {
            if ( pnlFiltros.Visible == true ) {
                Filtrar();
            }
        }

        private void dtpFecha_ValueChanged_1( object sender, EventArgs e ) {
            if ( pnlFiltros.Visible == true ) {
                Filtrar();
            }
        }

        private void txtBuscarInventario_TextChanged( object sender, EventArgs e ) {
            pnlInventarios.Controls.Clear();
            kardex.MostrarInventarios(pnlInventarios, txtBuscarInventario.Text);
        }

        private void btnMostrarTodo_Click( object sender, EventArgs e ) {
            txtBuscarInventario.Clear();
            kardex.MostrarInventarios( pnlInventarios, txtBuscarInventario.Text );
        }

        private void txtBuscarProductosV_TextChanged( object sender, EventArgs e ) {
            pnlProductosVencidos.Controls.Clear();
            kardex.ProductosVencidos( pnlProductosVencidos, txtBuscarProductosV.Text );

            if ( txtBuscarProductosV.Text == "" ) {
                pnlProductosVencidos.Controls.Clear();
            }
        }

        private void rbMenor30_CheckedChanged( object sender, EventArgs e ) {
            txtBuscarProductosV.Clear();
            pnlProductosVencidos.Controls.Clear();
            kardex.ProductosVencidosMenor30( pnlProductosVencidos );
            lblDiasVencidos.Text = "DIAS A VENCER";
        }

        private void rbVencidos_CheckedChanged( object sender, EventArgs e ) {
            txtBuscarProductosV.Clear();
            pnlProductosVencidos.Controls.Clear();
            kardex.ProductosVencidos(pnlProductosVencidos, txtBuscar.Text);
            lblDiasVencidos.Text = "DIAS VENCIDOS";
        }
        
        private void txtBuscarProductosV_Click( object sender, EventArgs e ) {
            rbMenor30.Checked = false;
            rbVencidos.Checked = false;
            pnlProductosVencidos.Controls.Clear();
        }
    }
}
