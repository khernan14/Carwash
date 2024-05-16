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

namespace CarWash.Reportes.Kardex.ReportInventarios {
    public partial class frmReporteInventario : Form {
        KardexD kardex = new KardexD();
        rpInventario rpInventarios = new rpInventario();
        public frmReporteInventario() {
            InitializeComponent();
        }

        private void frmReporteInventario_Load( object sender, EventArgs e ) {
            DataTable dataSource = kardex.ReporteInventario( );
            rpInventarios.DataSource = dataSource;
            rpInventarios.table1.DataSource = dataSource;
            reportViewer1.Report = rpInventarios;

            reportViewer1.Refresh();
        }

        private void btnImprimir_Click( object sender, EventArgs e ) {
            //DataTable dataSource = kardex.ReporteInventario();
            //rpInventarios.DataSource = dataSource;
            //rpInventarios.table1.DataSource = dataSource;
            //reportViewer1.Report = rpInventarios;
            //reportViewer1.Refresh();
        }

        private void reportViewer1_Load( object sender, EventArgs e ) {

        }
    }
}
