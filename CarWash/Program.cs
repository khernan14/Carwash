﻿using CarWash.Forms;
using CarWash.Forms.Cajas;
using CarWash.Forms.Configuraciones;
using CarWash.Forms.Configuraciones.AsistenteInstalacion;
using CarWash.Forms.Inventario;
using CarWash.Forms.Productos;
using CarWash.Reportes.Kardex.ReportInventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash {
    internal static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new frmLogin() );
        }
    }
}
