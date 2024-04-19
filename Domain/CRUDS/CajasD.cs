using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS {
    public class CajasD {
        private CajasDA cajas = new CajasDA();

        public DataTable Insertar( int usuarioID, int cajaID ) {
            DataTable tabla = new DataTable();
            tabla = cajas.Insertar( usuarioID, cajaID );
            return tabla;
        }

        public DataTable EditarSaldoInicial( int cajaID, decimal saldoInicial ) {
            DataTable tabla = new DataTable();
            tabla = cajas.EditarSaldoInicial( cajaID, saldoInicial );
            return tabla;
        }

        public DataTable CerrarCaja( int cajaID, DateTime fechaFin, DateTime fechaCierre ) {
            DataTable tabla = new DataTable();
            tabla = cajas.CerrarCaja( cajaID, fechaFin, fechaCierre );
            return tabla;
        }
    }
}
