using Domain;
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
    public partial class frmServidorRemoto : Form {
        UserModel model = new UserModel();
        frmRegistroEmpresa empresa = new frmRegistroEmpresa();
        frmInstalacionServer instalacionServer = new frmInstalacionServer();

        public frmServidorRemoto() {
            InitializeComponent();
        }

        private void frmServidorRemoto_Load( object sender, EventArgs e ) {
            //Listar();
        }

        private void Listar() {
            //pnlDatos.Location = new Point( (Width - pnlDatos.Width) / 2, (Height - pnlDatos.Height) / 2 );
            //// Si la base de datos existe, verificar si tiene usuarios
            //if ( model.DatabaseExists() ) {
            //    if ( model.DatabaseHasUsers() ) {
            //        frmRegistroEmpresa frm2 = new frmRegistroEmpresa();
            //        this.Hide();
            //        frm2.ShowDialog();
            //        this.Close();
            //    } else {
            //        frmLogin frm = new frmLogin();
            //        this.Hide();
            //        frm.ShowDialog();
            //        this.Close();
            //    }
            //}

        }

        private void btnPrincipal_Click( object sender, EventArgs e ) {
            //Dispose();
            instalacionServer.ShowDialog();
            this.Close();
        }
    }
}
