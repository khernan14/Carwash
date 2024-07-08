using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS {
    public class ConsumidoresD {
        ConsumidoresDA consumidor = new ConsumidoresDA();
        DataTable table = new DataTable();

        public DataTable InsertarConsumidor( string nombre, string direccionFacturacion, string ruc, string telefono, string tipoConsumidor, string estado, string saldo ) {
            table = consumidor.InsertarConsumidor(nombre, direccionFacturacion, ruc, telefono, tipoConsumidor, estado, saldo);
            return table;
        }
    }
}
