using CarWash.Custom_Controls;
using Domain;
using Domain.CRUDS;
using Domain.SqlServer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash.Forms.Configuraciones.AsistenteInstalacion {
    public partial class frmRegistroEmpresa : Form {
        EmpresasD empresas = new EmpresasD();
        CajasD cajas = new CajasD();
        TicketsD tickets = new TicketsD();
        UserModel model = new UserModel();
        Validaciones validacion = new Validaciones();
        ServerD server = new ServerD();

        private string lblSerialPC;

        string usaImpuesto, modoBusqueda;
        bool validateEmail = false;
        public static string correo;


        public frmRegistroEmpresa() {
            InitializeComponent();
        }

        private void frmRegistroEmpresa_Load( object sender, EventArgs e ) {
            model.SerialCaja(lblSerialPC);
            if ( rbSi.Checked ) {
                pnlImpuestos.Visible = true;
            }
            if ( rbNo.Checked ) {
                pnlImpuestos.Visible = false;
            }
        }

        private void ShowToast( string type, string message ) {
            AlertBoxs alert = new AlertBoxs( type, message, this );
            alert.ShowDialog();
        }

        private byte[] ConvertirImg() {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picPerfil.Image.Save( ms, System.Drawing.Imaging.ImageFormat.Jpeg );
            return ms.GetBuffer();
        }

        private void picPerfil_Click( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "";
            ofd.Filter = "Imagenes |*.jpg;*.*png";
            ofd.FilterIndex = 2;
            ofd.Title = "Insertar Logo de tu empresa";
            DialogResult dr = ofd.ShowDialog();
            if ( dr == DialogResult.OK ) {
                picPerfil.BackgroundImage = null;
                picPerfil.Image = Image.FromFile( ofd.FileName );
                picPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnBackup_Click( object sender, EventArgs e ) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string ruta = string.Empty;

            if ( fbd.ShowDialog() == DialogResult.OK ) {
                txtRuta.Text = fbd.SelectedPath;
                ruta = txtRuta.Text;
                if ( ruta.Contains( @"C:\" ) ) {
                    ShowToast( "ERROR", "Seleccione una ruta diferente al Disco C:" );
                    txtRuta.Text = "";
                } else {
                    txtRuta.Text = fbd.SelectedPath;
                }
            }
        }

        private void chkBarcode_CheckedChanged( object sender, EventArgs e ) {
            if ( chkBarcode.Checked ) {
                chkTeclado.Checked = false;
                modoBusqueda = "Lectora";
            }
            if ( !chkBarcode.Checked ) {
                chkTeclado.Checked = true;
            }
        }

        private void chkTeclado_CheckedChanged( object sender, EventArgs e ) {
            if ( chkTeclado.Checked ) {
                chkBarcode.Checked = false;
                modoBusqueda = "Teclado";
            } else if ( !chkTeclado.Checked ) {
                chkBarcode.Checked = true;
                modoBusqueda = "Lectora";
            }
        }

        private void cmbPais_SelectedIndexChanged( object sender, EventArgs e ) {
            cmbMoneda.SelectedIndex = cmbPais.SelectedIndex;
        }

        private void txtCorreo_TextChanged( object sender, EventArgs e ) {
            validateEmail = validacion.ValidarEmail( txtCorreo.Text, lblMessage, txtCorreo );
        }

        private void CreateInit() {
            //Create Company
            empresas.Insertar(
            txtNombre.Text,
            ConvertirImg(),
            cmbImpuesto.Text,
            decimal.Parse( cmbPorcentajeImpuesto.Text ),
            cmbMoneda.Text,
            usaImpuesto,
            modoBusqueda,
            txtRuta.Text,
            txtCorreo.Text,
            "Ninguna",
            DateTime.Now,
            1, "Pendiente",
            "General",
            cmbPais.Text,
            "No"
            );
            //Create Boxs
            cajas.InsertarCajas(txtCaja.Text, lblSerialPC);

            //Crear Comprobantes
            cajas.InsertarSerializacion("T", "6", "0", "Ventas", "Tikcet", "Si");
            cajas.InsertarSerializacion("B", "6", "0", "Ventas", "Boleta", "-");
            cajas.InsertarSerializacion("F", "6", "0", "Ventas", "Factura", "-");
            cajas.InsertarSerializacion("I", "6", "0", "Ingreso de Cobros", "Ingreso", "-");
            cajas.InsertarSerializacion("E", "6", "0", "Egreso de Pagos", "Egreso", "-");

            //Crear Diseño de Ticket por defecto
            tickets.TicketsDesign(
                    "RUC identificador fiscal de la empresa",
                    "Calle, Nro, avenida",
                    "Provincia - Departamento - Pais",
                    "Nombre Moneda",
                    "Agradecimiento",
                    "Pagina Web o Facebook",
                    "Anuncio",
                    "Datos Fiscales - Numero de autorizacion, Resolucion...",
                    "Ticket no Fiscal"
                );
        }

        private void btnSiguiente_Click( object sender, EventArgs e ) {

            bool isNombreValid = validacion.ValidarTexboxsVacios( txtNombre );
            bool isCajaValid = validacion.ValidarTexboxsVacios( txtCaja );
            bool isRutaValid = validacion.ValidarTexboxsVacios( txtRuta );
            bool isCorreoValid = validacion.ValidarTexboxsVacios( txtCorreo );

            if ( !isNombreValid || !isCajaValid || !isCorreoValid ) {
                if ( !isRutaValid ) {
                    if ( validateEmail == true ) {
                        if ( cmbPais.SelectedIndex != 0 ) {
                            if ( chkBarcode.Checked == true || chkTeclado.Checked == true ) {
                                //Creacion de la empresa, la caja y los comprobantes
                                CreateInit();
                                ShowToast( "SUCCES", "Almacenado correctamente" );
                                correo = txtCorreo.Text;
                                this.Hide();
                                frmUsuariosAuth frm = new frmUsuariosAuth();
                                frm.ShowDialog();
                                this.Dispose();
                                if ( usaImpuesto != "" ) {

                                } else {
                                    ShowToast( "ERROR", "Debe Seleccionar si vende con impuestos" );
                                }
                            } else {
                                ShowToast( "ERROR", "Debe seleccionar si la busqueda de producto es por lectora o teclado" );
                            }
                        } else {
                            ShowToast( "ERROR", "Debe seleccionar un pais" );
                        }
                    } else {
                        ShowToast( "ERROR", "Debe ingresar un correo electrónico válido" );
                    }
                } else {
                    ShowToast( "ERROR", "Debe seleccionar una carpeta para el backup" );
                }
            } else {
                ShowToast( "ERROR", "No puede dejar campos vacios" );
            }


        }

        private void rbSi_CheckedChanged( object sender, EventArgs e ) {
            if ( rbSi.Checked ) {
                usaImpuesto = "Si";
                pnlImpuestos.Visible = true;
            } else {
                usaImpuesto = "No";
                pnlImpuestos.Visible = false;
            }
        }

        private void rbNo_CheckedChanged( object sender, EventArgs e ) {
            if ( rbNo.Checked ) {
                usaImpuesto = "No";
                pnlImpuestos.Visible = false;
            } else {
                usaImpuesto = "Si";
                pnlImpuestos.Visible = true;
            }
        }
    }
}
