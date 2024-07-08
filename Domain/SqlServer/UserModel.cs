using DataAccess.SqlServer;
using Domain.Metodos;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain {
    public class UserModel {
        UserDao usuario = new UserDao();
        string serial;

        public bool MostrarUsuarios() {
            return usuario.MostrarUsuarios();
        }

        public bool isLoginUser( string user, string password ) {
            return usuario.Login( user, password );
        }

        public DataTable LoginsControl() {
            DataTable dt = new DataTable();
            string serialPCID = SerialCaja( serial );
            serial = EncryptData.Encriptar(serialPCID.Trim());
            dt = usuario.LoginsControl(serial);
            return dt;
        }

        public string SerialCaja(string lblSerialPC) {
            // Obtener el serial de la PC
            ManagementObjectSearcher MOS = new ManagementObjectSearcher( "SELECT * FROM Win32_BaseBoard" );
            foreach ( ManagementObject getSerial in MOS.Get() ) {
                lblSerialPC = getSerial.Properties[ "SerialNumber" ].Value.ToString();
                showBoxSerial( lblSerialPC );
            }return lblSerialPC;
        }

        private bool showBoxSerial( string serial ) {
            return usuario.CargarCajas( serial );
        }

        public bool isOpenedBox( string serial, int usuarioID ) {
            return usuario.isOpenedBox( serial, usuarioID );
        }

        public bool CargarUsuarios( FlowLayoutPanel flPanel, EventHandler myEventLabel, EventHandler myEventImage ) {
            return usuario.CargarUsuarios( flPanel, myEventLabel, myEventImage );
        }

        public string recoverPassword( string userRequesting ) {
            return usuario.recoverPassword( userRequesting );
        }

        public bool DatabaseExists( ) {
            return usuario.DatabaseExists();
        }
        
        public bool DatabaseHasUsers() {
            return usuario.DatabaseHasUsers();
        }
    }
}
