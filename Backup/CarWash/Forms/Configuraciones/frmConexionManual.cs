using CarWash.Custom_Controls;
using Domain;
using Domain.SqlServer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using System.Xml;

namespace CarWash.Forms.Configuraciones {
    public partial class frmConexionManual : Form {
        EncryptedAndDesencrypted connection = new EncryptedAndDesencrypted();

        public frmConexionManual() {
            InitializeComponent();
        }

        private void frmConexionManual_Load( object sender, EventArgs e ) {
            connection.ReadfromXML( txtConnection );
        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message );
            alert.ShowDialog();
        }

        private void btnGenerarCadena_Click( object sender, EventArgs e ) {
            if ( txtConnection.Text == "" ) {
                ShowToast( "ERROR", "No ha especificado una cadena de conexión" );
            } else {
                connection.GuardarConexion( txtConnection.Text );
                ShowToast( "SUCCESS", "Se cambio la cadena de conexión" );
                Application.Restart();
            }
        }

        private void guna2Button1_Click( object sender, EventArgs e ) {
            if ( txtConnection.Text == "" ) {
                ShowToast("ERROR", "No se puede probar la conexión porque no ha especificado una conexión");
            } else {
                var result = connection.isConnection();
                if ( result == true ) {
                    ShowToast( "SUCCESS", "Conexión realizada con éxito" );
                } else if ( result == false ) {
                    ShowToast( "ERROR", "Sin conexión a la Base de Datos, escriba una conexión válida" );
                }
            }
        }
    }
}
