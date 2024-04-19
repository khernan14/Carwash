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

        public AlertBoxs(string type, string message) {
            InitializeComponent();
            lblType.Text = type;
            lblMessage.Text = message;
            if (lblMessage.Text.Length >= 30) {
                this.Width = (lblMessage.Width + lblMessage.Text.Length) + 30;
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
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenWidth - this.Width - 5;
            toastY = screenHeight - this.Height + 70;

            this.Location = new Point( toastX, toastY );
        }

        int y = 100;
        private void toastHide_Tick( object sender, EventArgs e ) {
            y--;
            if ( y <= 0 ) {
                toastY += 1;
                this.Location = new Point ( toastX, toastY += 10 );
                if ( toastY > 800 ) {
                    toastHide.Stop();
                    y = 100;
                    this.Close();
                }
            }
        }

        private void toastTimer_Tick( object sender, EventArgs e ) {
            toastY -= 10;
            this.Location = new Point(toastX, toastY);
            if ( toastY <= 960 ) {
                toastTimer.Stop();
                toastHide.Start();
            }
        }
 
    }
}
