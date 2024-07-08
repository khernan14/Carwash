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
            string emailFormato = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if ( string.IsNullOrWhiteSpace( comprobarEmail ) ) {
                // Si el campo de texto está vacío
                lblMensaje.Visible = false;
                txtCampo.BorderThickness = 1;
                txtCampo.BorderColor = Color.FromArgb( 94, 148, 255 );
                txtCampo.HoverState.BorderColor = Color.FromArgb( 94, 148, 255 );
                txtCampo.FocusedState.BorderColor = Color.FromArgb( 94, 148, 255 );
                return true;
            }

            if ( Regex.IsMatch( comprobarEmail, emailFormato ) ) {
                // Si el email es válido
                lblMensaje.Visible = false;
                SetTextBoxBorderColor( txtCampo, Color.Green );
                return true;
            } else {
                // Si el email no es válido
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Ingrese una dirección de correo electrónico válida";
                SetTextBoxBorderColor( txtCampo, Color.Red );
                return false;
            }
        }

        private void SetTextBoxBorderColor( Guna2TextBox textBox, Color color ) {
            textBox.BorderThickness = 2;
            textBox.BorderColor = color;
            textBox.HoverState.BorderColor = color;
            textBox.FocusedState.BorderColor = color;
        }

        public bool ValidarTexboxsVacios( Guna2TextBox txtControl ) {
            if ( string.IsNullOrWhiteSpace( txtControl.Text ) ) {
                SetTextBoxBorderColor(txtControl, Color.Red);
                txtControl.Focus(); // Vuelve a enfocar el TextBox para que el usuario lo llene.
                return true;
            } else {
                txtControl.BorderThickness = 1;
                txtControl.BorderColor = Color.FromArgb(45, 45, 45);
                txtControl.HoverState.BorderColor = Color.FromArgb( 94, 148, 255 );
                txtControl.FocusedState.BorderColor = Color.FromArgb( 94, 148, 255 );
                return false;
            }
        }

        public void msgError( string msg, Button btnErrorMessage ) {
            btnErrorMessage.Text = "    " + msg;
            btnErrorMessage.Visible = true;
        }
    }
}
