using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash {
    public partial class frmUsuarios : Form {

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public Form currentChildForm;
        public frmUsuarios() {
            InitializeComponent();
        }

        private void frmUsuarios_Load( object sender, EventArgs e ) {

        }

        private void OpenChildForm( Form childForm ) {
            if ( currentChildForm != null ) {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnlDesktop.Controls.Add( childForm );
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnNuevo_Click( object sender, EventArgs e ) {
            //pnlDataGrid.Visible = false;
            OpenChildForm(new frmInterfazUsuario());
        }

        private void btnCancelar_Click( object sender, EventArgs e ) {
            //pnlDataGrid.Visible = true;
            currentChildForm.Close();
        }
    }
}
