using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS {
    public class GruposD {
        GruposDA grupos = new GruposDA();

        public DataTable Mostrar() {
            DataTable tabla = new DataTable();
            tabla = grupos.Mostrar();
            return tabla;
        }

        public DataTable Buscar( string buscar ) {
            DataTable tabla = new DataTable();
            tabla = grupos.Buscar( buscar );
            return tabla;
        }

        public DataTable Insertar( string linea ) {
            DataTable tabla = new DataTable();
            tabla = grupos.Insertar( linea );
            return tabla;
        }

        public DataTable Actualizar( int categoriaID, string linea ) {
            DataTable tabla = new DataTable();
            tabla = grupos.Actualizar(categoriaID, linea );
            return tabla;
        }
    }
}
