using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain {
    public class UsuariosD {
        private UsuariosDA usuarios = new UsuariosDA();

        public DataTable Mostrar() {
            DataTable tabla = new DataTable();
            tabla = usuarios.Mostrar();
            return tabla;
        }

        public DataTable Insertar( string nombres, string usuario, string password, byte[] icono, string nombreIcono, string correo, string rol ) {
            DataTable tabla = new DataTable();
            tabla = usuarios.Insertar( nombres, usuario, password, icono, nombreIcono, correo, rol );
            return tabla;
        }

        public DataTable Actualizar( int codigo, string nombres, string usuario, string password, byte[] icono, string nombreIcono, string correo, string rol ) {
            DataTable tabla = new DataTable();
            tabla = usuarios.Actualizar( codigo, nombres, usuario, password, icono, nombreIcono, correo, rol );
            return tabla;
        }

        public DataTable Eliminar( int codigo ) {
            DataTable tabla = new DataTable();
            tabla = usuarios.Eliminar( codigo );
            return tabla;
        }

        public DataTable Buscar( string buscar ) {
            DataTable tabla = new DataTable();
            tabla = usuarios.Buscar( buscar );
            return tabla;
        }
    }
}
