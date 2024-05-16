using CarWash.Custom_Controls;
using Domain;
using Domain.CRUDS;
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

namespace CarWash.Forms.Productos {
    public partial class frmGrupos : Form {
        MetodosListados metodos = new MetodosListados();
        GruposD grupos = new GruposD();

        public bool isActiveData = false;
        bool isEdit = false;
        public frmGrupos() {
            InitializeComponent();
        }

        private void frmGrupos_Load( object sender, EventArgs e ) {
            Cargar();
        }

        public void Cargar() {
            metodos.MostrarGrupos( dgDatos );
        }

        private void MostrarComponentes() {
            dgDatos.Visible = true;
            btnNuevo.Visible = true;
            btnGuardar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void OcultarComponentes() {
            dgDatos.Visible = false;
            btnNuevo.Visible = false;
            btnGuardar.Visible = true;
            btnEliminar.Visible = true;
        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message );
            alert.ShowDialog();
        }

        private void btnNuevo_Click( object sender, EventArgs e ) {
            OcultarComponentes();
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( isEdit == false ) {
                try {
                    grupos.Insertar( txtGrupo.Text );
                    ShowToast( "SUCCESS", "Datos Guardados satisfactoriamente" );
                    MostrarComponentes();
                    metodos.MostrarGrupos( dgDatos );
                    Limpiar();
                } catch ( Exception ex ) {
                    MessageDialog.Show( ex.Message, "Mensaje de Advertencia", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                }
            } else {
                try {
                    grupos.Actualizar( int.Parse( txtCategoriaID.Text ), txtGrupo.Text );
                    ShowToast( "SUCCESS", "Datos Guardados satisfactoriamente" );
                    MostrarComponentes();
                    metodos.MostrarGrupos( dgDatos );
                    Limpiar();
                    isEdit = false;
                } catch ( Exception ex ) {
                    //MessageDialog.Show( ex.Message, "Mensaje de Advertencia", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                    ShowToast( "ERROR", ex.Message );
                }
            }
        }

        private void Limpiar() {
            txtCategoriaID.Clear();
            txtGrupo.Clear();
        }

        private void dgDatos_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            if ( isActiveData == true ) {
                frmProducts frm2 = (frmProducts)Owner;
                frm2.txtGrupoID.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                frm2.txtGrupo.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                frm2.GenerateBarCode();
                isActiveData = false;
                this.Close();
            } else {
                txtCategoriaID.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
                txtGrupo.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
                OcultarComponentes();
            }
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            metodos.BuscarGrupos( dgDatos, txtBuscar.Text );
        }

        private void dgDatos_KeyUp( object sender, KeyEventArgs e ) {

        }

        private void txtGrupo_KeyPress( object sender, KeyPressEventArgs e ) {
            if ( char.IsLower( e.KeyChar ) ) {
                // Convierte la letra a mayúscula
                e.KeyChar = char.ToUpper( e.KeyChar );
            }
        }
    }
}
