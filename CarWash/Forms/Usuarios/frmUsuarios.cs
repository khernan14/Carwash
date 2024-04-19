using CarWash.Custom_Controls;
using Domain;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash {
    public partial class frmUsuarios : Form {

        MetodosListados metodos = new MetodosListados();
        UsuariosD users = new UsuariosD();
        Validaciones validaciones = new Validaciones();

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public Form currentChildForm;
        private bool isEdit = false;

        public frmUsuarios() {
            InitializeComponent();
        }

        private void frmUsuarios_Load( object sender, EventArgs e ) {
            metodos.MostrarUsuarios( dgDatos );
        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message );
            alert.ShowDialog();
        }

        private byte[] ConvertirImg() {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picPerfil.Image.Save( ms, System.Drawing.Imaging.ImageFormat.Jpeg );
            return ms.GetBuffer();
        }

        private MemoryStream ByteImage() {
            byte[] img = (byte[])dgDatos.CurrentRow.Cells[ 4 ].Value;
            MemoryStream ms = new MemoryStream( img );
            return ms;
        }

        private void ImageProfile1_Click( object sender, EventArgs e ) {
            if ( ImageProfile1.Focused ) {
                picPerfil.Image = ImageProfile1.Image;
                lblName.Text = ImageProfile1.Name;
                pnlFotos.Visible = false;
            }

            if ( ImageProfile2.Focused ) {
                picPerfil.Image = ImageProfile2.Image;
                lblName.Text = ImageProfile2.Name;
                pnlFotos.Visible = false;
            }

            if ( ImageProfile3.Focused ) {
                picPerfil.Image = ImageProfile3.Image;
                lblName.Text = ImageProfile3.Name;
                pnlFotos.Visible = false;
            }

            if ( ImageProfile4.Focused ) {
                picPerfil.Image = ImageProfile4.Image;
                lblName.Text = ImageProfile4.Name;
                pnlFotos.Visible = false;
            }

            if ( ImageProfile5.Focused ) {
                picPerfil.Image = ImageProfile5.Image;
                lblName.Text = ImageProfile5.Name;
                pnlFotos.Visible = false;
            }
        }

        private void MostrarPaneles() {
            pnlDataGrid.Visible = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnNuevo.Visible = true;
            btnEliminar.Visible = true;
            txtBuscar.Visible = true;
            btnErrorMessage.Visible = false;
        }

        private void OcultarPaneles() {
            pnlDataGrid.Visible = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnNuevo.Visible = false;
            btnEliminar.Visible = false;
            txtBuscar.Visible = false;
        }

        private void Limpiar() {
            lblCodigo.Text = "Codigo";
            lblName.Text = "Name";
            txtNombres.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            picPerfil.Image = picPerfil.InitialImage;
            txtCorreo.Clear();
            cmbRol.StartIndex = -1;
            btnErrorMessage.Visible = false;
        }

        private void btnNuevo_Click( object sender, EventArgs e ) {
            OcultarPaneles();
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            MostrarPaneles();
            Limpiar();
        }

        private void btnGuardar_Click( object sender, EventArgs e ) {
            if ( validaciones.ValidarEmail(txtCorreo.Text, lblMensajeCorreo, txtCorreo) == true ) {
                if ( isEdit == false ) {
                    try {
                        users.Insertar( txtNombres.Text, txtUsuario.Text, txtPassword.Text, ConvertirImg(), lblName.Text, txtCorreo.Text, cmbRol.Text );
                        MessageDialog.Show( "Datos Guardados satisfactoriamente", "Succesfully", MessageDialogButtons.OK, MessageDialogIcon.Information );
                        metodos.MostrarUsuarios( dgDatos );
                        MostrarPaneles();
                        Limpiar();
                    } catch ( Exception ex ) {
                        MessageDialog.Show(ex.Message, "Mensaje de Advertencia", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                    }
                } else {
                    try {
                        users.Actualizar( int.Parse( lblCodigo.Text ), txtNombres.Text, txtUsuario.Text, txtPassword.Text, ConvertirImg(), lblName.Text, txtCorreo.Text, cmbRol.Text );
                        //MessageDialog.Show( "Datos Guardados satisfactoriamente", "Succesfully", MessageDialogButtons.OK, MessageDialogIcon.Information );
                        ShowToast( "SUCCESS", "Datos guardados con éxito" );
                        metodos.MostrarUsuarios( dgDatos );
                        MostrarPaneles();
                        Limpiar();
                        isEdit = false;
                    } catch ( Exception ex ) {
                        //MessageDialog.Show( ex.Message, "Mensaje de Advertencia", MessageDialogButtons.OK, MessageDialogIcon.Warning );
                        ShowToast( "ERROR", ex.Message );
                    }
                }
            } else {
                validaciones.msgError("Correo electrónico invalido", btnErrorMessage);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
        }

        private void picPerfil_Click( object sender, EventArgs e ) {
            pnlFotos.Visible = true;
        }
        private void dgDatos_CellDoubleClick( object sender, DataGridViewCellEventArgs e ) {
            lblCodigo.Text = dgDatos.CurrentRow.Cells[ 0 ].Value.ToString();
            txtNombres.Text = dgDatos.CurrentRow.Cells[ 1 ].Value.ToString();
            txtUsuario.Text = dgDatos.CurrentRow.Cells[ 2 ].Value.ToString();
            txtPassword.Text = dgDatos.CurrentRow.Cells[ 3 ].Value.ToString();
            picPerfil.Image = Image.FromStream( ByteImage() );
            lblName.Text = dgDatos.CurrentRow.Cells[ 5 ].Value.ToString();
            txtCorreo.Text = dgDatos.CurrentRow.Cells[ 6 ].Value.ToString();
            cmbRol.Text = dgDatos.CurrentRow.Cells[ 7 ].Value.ToString();

            OcultarPaneles();

            isEdit = true;
        }

        private void btnEliminar_Click( object sender, EventArgs e ) {
            var result = MessageDialog.Show( "¿Desea eliminar este registro?", "Advertencia", MessageDialogButtons.YesNo, MessageDialogIcon.Warning );
            var codigo = int.Parse( dgDatos.CurrentRow.Cells[ 0 ].Value.ToString() );
            try {
                if ( result == DialogResult.Yes ) {
                    users.Eliminar( codigo );
                    metodos.MostrarUsuarios( dgDatos );
                    MessageDialog.Show( "Registro Eliminado Correctamente", "Succesfully", MessageDialogButtons.OK, MessageDialogIcon.Information );
                }
            } catch ( Exception ex ) {
                //MessageDialog.Show( ex.Message, "Mensaje de Advertencia", MessageDialogButtons.OK, MessageDialogIcon.Error );
                ShowToast("ERROR", ex.Message);
            }
        }

        private void txtCorreo_TextChanged( object sender, EventArgs e ) {
            validaciones.ValidarEmail( txtCorreo.Text, lblMensajeCorreo, txtCorreo );
        }

        private void btnAddImage_Click( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "";
            ofd.Filter = "Imagenes |*.jpg;*.*png";
            ofd.FilterIndex = 2;
            ofd.Title = "Insertar Imagen";
            DialogResult dr = ofd.ShowDialog();
            if ( dr == DialogResult.OK ) {
                picPerfil.BackgroundImage = null;
                picPerfil.Image = Image.FromFile( ofd.FileName );
                picPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
                lblName.Text = Path.GetFileName( ofd.FileName );
                pnlFotos.Visible = false;
            }
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e ) {
            metodos.Buscar(dgDatos, txtBuscar.Text);
        }

        private void pnlDatos_Click( object sender, EventArgs e ) {
            pnlFotos.Visible = false;
        }
    }
}
