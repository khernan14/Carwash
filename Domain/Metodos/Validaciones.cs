using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Button = System.Windows.Forms.Button;

namespace Domain {
    public class Validaciones {
        public bool ValidarEmail( string comprobarEmail, Guna2HtmlLabel lblMensaje, Guna2TextBox txtCampo ) {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if ( Regex.IsMatch( comprobarEmail, emailFormato ) ) {
                if ( Regex.Replace( comprobarEmail, emailFormato, String.Empty ).Length == 0 ) {
                    lblMensaje.Visible = false;
                    txtCampo.BorderThickness = 2;
                    txtCampo.BorderColor = Color.Green;
                    txtCampo.HoverState.BorderColor = Color.Green;
                    txtCampo.FocusedState.BorderColor = Color.Green;
                    return true;
                } else {
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Ingrese una dirección de correo electrónico válido";
                    txtCampo.BorderThickness = 2;
                    txtCampo.BorderColor = Color.Red;
                    txtCampo.HoverState.BorderColor = Color.Red;
                    txtCampo.FocusedState.BorderColor = Color.Red;
                    return false;
                }
            } else if ( txtCampo.Text == "" ) {
                lblMensaje.Visible = false;
                txtCampo.BorderThickness = 1;
                txtCampo.BorderColor = Color.FromArgb( 94, 148, 255 );
                txtCampo.HoverState.BorderColor = Color.FromArgb( 94, 148, 255 );
                txtCampo.FocusedState.BorderColor = Color.FromArgb( 94, 148, 255 );
                return true;
            } else {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Ingrese una dirección de correo electrónico válido";
                txtCampo.BorderThickness = 2;
                txtCampo.BorderColor = Color.Red;
                txtCampo.HoverState.BorderColor = Color.Red;
                txtCampo.FocusedState.BorderColor = Color.Red;
                return false;
            }
        }

        public void msgError( string msg, Button btnErrorMessage ) {
            btnErrorMessage.Text = "    " + msg;
            btnErrorMessage.Visible = true;
        }
    }
}
