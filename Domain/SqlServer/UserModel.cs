using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain {
    public class UserModel {
        UserDao usuario = new UserDao();

        public bool isLoginUser( string user, string password ) {
            return usuario.Login( user, password );
        }

        public bool showBoxSerial( string serial ) {
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
    }
}
