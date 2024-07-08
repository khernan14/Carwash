using CarWash.Custom_Controls;
using Domain;
using Domain.CRUDS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash.Forms.Configuraciones.AsistenteInstalacion {
    public partial class frmUsuariosAuth : Form {
        Validaciones validacion = new Validaciones();
        UsuariosD usuarios = new UsuariosD();
        LicenciasD licencias = new LicenciasD();
        ConsumidoresD consumidor = new ConsumidoresD();
        GruposD grupos = new GruposD();
        UserModel model = new UserModel();

        public frmUsuariosAuth() {
            InitializeComponent();
        }

        private void frmUsuariosAuth_Load( object sender, EventArgs e ) {

        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message, this );
            alert.ShowDialog();
        }

        private byte[] ConvertirImg() {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picPerfil.Image.Save( ms, System.Drawing.Imaging.ImageFormat.Jpeg );
            return ms.GetBuffer();
        }

        private void btnSiguiente_Click( object sender, EventArgs e ) {
            bool isNombreValid = validacion.ValidarTexboxsVacios( txtNombre );
            bool isUsuarioValid = validacion.ValidarTexboxsVacios( txtUsuario );
            bool isPasswordValid = validacion.ValidarTexboxsVacios( txtPassword );

            if ( !isNombreValid || !isUsuarioValid || !isPasswordValid ) {
                if ( txtPassword.Text == txtConfirmPassword.Text ) {

                    
                    usuarios.Insertar(
                            txtNombre.Text,
                            txtUsuario.Text,
                            txtPassword.Text,
                            ConvertirImg(),
                            "SystemEGG",
                            frmRegistroEmpresa.correo,
                            "Administrador (Control Total)"
                        );
                    licencias.InsertarLicenciaPrueba();
                    consumidor.InsertarConsumidor( "Consumidor Final", "Sin Direccion", "0", "Ninguno", "Consumidor Final", "0", "0.00" );
                    grupos.Insertar("General");
                    model.LoginsControl();
                    ShowToast("SUCCESS", "¡Listo! Recuerda que para iniciar Sesión tu usuario es: " + txtUsuario.Text + "y la contraseña es: " + txtPassword.Text);
                    Dispose();
                    Application.Restart();

                } else ShowToast("ERROR", "Las contraseñas no coinciden");
            } else ShowToast("ERROR", "No puede dejar los campos vacios");
        }
    }
}
