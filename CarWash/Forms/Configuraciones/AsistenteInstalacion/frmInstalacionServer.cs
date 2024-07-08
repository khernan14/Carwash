using Domain.Metodos;
using Domain.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash.Forms.Configuraciones.AsistenteInstalacion {
    public partial class frmInstalacionServer : Form {
        ServerD server = new ServerD();
        public static int milisegundos = 0;
        public static int   segundos = 0;
        public static bool databaseCreated = false;

        public frmInstalacionServer() {
            InitializeComponent();
        }

        private void frmInstalacionServer_Load( object sender, EventArgs e ) {
            CargaInicial();
        }


        private void DeleteDataBase() {
            server.DeleteDataBase();
        }

        private void CreateDataBase() {
            var result = server.CreateDataBase();
            if ( result == true ) {
                databaseCreated = true; // La base de datos fue creada
                pnlLoader.Visible = true;
                pnlTimer.Visible = false;
                Label1.Text = @"Instancia Encontrada...No Cierre esta Ventana, se cerrara Automaticamente cuando este todo Listo";
                timerSegAndMili.Start();
            } else {
                MostrarPanelesErrores();
            }
        }

        private void MostrarPanelesErrores() {
            this.Cursor = Cursors.Default;
            pnlLoader.Visible = false;
            btnInstalar.Visible = true;
            lblbuscador_de_servidores.Text = "De click a Instalar Servidor, luego de click a SI cuando se le pida, luego presione ACEPTAR y espere por favor";
        }

        private void CargaInicial() {
            Cursor = Cursors.WaitCursor;
            if ( !databaseCreated ) {
                //DeleteDataBase();
                CreateDataBase();
            } else {
                MostrarPanelesErrores(); // Mostrar paneles de error si la base de datos no se crea
            }
        }

        private void timerSegAndMili_Tick( object sender, EventArgs e ) {
            // Incrementa milisegundos y segundos
            timerTemporizador.Stop();
            timerSegAndMili.Interval = 10;
            milisegundos += 10; // Incrementar por el intervalo del Timer

            if ( milisegundos >= 800 ) {
                segundos += 1;
                milisegundos = 0;
            }

            int minutos = segundos / 60;
            int segundosRestantes = segundos % 60;

            // Formatear el tiempo como mm:ss
            lblTime.Text = $"{minutos:D2}:{segundosRestantes:D2}";

            if ( segundos == 15 ) {
                timerSegAndMili.Stop();
                // Guardar un estado indicando que la base de datos fue creada
                //Properties.Settings.Default.DatabaseCreated = "All";
                //Properties.Settings.Default.Save();
                Application.Restart();
            }
        }

        private void btnInstalar_Click( object sender, EventArgs e ) {
            timerCreateIni.Start();
            server.ExecuteSQLServer();
            pnlLoader.Visible = true;
            pnlTimer.Visible = true;
            pnlLoader.Dock = DockStyle.Fill;
            timerTemporizador.Start();
        }

        private void timerCreateIni_Tick( object sender, EventArgs e ) {
            server.CreateConfigurationFile(timerCreateIni);
        }

        private void timerTemporizador_Tick( object sender, EventArgs e ) {
            // Incrementa milisegundos y segundos
            timerTemporizador.Interval = 10;
            milisegundos += 10; // Incrementar por el intervalo del Timer

            if ( milisegundos >= 700 ) {
                segundos += 1;
                milisegundos = 0;
            }

            int minutos = segundos / 60;
            int segundosRestantes = segundos % 60;

            // Formatear el tiempo como mm:ss
            lblTime.Text = $"{minutos:D2}:{segundosRestantes:D2}";

            if ( minutos == 6 ) {
                timerTemporizador.Enabled = false;
                server.CreateDataBase();
                timerSegAndMili.Start();
            }
        }
    }
}
