using CarWash.Custom_Controls;
using CarWash.Forms.Cajas;
using Common;
using Domain;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Domain.CRUDS;

namespace CarWash.Forms {
    public partial class frmLogin : Form {
        UserModel model = new UserModel();
        CajasD cajas = new CajasD();
        WaitFormFunc wait = new WaitFormFunc();

        public frmLogin() {
            InitializeComponent();
        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message );
            alert.ShowDialog();
        }

        private void myEventLabel( object sender, EventArgs e ) {
            lblLogin.Text = ((Label)sender).Text;
            pnlCodigo.Visible = true;
            pnlUsuarios.Visible = false;
            txtPassword.Focus();
        }

        private void myEventImage( object sender, EventArgs e ) {
            lblLogin.Text = ((PictureBox)sender).Tag.ToString();
            pnlCodigo.Visible = true;
            pnlUsuarios.Visible = false;
            txtPassword.Focus();
        }

        private void frmLogin_Load( object sender, EventArgs e ) {
            model.CargarUsuarios( pnlUsuarios, myEventLabel, myEventImage );
            escalar_paneles();
            timer1.Start();
        }

        void escalar_paneles() {
            pnlUsuarios.Size = new System.Drawing.Size( 1142, 767 );
            pnlCodigo.Size = new System.Drawing.Size( 437, 801 );
            pnlRecoverPass.Size = new System.Drawing.Size( 682, 324 );
            pnlCodigo.Location = new Point( (Width - pnlCodigo.Width) / 2, (Height - pnlCodigo.Height) / 2 );
            pnlUsuarios.Location = new Point( (Width - pnlUsuarios.Width) / 2, (Height - pnlUsuarios.Height) / 2 );
            pnlRecoverPass.Location = new Point( (Width - pnlRecoverPass.Width) / 2, (Height - pnlRecoverPass.Height) / 2 );
        }

        private void txtPassword_TextChanged( object sender, EventArgs e ) {
            var resultado = model.isLoginUser( lblLogin.Text, txtPassword.Text );
            if ( resultado == true ) {
                try {
                    var result = model.isOpenedBox( lblSerialPC.Text, int.Parse( UserLoginCache.userID.ToString() ) );
                    if ( result == false && UserLoginCache.cargo != Common.Cache.Cargos.Ventas ) {
                        
                        //wait.Show( this );
                        int usuarioID = int.Parse( UserLoginCache.userID.ToString() );
                        int cajaID = int.Parse( UserLoginCache.cajaID.ToString() );
                        cajas.Insertar( usuarioID, cajaID );
                        frmAperturaCaja frm = new frmAperturaCaja();
                        this.Hide();
                        frm.ShowDialog();
                        //wait.Close();
                    } else {
                        //wait.Show( this );
                        frmPrincipalVentas frm2 = new frmPrincipalVentas();
                        this.Hide();
                        //wait.Close();
                        frm2.ShowDialog();
                    }
                } catch ( Exception ex ) {
                    ShowToast( "ERROR", ex.Message );
                }
            } else {
                if ( txtPassword.Text.Length > 4 ) {
                    ShowToast( "ERROR", "Pin Incorrecto" );
                }
            }
        }

        private void btnRestaurar_Click( object sender, EventArgs e ) {
            //var user = new UserModel();
            var result = model.recoverPassword( txtCorreo.Text );
            this.TopMost = false;
            MessageDialog.Show( result, "Tecnasa Honduras", MessageDialogButtons.OK, MessageDialogIcon.Information );
            pnlRecoverPass.Visible = false;
            txtCorreo.Clear();
            pnlUsuarios.Visible = true;
        }

        private void btnOlvidarContra_Click( object sender, EventArgs e ) {
            pnlRecoverPass.Visible = true;
            pnlRecoverPass.Location = new Point( 165, 130 );
            pnlUsuarios.Visible = false;
        }

        private void lblCambiarUser_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            pnlUsuarios.Visible = true;
            pnlCodigo.Visible = false;
        }

        private void timer1_Tick( object sender, EventArgs e ) {
            timer1.Stop();
            try {
                ManagementObjectSearcher MOS = new ManagementObjectSearcher( "SELECT * FROM Win32_BaseBoard" );
                foreach ( ManagementObject getSerial in MOS.Get() ) {
                    lblSerialPC.Text = getSerial.Properties[ "SerialNumber" ].Value.ToString();
                    model.showBoxSerial( lblSerialPC.Text );
                }
            } catch ( Exception ex ) {
                ShowToast( "ERROR", ex.Message );
            }
        }

        public static string Mid( string param, int startIndex ) {
            string result = param.Substring( startIndex );
            return result;
        }

        public void Teclado() {
            txtPassword.Focus();
            txtPassword.SelectionStart = txtPassword.Text.Length;
            txtPassword.SelectionLength = 0;
        }

        private void btn2_Click( object sender, EventArgs e ) {
            if ( btn0.Focused ) {
                txtPassword.Text += "0";
                Teclado();
            } else if ( btn1.Focused ) {
                txtPassword.Text += "1";
                Teclado();
            } else if ( btn2.Focused ) {
                txtPassword.Text += "2";
                Teclado();
            } else if ( btn3.Focused ) {
                txtPassword.Text += "3";
                Teclado();
            } else if ( btn4.Focused ) {
                txtPassword.Text += "4";
                Teclado();
            } else if ( btn5.Focused ) {
                txtPassword.Text += "5";
                Teclado();
            } else if ( btn6.Focused ) {
                txtPassword.Text += "6";
                Teclado();
            } else if ( btn7.Focused ) {
                txtPassword.Text += "7";
                Teclado();
            } else if ( btn8.Focused ) {
                txtPassword.Text += "8";
                Teclado();
            } else if ( btn9.Focused ) {
                txtPassword.Text += "9";
                Teclado();
            } else if ( btnBorrarTodo.Focused ) {
                txtPassword.Clear();
            }
        }

        private void btnBorrar_Click( object sender, EventArgs e ) {
            if ( txtPassword.Text.Length > 0 ) {
                txtPassword.Text = txtPassword.Text.Remove( txtPassword.Text.Length - 1 );
            }
        }

        private void btnBorrar_KeyPress( object sender, KeyPressEventArgs e ) {

        }
    }
}
