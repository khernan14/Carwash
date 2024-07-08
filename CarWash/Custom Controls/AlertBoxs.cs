using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash.Custom_Controls {
    public partial class AlertBoxs : Form {
        int toastX, toastY;
        Form mainForm;

        public AlertBoxs(string type, string message, Form mainForm) {
            InitializeComponent();
            this.mainForm = mainForm;
            lblType.Text = type;
            lblMessage.Text = message;
            if (lblMessage.Text.Length >= 30) {
                this.Width = (lblMessage.Width + lblMessage.Text.Length) + 35;
            }

            switch ( type ) {
                case "SUCCESS":
                    pnlBorder.FillColor = Color.FromArgb( 57, 155, 53 );
                    picIcon.Image = Properties.Resources.success;
                    break;
                case "ERROR":
                    pnlBorder.FillColor = Color.FromArgb( 227, 50, 45 );
                    picIcon.Image = Properties.Resources.Error;
                    break;
                case "INFORMATION":
                    pnlBorder.FillColor = Color.FromArgb( 18, 136, 191 );
                    picIcon.Image = Properties.Resources.information;
                    break;
                case "WARNING":
                    pnlBorder.FillColor = Color.FromArgb( 245, 171, 35 );
                    picIcon.Image = Properties.Resources.warning;
                    break;
            }
        }

        private void AlertBoxs_Load( object sender, EventArgs e ) {
            Position();
        }

        private void Position() {
            // Obtener la posición del formulario principal
            int mainFormX = mainForm.Location.X;
            int mainFormY = mainForm.Location.Y;
            int mainFormWidth = mainForm.Width;

            // Calcular la posición X para centrar el cuadro de alerta en el formulario principal
            toastX = mainFormX + (mainFormWidth - this.Width) / 2;

            // Fijar la posición Y en la parte superior del formulario principal
            toastY = mainFormY + 10; // Justo en el borde superior del formulario principal

            this.Location = new Point( toastX, toastY );
        }

        int y = 100;
        private void toastHide_Tick( object sender, EventArgs e ) {
            y--;
            if ( y <= 0 ) {
                toastY -= 1;
                this.Location = new Point( toastX, toastY -= 10 );
                if ( toastY < mainForm.Location.Y - this.Height ) // La ventana se oculta completamente por encima del formulario principal
                {
                    toastHide.Stop();
                    y = 100;
                    this.Close();
                }
            }
        }

        private void toastTimer_Tick( object sender, EventArgs e ) {
            //toastY -= 10;
            //this.Location = new Point( toastX, toastY );
            //if ( toastY <= 10 ) // Mantener la notificación en la parte superior
            //{
            //}
                toastTimer.Stop();
                toastHide.Start();
        }
 
    }
}
