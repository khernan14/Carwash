using CarWash.Custom_Controls;
using Common;
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

namespace CarWash.Forms.Cajas {
    public partial class frmCierreCaja : Form {
        CajasD cajas = new CajasD();

        public frmCierreCaja() {
            InitializeComponent();
        }
        private void frmCierreCaja_Load( object sender, EventArgs e ) {

        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message, this );
            alert.ShowDialog();
        }

        private void btnCerrarTurno_Click( object sender, EventArgs e ) {
            try {
                int cajaID = int.Parse(UserLoginCache.cajaID.ToString());
                cajas.CerrarCaja(cajaID, dtpFecha.Value, dtpFecha.Value);
                ShowToast("SUCCESS", "Cierre de Caja exitoso");
            } catch ( Exception ex ) {
                ShowToast("ERROR", ex.Message);
            }
        }

    }
}
