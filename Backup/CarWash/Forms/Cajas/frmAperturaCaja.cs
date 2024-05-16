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
    public partial class frmAperturaCaja : Form {
        CajasD cajas = new CajasD();
        public frmAperturaCaja() {
            InitializeComponent();
        }

        private void frmAperturaCaja_Load( object sender, EventArgs e ) {

        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message );
            alert.ShowDialog();
        }

        private void btnIniciarSesion_Click( object sender, EventArgs e ) {
            try {
                int cajaID = int.Parse( UserLoginCache.cajaID.ToString() );
                decimal saldoRestante = decimal.Parse( txtCajaInicial.Text);
                cajas.EditarSaldoInicial( cajaID, saldoRestante );

                frmPrincipalVentas frm = new frmPrincipalVentas();
                this.Hide();
                frm.ShowDialog();

            } catch ( Exception ex ) {
                ShowToast("ERROR", ex.Message);
            }
        }

        private void btnOmitir_Click( object sender, EventArgs e ) {
            try {
                int cajaID = int.Parse( UserLoginCache.cajaID.ToString() );
                decimal saldoRestante = decimal.Parse( "0.00" );
                cajas.EditarSaldoInicial( cajaID, saldoRestante );

                frmPrincipalVentas frm = new frmPrincipalVentas();
                this.Hide();
                frm.ShowDialog();

            } catch ( Exception ex ) {
                ShowToast( "ERROR", ex.Message );
            }
        }
    }
}
